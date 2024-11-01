﻿using CustomChannelCreator.Models;
using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Xml;
using XrmToolBox.Extensibility;
using static System.Windows.Forms.ListView;
using Label = Microsoft.Xrm.Sdk.Label;
using ListViewItem = System.Windows.Forms.ListViewItem;
//using XrmToolBox.Extensibility;

namespace CustomChannelCreator
{
    public partial class CustomChannelCreator : PluginControlBase
    {
        private Settings mySettings;

        public CustomChannelCreator()
        {
            InitializeComponent();
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            //ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));


            // Loads or creates the settings for the plugin
            if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
            {
                mySettings = new Settings();

                LogWarning("Settings not found => a new settings file has been created!");
            }
            else
            {
                LogInfo("Settings found and loaded");
            }
            Utils.DisableControls(this);

            //this.LoadEntities.Enabled = true;
            //Utils.EnableControls(this.LoadEntities);

        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void tsbSample_Click(object sender, EventArgs e)
        {
            // The ExecuteMethod method handles connecting to an
            // organization if XrmToolBox is not yet connected
            ExecuteMethod(GetAccounts);
        }
        private List<ListBoxItem> GetInitialitems()
        {
            List<ListBoxItem> retorno = new List<ListBoxItem>();

            Dictionary<string, string> items = new Dictionary<string, string>
            {
                { "192350000", "Text" },
                { "192350001", "Html" },
                { "192350002", "Url" },
                { "192350003", "File" },
                { "192350004", "Image" },
                { "192350005", "Lookup" }
            };

            foreach (var pair in items)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = pair;
                retorno.Add(item);
            }
            return retorno;
        }
        private void GetAccounts()
        {
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Getting accounts",
                Work = (worker, args) =>
                {
                    args.Result = Service.RetrieveMultiple(new QueryExpression("account")
                    {
                        TopCount = 50
                    });
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    var result = args.Result as EntityCollection;
                    if (result != null)
                    {
                        MessageBox.Show($"Found {result.Entities.Count} accounts");
                    }
                }
            });
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyPluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var obj = sender as ListBoxItem;
            this.messagePartName.Enabled = true;
            this.lookUp.Enabled = true;
            //this.viewId.Enabled = true;
            this.addButton.Enabled = true;
            this.required.Enabled = true;

            var selected = this.listBox1.SelectedItem as CustomListBoxItem;
            if (selected.Text == "Lookup")
            {
                this.label3.Show();
                this.lookUp.Show();
                this.viewId.Show();
                this.label7.Show();
            }
            else
            {
                this.label3.Hide();
                this.viewId.Hide();
                this.lookUp.Hide();
                this.label7.Show();
            }
            this.type.Text = selected.Value;

        }
        public delegate void AddItemCallback();
        void AddItem()
        {
            var name = this.messagePartName.Text;
            var lookup = this.lookUp.SelectedItem != null ? (this.lookUp.SelectedItem as CustomListBoxItem).ToString() : "";
            var type = this.type.Text;
            var view = this.viewId.SelectedItem != null ? (this.viewId.SelectedItem as ComboboxItem)?.Value.Id.ToString() : "";
            var isRequired = this.required.Checked;
            string[] row = { name, type, isRequired.ToString(), lookup, view };
            this.listView1.Items.Add(new System.Windows.Forms.ListViewItem(row));
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            //var name = this.messagePartName.Text;
            //var lookup = this.lookUp.SelectedItem != null ? (this.lookUp.SelectedItem as CustomListBoxItem).ToString() : "";
            //var type = this.type.Text;
            //var view = this.viewId.SelectedItem != null ? (this.viewId.SelectedItem as ComboboxItem)?.Value.Id.ToString() : "";
            //var isRequired = this.required.Checked;
            //string[] row = { name, type, isRequired.ToString(), lookup, view };

            var @delegate = new AddItemCallback(AddItem);
            this.Invoke( @delegate );
            //listView1.Items.Add(new System.Windows.Forms.ListViewItem(row));
            messagePartName.Enabled = false;
            messagePartName.Text = string.Empty;
            lookUp.Enabled = false;
            required.Enabled = false;
            lookUp.SelectedItem = null;
            viewId.Enabled = false;
            viewId.SelectedItem = null;
            this.addButton.Enabled = false;
            this.viewId.Items.Clear();

        }
        public delegate ComboboxItem GetValueCallback(System.Windows.Forms.ComboBox item);
        ComboboxItem getValue(System.Windows.Forms.ComboBox item)
        {
            return item.SelectedItem as ComboboxItem;
        }
        public delegate IEnumerable<ListViewItem> GetListViewItemsCallback(System.Windows.Forms.ListView item);

        public IEnumerable<ListViewItem> GetListViewItems(System.Windows.Forms.ListView list)
        {
            var ret = new List<ListViewItem>();
            foreach (ListViewItem item in list.Items)
            {
                ret.Add(item);
            }
            return ret;
                    }
        private void Create_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading...",
                Work = (w, events) =>
                {
                    w.WorkerReportsProgress = true;
                    var solutionName = this.solutionName.Text;
                    var @delegate = new GetValueCallback(getValue);
                    var publisher = this.Invoke(@delegate, this.publisher) as ComboboxItem;
                    //var publisher = this.publisher.SelectedItem as ComboboxItem;
                    w.ReportProgress(-1, "Creating solution...");
                    Entity solution = new Entity("solution");
                    solution.Attributes.Add("uniquename", solutionName.Replace(" ", string.Empty));
                    solution.Attributes.Add("friendlyname", solutionName);
                    solution.Attributes.Add("publisherid", publisher.Value.ToEntityReference());
                    solution.Attributes.Add("version", "1.0.0.0");
                    var solutionId = this.Service.Create(solution);
                    w.ReportProgress(-1, "Creating entity...");
                    var entityChannelInstance = this.customChannelName.Text;
                    var prefix = publisher.Value.GetAttributeValue<string>("customizationprefix");
                    var entityChannelInstanceSchema = $"{prefix}_{entityChannelInstance.Replace(" ", string.Empty).ToLower()}channelinstance";

                    EntityMetadata customchannelinstanceMetadata = new EntityMetadata()
                    {
                        SchemaName = entityChannelInstanceSchema, //Required
                        DisplayName = new Label(entityChannelInstance, 1033),//Required
                        DisplayCollectionName = new Label(entityChannelInstance, 1033),//Required
                        HasNotes = false, //Required
                        HasActivities = false, //Required
                        Description = new Label(
                                   "A table to store information about custom channel instances", 1033),
                        OwnershipType = OwnershipTypes.UserOwned,

                    };
                    CreateEntityRequest createEntityRequest = new CreateEntityRequest
                    {
                        Entity = customchannelinstanceMetadata,
                        PrimaryAttribute = new StringAttributeMetadata
                        {
                            SchemaName = $"{prefix}_name",
                            RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                            MaxLength = 100,
                            FormatName = StringFormatName.Text,
                            DisplayName = new Label($"{entityChannelInstance} Channel Instance Name", 1033),
                            Description = new Label("The primary column for the Bank Account table.", 1033)
                        },
                        SolutionUniqueName = solutionName.Replace(" ", string.Empty)
                    };
                    this.Service.Execute(createEntityRequest);
                    w.ReportProgress(-1, "Creating relationship...");
                    var createRelationshipRequest = new CreateOneToManyRequest();
                    var oneToManyRelationship = new OneToManyRelationshipMetadata
                    {
                        ReferencingEntity = "msdyn_channelinstance",
                        ReferencedEntity = entityChannelInstanceSchema,
                        ReferencingEntityNavigationPropertyName = $"msdyn_extendedentityid_{entityChannelInstanceSchema}",
                        SchemaName = $"msdyn_extendedentityid_{entityChannelInstanceSchema}"
                    };

                    createRelationshipRequest.OneToManyRelationship = oneToManyRelationship;
                    createRelationshipRequest.Parameters["Lookup"] = new LookupAttributeMetadata()
                    {
                        SchemaName = "msdyn_extendedentityId",
                        DisplayName = new Label("Extended Entity Id", 1033),


                    };
                    createRelationshipRequest.SolutionUniqueName = solutionName.Replace(" ", string.Empty);

                    this.Service.Execute(createRelationshipRequest);
                    w.ReportProgress(-1, "Creation channel definition...");
                    var retrieveEntityResponse = Utils.RetrieveEntityMetadata(this.Service, entityChannelInstanceSchema);

                    var formQuery = new QueryExpression("systemform");
                    formQuery.Criteria.AddCondition("objecttypecode", ConditionOperator.Equal, retrieveEntityResponse.EntityMetadata.ObjectTypeCode);
                    formQuery.Criteria.AddCondition("type", ConditionOperator.Equal, 2);
                    var form = this.Service.RetrieveMultiple(formQuery);
                    
                    var customAPISelected = this.Invoke(@delegate, this.customApi) as ComboboxItem;

                    Entity channelDefinition = Utils.CreateChannelDefinition(this.Service, entityChannelInstanceSchema, form.Entities.FirstOrDefault()?.Id.ToString(), entityChannelInstance, customAPISelected.Text);

                    var retrieveEntityChannelDefinitionResponse = Utils.RetrieveEntityMetadata(this.Service, "msdyn_channeldefinition");

                    AddSolutionComponentRequest addSolutionComponentRequest = new AddSolutionComponentRequest()
                    {
                        ComponentType = retrieveEntityChannelDefinitionResponse.EntityMetadata.ObjectTypeCode.Value,
                        ComponentId = channelDefinition.Id,
                        SolutionUniqueName = solutionName.Replace(" ", string.Empty)
                    };

                    this.Service.Execute(addSolutionComponentRequest);
                    w.ReportProgress(-1, "Creation messageparts...");
                    var retrieveEntityChannelDefinitionMessagepartResponse = Utils.RetrieveEntityMetadata(this.Service, "msdyn_channelmessagepart");

                    List<Entity> messageParts = new List<Entity>();
                    var @delegateListViewItesm = new GetListViewItemsCallback(GetListViewItems);
                    var listViewItems = this.Invoke(@delegateListViewItesm, this.listView1) as List<ListViewItem>;
                    foreach (ListViewItem mp in listViewItems)
                    {
                        Entity messagePart = Utils.CreateMessagePart(this.Service, channelDefinition, mp.SubItems[0].Text, mp.SubItems[1].Text, mp.SubItems[3].Text, mp.SubItems[4].Text, mp.SubItems[2].Text);
                        messageParts.Add(messagePart);
                        AddSolutionComponentRequest addSolutionComponentRequest2 = new AddSolutionComponentRequest()
                        {
                            ComponentType = retrieveEntityChannelDefinitionMessagepartResponse.EntityMetadata.ObjectTypeCode.Value,
                            ComponentId = messagePart.Id,
                            SolutionUniqueName = solutionName.Replace(" ", string.Empty)
                        };
                        this.Service.Execute(addSolutionComponentRequest2);
                    }

                },
                 ProgressChanged = events =>
                 {
                     // it will display "I have found the user id" in this example
                     SetWorkingMessage(events.UserState.ToString());
                 },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });

            Cursor = Cursors.Default;
        }

        private void Load_Click_1(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.publisher.Enabled = true;
            this.solutionName.Enabled = true;
            this.customChannelName.Enabled = true;
            this.customApi.Enabled = true;
            this.listBox1.Enabled = true;
            this.listView1.Enabled = true;

            IEnumerable<ComboboxItem> items = new List<ComboboxItem>();
            IEnumerable<ComboboxItem> itemsCAPI = new List<ComboboxItem>();
            IEnumerable<CustomListBoxItem> messageParts = new List<CustomListBoxItem>();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading...",
                Work = (w, events) =>
                {
                    // This code is executed in another thread
                    //this.Cursor = Cursors.WaitCursor;

                    w.ReportProgress(-1, "Retrieving publishers...");
                    var queryPublisher = new QueryExpression("publisher");
                    queryPublisher.ColumnSet.AddColumns("customizationprefix", "uniquename", "friendlyname");
                    items = this.Service.RetrieveMultiple(queryPublisher)?.Entities.Select(x => new ComboboxItem(x.GetAttributeValue<string>("friendlyname"), x)).OrderBy(x => x.Text);
                    // this.publisher.Items.AddRange(items);
                    w.ReportProgress(-1, "Retrieving Custom APIs");
                    var queryCustomAPI = new QueryExpression("customapi");
                    queryCustomAPI.ColumnSet.AddColumns("uniquename", "displayname", "name");
                    itemsCAPI = this.Service.RetrieveMultiple(queryCustomAPI)?.Entities.Select(x => new ComboboxItem(x.GetAttributeValue<string>("uniquename"), x)).OrderBy(x => x.Text);
                    //this.customApi.Items.AddRange(itemsCAPI);
                    w.ReportProgress(-1, "Setting messageparts types");

                    RetrieveAllEntitiesRequest retrieveAllEntitiesRequest = new RetrieveAllEntitiesRequest();
                    retrieveAllEntitiesRequest.EntityFilters = EntityFilters.Entity;
                    retrieveAllEntitiesRequest.RetrieveAsIfPublished = false;
                    RetrieveAllEntitiesResponse retrieveAllEntitiesResponse = (RetrieveAllEntitiesResponse)this.Service.Execute(retrieveAllEntitiesRequest);
                    messageParts = retrieveAllEntitiesResponse.EntityMetadata.Select(x => new CustomListBoxItem(x.LogicalName, x.ObjectTypeCode.ToString())).OrderBy(x => x.Text);
                    //this.lookUp.Items.AddRange(retrieveAllEntitiesResponse.EntityMetadata.Select(x => new CustomListBoxItem(x.LogicalName, x.ObjectTypeCode.ToString())).OrderBy(x => x.Text).ToArray());
                    events.Result = true;
                },
                ProgressChanged = events =>
                {
                    // it will display "I have found the user id" in this example
                    SetWorkingMessage(events.UserState.ToString());
                },
                PostWorkCallBack = events =>
                {
                    var @delegate = new FillControlsCalback(FillControls);
                    //this.publisher.BeginInvoke(@delegate, );
                    this.Invoke(@delegate,items, itemsCAPI, messageParts );
                    //this.publisher.Items.AddRange(items.ToArray());
                    //this.customApi.Items.AddRange(itemsCAPI.ToArray());
                    //this.lookUp.Items.AddRange(messageParts.ToArray());
                    List<CustomListBoxItem> listBox = new List<CustomListBoxItem>
                    {
                        new CustomListBoxItem("Text", "192350000"),
                        new CustomListBoxItem("Html", "192350001"),
                        new CustomListBoxItem("Url", "192350002"),
                        new CustomListBoxItem("Image", "192350004"),
                        new CustomListBoxItem("File", "192350003"),
                        new CustomListBoxItem("Lookup", "192350005")
                    };

                    listBox.ForEach(x => this.listBox1.Items.Add(x));
                    // This code is executed in the main thread
                    //MessageBox.Show($"You are {(Guid)events.Result}");

                },
                AsyncArgument = null,
                // Progress information panel size
                MessageWidth = 340,
                MessageHeight = 150
            });

            this.Cursor = Cursors.Default;
        }
        void FillControls(IEnumerable<ComboboxItem> publishers, IEnumerable<ComboboxItem> customApis, IEnumerable<CustomListBoxItem> messages)
        {
            this.publisher.Items.AddRange(publishers.ToArray());
            this.customApi.Items.AddRange(customApis.ToArray());
            this.lookUp.Items.AddRange(messages.ToArray());
        }
        public delegate void FillControlsCalback(IEnumerable<ComboboxItem> publishers, IEnumerable<ComboboxItem> customApis, IEnumerable<CustomListBoxItem> messages);
        private void lookUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set Condition Values
            if (this.lookUp.SelectedItem != null)
            {
                this.viewId.Enabled = true;
                var query = new QueryExpression("savedquery");
                query.ColumnSet.AddColumns("name", "returnedtypecode", "savedqueryid");
                query.Criteria.AddCondition("returnedtypecode", ConditionOperator.Equal, Int32.Parse((this.lookUp.SelectedItem as CustomListBoxItem).Value));

                var results = this.Service.RetrieveMultiple(query);
                this.viewId.Items.AddRange(results.Entities.Select(x => new ComboboxItem(x.GetAttributeValue<string>("name"), x)).OrderBy(x => x.Text).ToArray());
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}