// <Snippet11>
namespace Samples.AspNet.CS.Controls
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.Design;
    using System.Web.UI.Design.WebControls;
    using System.Web.UI.WebControls;
    using System.Reflection;
    using System.Xml;
    using System.Configuration;

    // This region-based control renders the content of an XML file.
    [
      Designer(typeof(ControlWithStyleTasksDesigner)),
      ToolboxData("<{0}:ControlWithStyleTasks runat=\"server\" "
                  + "width=\"100%\"></{0}:ControlWithStyleTasks>")
    ]
    public class ControlWithStyleTasks : Panel { }

    [
      Designer(typeof(ControlWithConfigurationSettingDesigner)),
      ToolboxData("<{0}:ControlWithConfigurationSetting runat=\"server\" "
                  + "width=\"100%\"></{0}:ControlWithConfigurationSetting>")
    ]
    public class ControlWithConfigurationSetting : Panel { }

    [
      Designer(typeof(ControlWithButtonTasksDesigner)),
      ToolboxData("<{0}:ControlWithButtonTasks runat=\"server\" "
                  + "width=\"100%\"></{0}:ControlWithButtonTasks>")
    ]
    public class ControlWithButtonTasks : Panel { }


    // Declare a custom button to add dynamically at design time.
    public class NewButton : Button
    {
        public NewButton() { Text = "NewButton"; }
    }


    // This control designer is used to read xml files from the project.
	[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
	public class ControlWithStyleTasksDesigner : PanelContainerDesigner
    {
        private Style _style = null;

        public override string FrameCaption
        {
            get
            {
                return "Container getting styles from the project item.";
            }
        }

        public override Style FrameStyle
        {
            get
            {
                if (_style == null)
                {
                    _style = new Style();
                    _style.Font.Name = "Verdana";
                    _style.Font.Size = new FontUnit("XSmall");
                    _style.BackColor = Color.LightGreen;
                    _style.ForeColor = Color.Black;
                }

                return _style;
            }
        }

        // Create a convenience field for the control.
        private ControlWithStyleTasks myControl;
        public override void Initialize(IComponent component)
        {
            // Create the convenience control.
            base.Initialize(component);
            myControl = (ControlWithStyleTasks)component;
        }

        // The following section creates a designer action list.
        // Add the specific action list for this control. The 
        // procedure here depends upon the specific order for 
        // the list to be added, but always add the base.
		public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists =
                  new DesignerActionListCollection();
                actionLists.AddRange(base.ActionLists);
                actionLists.Add(new MyList(this));
                return actionLists;
            }
        }

        private string _styleConfigPhysicalFile = "";
        protected string StyleConfigurationFile
        {
            get { return _styleConfigPhysicalFile; }
            set
            {
                string styleConfigPhysicalFilePath = String.Empty;
                if (value.Length > 0)
                {
                    // Access the folder and look for the Control.xml file; 
                    // then obtain its physical path to use to set styles 
                    // for this control and control designer.  Obtain the 
                    // actual file and its physical path from WebApplication.
                    IWebApplication webApp =
                      (IWebApplication)Component.Site.GetService(
                        typeof(IWebApplication));
                    if (webApp != null)
                    {
                        // Look for the project items from the root.
                        IProjectItem dataFileProjectItem =
                          webApp.GetProjectItemFromUrl("~/" + value);
                        if (dataFileProjectItem != null)
                        {
                            _styleConfigPhysicalFile = value;
                            styleConfigPhysicalFilePath =
                              dataFileProjectItem.PhysicalPath;
                        }
                    }
                }

                // Get the styles from the XML file.
                SetControlStyleFromConfiguration(styleConfigPhysicalFilePath);
            }
        }

        // Open the XML document and set control properties directly.
        private void SetControlStyleFromConfiguration(string path)
        {
            if (path == null || path == String.Empty)
                return;

            WebControl wc = (WebControl)Component;
            if (wc == null)
                return;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNodeList stylesList = xmlDoc.GetElementsByTagName("style");
            for (int i = 0; i < stylesList.Count; i++)
            {
                if (stylesList[i].Attributes["name"].Value == "BackColor")
                {
                    PropertyDescriptor pd =
                      TypeDescriptor.GetProperties(wc)["BackColor"];
                    if (pd != null)
                        pd.SetValue(wc,
                          Color.FromName(stylesList[i].Attributes["value"].Value));
                }
                if (stylesList[i].Attributes["name"].Value == "ForeColor")
                {
                    PropertyDescriptor pd =
                      TypeDescriptor.GetProperties(wc)["ForeColor"];
                    if (pd != null)
                        pd.SetValue(wc,
                          Color.FromName(stylesList[i].Attributes["value"].Value));
                }
            }
        }

        // Create the action list for this control.
        private class MyList : DesignerActionList
        {
            private ControlWithStyleTasksDesigner _parent;

            public MyList(ControlWithStyleTasksDesigner parent)
                : base(parent.Component)
            {
                _parent = parent;
            }

            [
              TypeConverter(typeof(FileListTypeConverter))
            ]
            public string ConfigureControlStyle
            {
                get { return _parent.StyleConfigurationFile; }
                set
                {
                    _parent.StyleConfigurationFile = value;
                }
            }

            // Provide the list of sorted action items for the host.
            // Note that you can define the items through constructors 
            // or through metadata on the method or property items.
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection();

                items.Add(new DesignerActionTextItem("Configuration",
                                                      "Select"));
                items.Add(new DesignerActionPropertyItem("ConfigureControlStyle",
                                               "Configure XML",
                                               "Select",
                                               String.Empty));
                return items;
            }

            // The type converter needs to be generated with a standard 
            // collection of items from the project.
            private class FileListTypeConverter : TypeConverter
            {
                public override StandardValuesCollection
                  GetStandardValues(ITypeDescriptorContext context)
                {
                    MyList myList = (MyList)context.Instance;
                    IWebApplication webApp =
                      (IWebApplication)myList._parent.Component.Site.GetService(
                        typeof(IWebApplication));

                    ArrayList xmlFiles = new ArrayList();
                    IFolderProjectItem rootItem =
                      (IFolderProjectItem)webApp.RootProjectItem;
                    foreach (IProjectItem item in rootItem.Children)
                    {
                        if (String.Equals(Path.GetExtension(item.Name),
                                          ".xml",
                                          StringComparison.CurrentCultureIgnoreCase))
                        {
                            xmlFiles.Add(item.Name);
                        }
                    }

                    return new StandardValuesCollection(xmlFiles);
                }

                public override bool GetStandardValuesExclusive(
                  ITypeDescriptorContext context)
                {
                    return false;
                }
                public override bool GetStandardValuesSupported(
                  ITypeDescriptorContext context)
                {
                    return true;
                }
            }
        }

    }

    // This control designer is used to obtain the 
    // configuration setting for the title.
    public class ControlWithConfigurationSettingDesigner : PanelContainerDesigner
    {
        public ControlWithConfigurationSettingDesigner() { }

        private Style _style = null;

        public override string FrameCaption
        {
            get
            {
                string title = String.Empty;
                IWebApplication webApp =
                  (IWebApplication)Component.Site.GetService(
                    typeof(IWebApplication));
                if (webApp != null)
                {
                    // Get the Configuration API.
                    Configuration config = webApp.OpenWebConfiguration(true);
                    if (config != null)
                    {
                        AppSettingsSection settingsSection = config.AppSettings;
                        if (settingsSection != null)
                        {
                            title =
                              " .... "
                              + settingsSection.Settings["ContainerControlTitle"]
                              + " ..... ";
                        }
                    }
                }
                return title;
            }
        }

        public override Style FrameStyle
        {
            get
            {
                if (_style == null)
                {
                    _style = new Style();
                    _style.Font.Name = "Verdana";
                    _style.Font.Size = new FontUnit("XSmall");
                    _style.BackColor = Color.LightGreen;
                    _style.ForeColor = Color.Black;
                }

                return _style;
            }
        }
    }

    // This control designer reads from the project file.
	[System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
	public class ControlWithButtonTasksDesigner : PanelContainerDesigner
    {
        public ControlWithButtonTasksDesigner() { }

        private Style _style = null;

        // Add the caption by default. Note that the caption 
        // will only appear if the Web server control 
        // allows child controls rather than properties. 
        public override string FrameCaption
        {
            get { return "Container adding controls to the document."; }
        }

        public override Style FrameStyle
        {
            get
            {
                if (_style == null)
                {
                    _style = new Style();
                    _style.Font.Name = "Verdana";
                    _style.Font.Size = new FontUnit("XSmall");
                    _style.BackColor = Color.LightGreen;
                    _style.ForeColor = Color.Black;
                }

                return _style;
            }
        }

        // The following section creates a designer action list.
        // Add the specific action list for this control. The 
        // procedure here depends upon the specific order for the 
        // list to be added, but always add the base.
		public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists =
                  new DesignerActionListCollection();
                actionLists.AddRange(base.ActionLists);
                actionLists.Add(new MyList3(this));
                return actionLists;
            }
        }

        public void AddButton()
        {
            // Add a standard button.
            Button b = new Button();
            b.Text = "New standard button";
            RootDesigner.AddControlToDocument(b, null, ControlLocation.First);
        }


        public void AddNewButton()
        {
            // Add your custom button.
            NewButton b = new NewButton();
            b.Text = "New custom button";

            // For buttons defined in a different assembly, add the  
            // register directive for the referenced assembly. 
            // assembly. By default, this goes to the document, unless 
            // already defined in the document or in configuration.
            WebFormsReferenceManager wfrm =
              RootDesigner.ReferenceManager;
            wfrm.RegisterTagPrefix(b.GetType());

            RootDesigner.AddControlToDocument(b, null, ControlLocation.Last);
        }


        // Create the action list for this control.
        private class MyList3 : DesignerActionList
        {
            private ControlWithButtonTasksDesigner _parent;
            public MyList3(ControlWithButtonTasksDesigner parent)
                : base(parent.Component)
            {
                _parent = parent;
            }

            public void AddButton()
            {
                _parent.AddButton();
            }
            public void AddNewButton()
            {
                _parent.AddNewButton();
            }

            // Provide the list of sorted action items for the host.
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection();

                items.Add(new DesignerActionTextItem("Add Control", "Add"));
                items.Add(new DesignerActionMethodItem(this,
                                               "AddButton",
                                               "Add a Button",
                                               "Add",
                                               String.Empty,
                                               false));
                items.Add(new DesignerActionMethodItem(this,
                                               "AddNewButton",
                                               "Add a custom Button",
                                               "Add",
                                               String.Empty,
                                               false));
                return items;
            }
        }
    }
}

// </Snippet11>