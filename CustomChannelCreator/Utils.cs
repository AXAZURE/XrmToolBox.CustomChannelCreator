using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using NuGet.Packaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CustomChannelCreator
{
    public static class Utils
    {


        public static string ByteArrayToZip(byte[] input)
        {
            string solutionZipPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            File.WriteAllBytes(solutionZipPath, input);


            return solutionZipPath;
        }
        public static void ZipAllFilesFromPath(string path, string destinyFile)
        {
            //Stream fileStream = new Stream(destinyFile, FileMode.Create);
            try
            {
                ZipFile.CreateFromDirectory(path, destinyFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string unzipFromPath(string zipPath, string name)
        {
            ZipFile.ExtractToDirectory(zipPath, $"{Path.GetTempPath()}/{name}");

            return $"{Path.GetTempPath()}/{name}";
            // System.IO.Compression.ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
        public static string ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string text = reader.ReadToEnd();
            reader.Close();
            // Read the stream as a string.
            return text;
        }
        public static bool WriteFile(string path, string content)
        {
            using (StreamWriter outputFile = new StreamWriter(path, false))
            {
                outputFile.Write(content);
            }

            return true;
        }
        public static XmlDocument ReadXML(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            return doc;
        }
        public static XmlDocument Process(XmlDocument doc, Entity channelDefinition, List<Entity> messageParts)
        {
            XmlElement channeldefinitions = doc.CreateElement("msdyn_channeldefinitions");
            XmlElement channeldefinitionxml = doc.CreateElement("msdyn_channeldefinition");
            XmlElement msdyn_channeldefinitionexternalentity = doc.CreateElement("msdyn_channeldefinitionexternalentity");
            msdyn_channeldefinitionexternalentity.InnerText = channelDefinition.GetAttributeValue<string>("msdyn_channeldefinitionexternalentity");
            XmlElement msdyn_channeldefinitionexternalformid = doc.CreateElement("msdyn_channeldefinitionexternalformid");
            msdyn_channeldefinitionexternalformid.InnerText = channelDefinition.GetAttributeValue<string>("msdyn_channeldefinitionexternalformid");
            XmlElement msdyn_channeltype = doc.CreateElement("msdyn_channeltype");
            msdyn_channeltype.InnerText = channelDefinition.GetAttributeValue<string>("msdyn_channeltype");
            XmlElement msdyn_description = doc.CreateElement("msdyn_description");
            msdyn_description.InnerText = channelDefinition.GetAttributeValue<string>("msdyn_description");
            XmlElement msdyn_displayname = doc.CreateElement("msdyn_displayname");
            msdyn_displayname.InnerText = channelDefinition.GetAttributeValue<string>("msdyn_displayname");
            XmlElement msdyn_hasdeliveryreceipt = doc.CreateElement("msdyn_hasdeliveryreceipt");
            msdyn_hasdeliveryreceipt.InnerText = channelDefinition.GetAttributeValue<bool>("msdyn_hasdeliveryreceipt") ? "1" : "0";
            XmlElement msdyn_hasinbound = doc.CreateElement("msdyn_hasinbound");
            msdyn_hasinbound.InnerText = channelDefinition.GetAttributeValue<bool>("msdyn_hasinbound") ? "1" : "0";
            XmlElement msdyn_messageformid = doc.CreateElement("msdyn_messageformid");
            XmlElement msdyn_outboundendpointurltemplate = doc.CreateElement("msdyn_outboundendpointurltemplate");
            msdyn_outboundendpointurltemplate.InnerText = channelDefinition.GetAttributeValue<string>("msdyn_outboundendpointurltemplate");
            XmlElement msdyn_specialconsentrequired = doc.CreateElement("msdyn_specialconsentrequired");
            msdyn_specialconsentrequired.InnerText = channelDefinition.GetAttributeValue<bool>("msdyn_specialconsentrequired") ? "1" : "0";
            XmlElement msdyn_supportsaccount = doc.CreateElement("msdyn_supportsaccount");
            msdyn_supportsaccount.InnerText = channelDefinition.GetAttributeValue<bool>("msdyn_supportsaccount") ? "1" : "0";
            XmlElement msdyn_supportsattachment = doc.CreateElement("msdyn_supportsattachment");
            msdyn_supportsattachment.InnerText = channelDefinition.GetAttributeValue<bool>("msdyn_supportsattachment") ? "1" : "0";
            XmlElement msdyn_supportsbinary = doc.CreateElement("msdyn_supportsbinary");
            msdyn_supportsbinary.InnerText = channelDefinition.GetAttributeValue<bool>("msdyn_supportsbinary") ? "1" : "0";
            channeldefinitions.AppendChild(channeldefinitionxml);
            channeldefinitionxml.AppendChild(msdyn_channeldefinitionexternalentity);
            channeldefinitionxml.AppendChild(msdyn_channeldefinitionexternalformid);
            channeldefinitionxml.AppendChild(msdyn_channeltype);
            channeldefinitionxml.AppendChild(msdyn_description);
            channeldefinitionxml.AppendChild(msdyn_displayname);
            channeldefinitionxml.AppendChild(msdyn_hasdeliveryreceipt);
            channeldefinitionxml.AppendChild(msdyn_hasinbound);
            channeldefinitionxml.AppendChild(msdyn_messageformid);
            channeldefinitionxml.AppendChild(msdyn_outboundendpointurltemplate);
            channeldefinitionxml.AppendChild(msdyn_specialconsentrequired);
            channeldefinitionxml.AppendChild(msdyn_supportsaccount);
            channeldefinitionxml.AppendChild(msdyn_supportsattachment);
            channeldefinitionxml.AppendChild(msdyn_supportsbinary);
            XmlAttribute attributeChannelDefinitionId = doc.CreateAttribute("msdyn_channeldefinitionid");
            attributeChannelDefinitionId.Value = channelDefinition.Id.ToString();
            channeldefinitionxml.Attributes.Append(attributeChannelDefinitionId);

            XmlElement messageparts = doc.CreateElement("msdyn_channelmessageparts");

            foreach (var mp in messageParts)
            {
                XmlElement messagePart = doc.CreateElement("msdyn_channelmessagepart");
                XmlAttribute attributeId = doc.CreateAttribute("msdyn_channelmessagepartid");
                attributeId.Value = mp.Id.ToString();
                messagePart.Attributes.Append(attributeId);
                foreach (var attribute in mp.Attributes)
                {
                    if (attribute.Key == "msdyn_channeldefinitionid")
                    {
                        XmlElement channelDef = doc.CreateElement(attribute.Key);
                        XmlElement channelDefId = doc.CreateElement(attribute.Key);
                        channelDefId.InnerText = (attribute.Value as EntityReference).Id.ToString();
                        channelDef.AppendChild(channelDefId);
                        messagePart.AppendChild(channelDef);
                    }
                    else if (attribute.Key != "msdyn_channelmessagepartid")
                    {
                        XmlElement elemento = doc.CreateElement(attribute.Key);
                        elemento.InnerText = GetValue(attribute.Value);
                        messagePart.AppendChild(elemento);
                    }
                }
                messageparts.AppendChild(messagePart);

            }
            doc.FirstChild.AppendChild(channeldefinitions);
            doc.FirstChild.AppendChild(messageparts);
            return doc;
        }
        public static void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (!(c is ToolStrip) && !(c is System.Windows.Forms.Label)) { 
                    //DisableControls(c);
                    c.Enabled = false;
                }
            }
            //con.Enabled = false;
        }

        public static void EnableControls(Control con)
        {
            if (con != null)
            {
                con.Enabled = true;
                EnableControls(con.Parent);
            }
        }
        public static string GetValue(object value)
        {
            if (value is string)
                return (string)value;
            if (value is int)
                return Convert.ToInt32(value).ToString();
            if (value is bool)
                return Convert.ToBoolean(value) ? "1" : "0";
            if (value is long)
                return Convert.ToInt64(value).ToString();
            if (value is float)
                return Convert.ToSingle(value).ToString();
            if (value is double)
                return Convert.ToDouble(value).ToString();
            if (value is decimal)
                return Convert.ToDecimal(value).ToString();
            if (value is DateTime)
                return Convert.ToDateTime(value).ToString();
            if (value is OptionSetValue)
                return ((OptionSetValue)value).Value.ToString();

            return value.ToString();
        }

        public static Entity CreateChannelDefinition(IOrganizationService service, string entityChannelInstanceSchema, string formId, string entityChannelInstance, string customApi)
        {
            Entity channelDefinition = new Entity("msdyn_channeldefinition");
            channelDefinition.Attributes.Add("msdyn_channeldefinitionexternalentity", entityChannelInstanceSchema);
            channelDefinition.Attributes.Add("msdyn_channeldefinitionexternalformid", formId); //fromid
            channelDefinition.Attributes.Add("msdyn_channeltype", "Custom");
            channelDefinition.Attributes.Add("msdyn_displayname", entityChannelInstance);
            channelDefinition.Attributes.Add("msdyn_name", entityChannelInstance);
            channelDefinition.Attributes.Add("msdyn_hasdeliveryreceipt", false);
            channelDefinition.Attributes.Add("msdyn_hasinbound", false);
            channelDefinition.Attributes.Add("msdyn_outboundendpointurltemplate", $"/{customApi}");
            channelDefinition.Attributes.Add("msdyn_specialconsentrequired", false);
            channelDefinition.Attributes.Add("msdyn_supportsaccount", true);
            channelDefinition.Attributes.Add("msdyn_supportsattachment", false);
            channelDefinition.Attributes.Add("msdyn_supportsbinary", true);

            var channelDefinitionId = service.Create(channelDefinition);
            channelDefinition.Id = channelDefinitionId;
            return channelDefinition;
        }
        public static Entity CreateMessagePart(IOrganizationService service,Entity channelDefinition, string text, string type,string entityname,string viewId)
        {
            Entity messagePart = new Entity("msdyn_channelmessagepart");
            messagePart.Attributes.Add("msdyn_channeldefinitionid", new EntityReference("msdyn_channeldefinition", channelDefinition.Id));
            messagePart.Attributes.Add("msdyn_description", text);
            messagePart.Attributes.Add("msdyn_displayname", text);
            messagePart.Attributes.Add("msdyn_isrequired", true);
            messagePart.Attributes.Add("msdyn_maxlength", 1000);
            messagePart.Attributes.Add("msdyn_name", text);
            messagePart.Attributes.Add("msdyn_type", new OptionSetValue(Int32.Parse(type)));
            if (type == "LookUp")
            {
                messagePart.Attributes.Add("msdyn_entityname", entityname);
                messagePart.Attributes.Add("msdyn_entityviewid", viewId);
            }
            var messagepartid = service.Create(messagePart);
            messagePart.Id = messagepartid;
            return messagePart;
        }
        public static RetrieveEntityResponse RetrieveEntityMetadata(IOrganizationService service, string logicalName )
        {
            RetrieveEntityRequest retrieveEntityRequest = new RetrieveEntityRequest();
            retrieveEntityRequest.LogicalName = logicalName;
            retrieveEntityRequest.EntityFilters = EntityFilters.Entity;
            return service.Execute(retrieveEntityRequest) as RetrieveEntityResponse;
        }
    }
}

