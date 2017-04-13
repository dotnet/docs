//<Snippet1>
using System;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Collections;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace ASPNet.Samples
{
    // Create a custom control class with a Label and TextBox
    [System.Security.Permissions.PermissionSetAttribute(
        System.Security.Permissions.SecurityAction.InheritanceDemand,
        Name = "FullTrust")]
    [System.Security.Permissions.PermissionSetAttribute(
        System.Security.Permissions.SecurityAction.Demand,
        Name = "FullTrust")]
    [DesignerAttribute(typeof(SampleControlDesigner))]
    public class SampleControl : CompositeControl
    {
        int defaultWidth = 150;

        public SampleControl()
        {
        }

        // Create a set of public properties
        [Browsable(true), Bindable(true), DefaultValue(""),
            PersistenceMode(PersistenceMode.Attribute)]
        public string LabelText
        {
            get
            {
                EnsureChildControls();
                return MyLabel.Text;
            }
            set
            {
                EnsureChildControls();
                MyLabel.Text = value;
            }
        }

        [Browsable(true), Bindable(true), DefaultValue(""),
            PersistenceMode(PersistenceMode.Attribute)]
        public string BoxText
        {
            get
            { 
                EnsureChildControls();
                return MyTextBox.Text;
            }
            set
            {
                EnsureChildControls();
                MyTextBox.Text = value;
            }
        }

        [Browsable(true), Bindable(true), Category("Appearance"),
            PersistenceMode(PersistenceMode.Attribute)]
        public Unit BoxWidth
        {
            get
            {
                EnsureChildControls();
                return MyTextBox.Width;
            }
            set
            {
                EnsureChildControls();
                MyTextBox.Width = value;
            }
        }

        [Browsable(true), Bindable(true), Category("Appearance"),
            PersistenceMode(PersistenceMode.Attribute)]
        public override Color BackColor
        {
            get
            {
                EnsureChildControls();
                return MyTextBox.BackColor;
           }
            set
            {
                EnsureChildControls();
                MyTextBox.BackColor = value;
            }
        }

        // Create private properties
        private TextBox MyTextBox
        {
            get
            {
                EnsureChildControls();
                return (TextBox)FindControl("MyTextBox");
            }
        }
        private Label MyLabel
        {
            get
            {
                EnsureChildControls();
                return (Label)FindControl("MyLabel");
            }
        }

        // Create a label and a text box.
        protected override void CreateChildControls()
        {
            // Clear the controls
            Controls.Clear();

            // Create a Label control
            Label localLabel = new Label();
            localLabel.EnableViewState = false;
            localLabel.ID = "MyLabel";
            localLabel.Text = localLabel.ID + ": ";
            Controls.Add(localLabel);

            // Create a TextBox control
            TextBox localTextBox = new TextBox();
            localTextBox.ID = "MyTextBox";
            localTextBox.Width = defaultWidth;
            Controls.Add(localTextBox);
        }
    }


    // Create a designer class for the SampleControl
    [System.Security.Permissions.SecurityPermission(
        System.Security.Permissions.SecurityAction.Demand, 
        Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
    public class SampleControlDesigner : ControlDesigner
    {
        // Constructor
        public SampleControlDesigner() : base()
        {
        }

        // Do not allow resizing; force use of properties to set width
        public override bool AllowResize
        {
            get { return false; }
        }

        //<Snippet2>
        // Create a custom ActionLists collection
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create the collection
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                // Get the base items, if any
                actionLists.AddRange(base.ActionLists);

                // Add a custom list of actions
                actionLists.Add(new CustomControlActionList(this));

                return actionLists;
            }
        }
        //</Snippet2>

        // Create an embedded DesignerActionList class
        private class CustomControlActionList : DesignerActionList
        {
            // Create private fields
            private SampleControlDesigner _parent;
            private DesignerActionItemCollection items;

            // Constructor
            public CustomControlActionList(SampleControlDesigner parent)
                : base(parent.Component)
            {
                _parent = parent;
            }

            // Create a set of transacted callback methods
            // Callback for the wide format
            public void FormatWide()
            {
                SampleControl ctrl = (SampleControl)_parent.Component;
                
                // Create the callback
                TransactedChangeCallback toCall = new TransactedChangeCallback(DoFormat);
                // Create the transacted change in the control
                ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatWide", "Use a wide format");
            }

            // Callback for the medium format
            public void FormatMedium()
            {
                SampleControl ctrl = (SampleControl)_parent.Component;
                
                // Create the callback
                TransactedChangeCallback toCall = new TransactedChangeCallback(DoFormat);
                // Create the transacted change in the control
                ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatMedium", "Use a medium format");
            }

            // Callback for the narrow format
            public void FormatNarrow()
            {
                SampleControl ctrl = (SampleControl)_parent.Component;
                
                // Create the callback
                TransactedChangeCallback toCall = new TransactedChangeCallback(DoFormat);
                // Create the transacted change in the control
                ControlDesigner.InvokeTransactedChange(ctrl, toCall, "FormatNarrow", "Use a narrow format");
            }

            //<Snippet3>
            // Get the sorted list of Action items
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                if (items == null)
                {
                    // Create the collection
                    items = new DesignerActionItemCollection();

                    // Add a header to the list
                    items.Add(new DesignerActionHeaderItem("Select a Style:"));

                    // Add three commands
                    items.Add(new DesignerActionMethodItem(this, "FormatWide", "Format Wide", true));
                    items.Add(new DesignerActionMethodItem(this, "FormatMedium", "Format Medium", true));
                    items.Add(new DesignerActionMethodItem(this, "FormatNarrow", "Format Narrow", true));
                }
                return items;
            }
            //</Snippet3>

            // Function for the callbacks to call
            public bool DoFormat(object arg)
            {
                // Get a reference to the designer's associated component
                SampleControl ctl = (SampleControl)_parent.Component;

                // Get the format name from the arg
                string fmt = (string)arg;

                // Create property descriptors
                PropertyDescriptor widthProp = TypeDescriptor.GetProperties(ctl)["BoxWidth"];
                PropertyDescriptor backColorProp = TypeDescriptor.GetProperties(ctl)["BackColor"];

                // For the selected format, set two properties
                switch (fmt)
                {
                    case "FormatWide":
                        widthProp.SetValue(ctl, Unit.Pixel(250));
                        backColorProp.SetValue(ctl, Color.LightBlue);
                        break;
                    case "FormatNarrow":
                        widthProp.SetValue(ctl, Unit.Pixel(100));
                        backColorProp.SetValue(ctl, Color.LightCoral);
                        break;
                    case "FormatMedium":
                        widthProp.SetValue(ctl, Unit.Pixel(150));
                        backColorProp.SetValue(ctl, Color.White);
                        break;
                }
                _parent.UpdateDesignTimeHtml();

                // Return an indication of success
                return true;
            }
        }
    }
}
//</Snippet1>