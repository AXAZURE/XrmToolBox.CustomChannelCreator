using Microsoft.Xrm.Sdk.Query;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace CustomChannelCreator
{
    partial class CustomChannelCreator
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomChannelCreator));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadEntities = new System.Windows.Forms.ToolStripButton();
            this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Create = new System.Windows.Forms.ToolStripButton();
            this.customChannelName = new System.Windows.Forms.TextBox();
            this.CustomChannel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.messagePartName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lookUp = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.messagepartnamecolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.typecolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.entitylookupcolumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.viewIdColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.solutionName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.publisher = new System.Windows.Forms.ComboBox();
            this.type = new System.Windows.Forms.TextBox();
            this.customApi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.viewId = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.required = new System.Windows.Forms.CheckBox();
            this.RequiredHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.toolStripSeparator1,
            this.LoadEntities,
            this.tssSeparator1,
            this.Create});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStripMenu.Size = new System.Drawing.Size(1551, 27);
            this.toolStripMenu.TabIndex = 4;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(107, 24);
            this.tsbClose.Text = "Close this tool";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // LoadEntities
            // 
            this.LoadEntities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadEntities.Image = ((System.Drawing.Image)(resources.GetObject("LoadEntities.Image")));
            this.LoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadEntities.Name = "LoadEntities";
            this.LoadEntities.Size = new System.Drawing.Size(94, 24);
            this.LoadEntities.Text = "LoadEntities";
            this.LoadEntities.Click += new System.EventHandler(this.Load_Click_1);
            // 
            // tssSeparator1
            // 
            this.tssSeparator1.Name = "tssSeparator1";
            this.tssSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // Create
            // 
            this.Create.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Create.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(56, 24);
            this.Create.Text = "Create";
            this.Create.ToolTipText = "Create";
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // customChannelName
            // 
            this.customChannelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.customChannelName.Location = new System.Drawing.Point(179, 150);
            this.customChannelName.Margin = new System.Windows.Forms.Padding(4);
            this.customChannelName.Name = "customChannelName";
            this.customChannelName.Size = new System.Drawing.Size(923, 22);
            this.customChannelName.TabIndex = 5;
            // 
            // CustomChannel
            // 
            this.CustomChannel.AutoSize = true;
            this.CustomChannel.Location = new System.Drawing.Point(17, 159);
            this.CustomChannel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CustomChannel.Name = "CustomChannel";
            this.CustomChannel.Size = new System.Drawing.Size(144, 16);
            this.CustomChannel.TabIndex = 6;
            this.CustomChannel.Text = "Custom Channel Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 256);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Message Parts";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(25, 288);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(295, 164);
            this.listBox1.TabIndex = 9;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(583, 424);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(100, 28);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(1380, 424);
            this.removeButton.Margin = new System.Windows.Forms.Padding(4);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(100, 28);
            this.removeButton.TabIndex = 11;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // messagePartName
            // 
            this.messagePartName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messagePartName.Location = new System.Drawing.Point(523, 288);
            this.messagePartName.Margin = new System.Windows.Forms.Padding(4);
            this.messagePartName.Name = "messagePartName";
            this.messagePartName.Size = new System.Drawing.Size(160, 22);
            this.messagePartName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 297);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Message Part Name";
            // 
            // lookUp
            // 
            this.lookUp.FormattingEnabled = true;
            this.lookUp.Location = new System.Drawing.Point(523, 322);
            this.lookUp.Margin = new System.Windows.Forms.Padding(4);
            this.lookUp.Name = "lookUp";
            this.lookUp.Size = new System.Drawing.Size(160, 24);
            this.lookUp.TabIndex = 15;
            this.lookUp.SelectedIndexChanged += new System.EventHandler(this.lookUp_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(347, 332);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Entity Reference";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView1.BackgroundImageTiled = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.messagepartnamecolumn,
            this.typecolumn,
            this.RequiredHeader,
            this.entitylookupcolumn,
            this.viewIdColumn});
            this.listView1.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(716, 288);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listView1.Size = new System.Drawing.Size(639, 164);
            this.listView1.TabIndex = 17;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.UseWaitCursor = true;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // messagepartnamecolumn
            // 
            this.messagepartnamecolumn.Text = "Message Part Name";
            this.messagepartnamecolumn.Width = 170;
            // 
            // typecolumn
            // 
            this.typecolumn.Text = "Type";
            this.typecolumn.Width = 100;
            // 
            // entitylookupcolumn
            // 
            this.entitylookupcolumn.DisplayIndex = 2;
            this.entitylookupcolumn.Text = "Entity Lookup";
            this.entitylookupcolumn.Width = 100;
            // 
            // viewIdColumn
            // 
            this.viewIdColumn.DisplayIndex = 3;
            this.viewIdColumn.Text = "Entity View";
            this.viewIdColumn.Width = 150;
            // 
            // solutionName
            // 
            this.solutionName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.solutionName.Location = new System.Drawing.Point(179, 118);
            this.solutionName.Margin = new System.Windows.Forms.Padding(4);
            this.solutionName.Name = "solutionName";
            this.solutionName.Size = new System.Drawing.Size(923, 22);
            this.solutionName.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 127);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Solution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Publisher";
            // 
            // publisher
            // 
            this.publisher.FormattingEnabled = true;
            this.publisher.Location = new System.Drawing.Point(179, 85);
            this.publisher.Margin = new System.Windows.Forms.Padding(4);
            this.publisher.Name = "publisher";
            this.publisher.Size = new System.Drawing.Size(923, 24);
            this.publisher.TabIndex = 25;
            // 
            // type
            // 
            this.type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.type.Enabled = false;
            this.type.Location = new System.Drawing.Point(350, 430);
            this.type.Margin = new System.Windows.Forms.Padding(4);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(160, 22);
            this.type.TabIndex = 22;
            // 
            // customApi
            // 
            this.customApi.FormattingEnabled = true;
            this.customApi.Location = new System.Drawing.Point(179, 182);
            this.customApi.Margin = new System.Windows.Forms.Padding(4);
            this.customApi.Name = "customApi";
            this.customApi.Size = new System.Drawing.Size(923, 24);
            this.customApi.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 190);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 16);
            this.label6.TabIndex = 24;
            this.label6.Text = "Custom API";
            // 
            // viewId
            // 
            this.viewId.FormattingEnabled = true;
            this.viewId.Location = new System.Drawing.Point(523, 357);
            this.viewId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewId.Name = "viewId";
            this.viewId.Size = new System.Drawing.Size(160, 24);
            this.viewId.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(347, 361);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "View Entity Reference";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // required
            // 
            this.required.AutoSize = true;
            this.required.Location = new System.Drawing.Point(523, 397);
            this.required.Name = "required";
            this.required.Size = new System.Drawing.Size(85, 20);
            this.required.TabIndex = 29;
            this.required.Text = "Required";
            this.required.UseVisualStyleBackColor = true;
            // 
            // RequiredHeader
            // 
            this.RequiredHeader.Text = "Required";
            this.RequiredHeader.Width = 113;
            // 
            // CustomChannelCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Controls.Add(this.required);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.viewId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.customApi);
            this.Controls.Add(this.type);
            this.Controls.Add(this.publisher);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.solutionName);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lookUp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messagePartName);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustomChannel);
            this.Controls.Add(this.customChannelName);
            this.Controls.Add(this.toolStripMenu);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CustomChannelCreator";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(1551, 599);
            this.Load += new System.EventHandler(this.MyPluginControl_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        //public List<ListBoxItem> GetInitialitems()
        //{
        //    List<ListBoxItem> retorno = new List<ListBoxItem>();

        //    Dictionary<string, string> items = new Dictionary<string, string> ();
        //    items.Add("192350000", "Text");
        //    items.Add("192350001", "Html");
        //    items.Add("192350002", "Url");
        //    items.Add("192350003", "File");
        //    items.Add("192350004", "Image");
        //    items.Add("192350005", "Lookup");

        //    foreach(var pair in items)
        //    {
        //        ListBoxItem item = new ListBoxItem();
        //        item.Content = pair;
        //        retorno.Add(item);
        //    }
        //    return retorno;
        //}

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TextBox customChannelName;
        private System.Windows.Forms.Label CustomChannel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.TextBox messagePartName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox lookUp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox solutionName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox publisher;
        private System.Windows.Forms.TextBox type;
        private System.Windows.Forms.ToolStripButton Create;
        private System.Windows.Forms.ComboBox customApi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripButton LoadEntities;
        private System.Windows.Forms.ColumnHeader typecolumn;
        private System.Windows.Forms.ColumnHeader entitylookupcolumn;
        private System.Windows.Forms.ColumnHeader messagepartnamecolumn;
        private System.Windows.Forms.ComboBox viewId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader viewIdColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader RequiredHeader;
        private System.Windows.Forms.CheckBox required;
    }
}
