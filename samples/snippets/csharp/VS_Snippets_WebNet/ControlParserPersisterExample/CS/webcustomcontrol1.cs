//<Snippet1>
using System;
using System.Drawing;
using System.Drawing.Design;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace ControlParserPersisterDesignerControl_CS
{
    // Web control designer provides an interface 
    //   to use the ControlPersister and ControlParser.
    // The DesignerActionListCollection must run under "FullTrust",
    //   so you must also require your designer to run under "FullTrust".
    [System.Security.Permissions.PermissionSetAttribute(
        System.Security.Permissions.SecurityAction.InheritanceDemand, 
        Name = "FullTrust")]
    [System.Security.Permissions.PermissionSetAttribute(
        System.Security.Permissions.SecurityAction.Demand, 
        Name = "FullTrust")]
    public class ControlParserPersisterDesigner :
        System.Web.UI.Design.ControlDesigner
    {
        private DesignerActionListCollection _actLists = null;

        public ControlParserPersisterDesigner()
            : base()
        {}

        // Creates designer menu commands to persist
        // a control and to load a persisted control.
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (_actLists == null)
                {
                    _actLists = new DesignerActionListCollection();
                    _actLists.AddRange(base.ActionLists);
                    _actLists.Add(new ParserActionList(this));
                }
                return _actLists;
            }
        }

        // A custom class for the DesignerActionList
        private class ParserActionList : DesignerActionList
        {
            private ControlParserPersisterDesigner _parent;
            private DesignerActionItemCollection _items;

            public ParserActionList(ControlParserPersisterDesigner parent) : 
                base(parent.Component)
            {
                _parent = parent;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                if (_items == null)
                {
                    // Create the collection
                    _items = new DesignerActionItemCollection();

                    _items.Add(new DesignerActionMethodItem(this, "saveControl", "Parse and Save Control...", true));
                    _items.Add(new DesignerActionMethodItem(this, "loadPersistedControl", "Load Persisted Control...", true));
                }
                return _items;
            }

            // Displays a list of controls in the project, if any,
            // and displays the HTML markup for the selected control.       
            private void saveControl()
            {
                // Get the collection of components in the current 
                // design mode document.
                ComponentCollection documentComponents =
                    this.Component.Site.Container.Components;

                // Filter the components to those that derive from the 
                // System.Web.UI.Control class.

                // Create an IComponent array of the maximum possible length needed.
                IComponent[] filterArray = new IComponent[documentComponents.Count];

                // Count the total qualifying components.
                int total = 0;
                for (int i = 0; i < documentComponents.Count; i++)
                {
                    // If the component derives from System.Web.UI.Control, 
                    // copy a reference to the control to the filterArray 
                    // array and increment the control count.
                    if (typeof(System.Web.UI.Control).IsAssignableFrom(
                        documentComponents[i].GetType()))
                    {
                        if (((System.Web.UI.Control)documentComponents[i]).UniqueID
                            != null)
                        {
                            filterArray[total] = documentComponents[i];
                            total++;
                        }
                    }
                }

                if (total == 0)
                    throw new Exception(
                        "Document contains no System.Web.UI.Control components.");

                // Move the components that derive from System.Web.UI.Control to a 
                // new array of the correct size.
                System.Web.UI.Control[] controlArray =
                    new System.Web.UI.Control[total];
                for (int i = 0; i < total; i++)
                    controlArray[i] = (System.Web.UI.Control)filterArray[i];

                // Create a ControlSelectionForm to select a control.
                ControlSelectionForm selectionForm =
                    new ControlSelectionForm(controlArray);

                // Display the form.
                if (selectionForm.ShowDialog() != DialogResult.OK)
                    return;

                // Validate the selection.
                if (selectionForm.controlList.SelectedIndex == -1)
                    throw new Exception("You must select a control to persist.");

                //<Snippet3>
                // Parse the selected control into a persistence string.
                string persistedData = ControlPersister.PersistControl(
                    controlArray[selectionForm.controlList.SelectedIndex]);
                //</Snippet3>

                // Display the persistence string in a text box.
                StringDisplayForm displayForm =
                    new StringDisplayForm(persistedData);
                displayForm.ShowDialog();
            }

            // Displays a textbox form to receive an HTML 
            // string that represents a control, and creates
            // a toolbox item for the control, if not already
            // present in the selected toolbox category.
            private void loadPersistedControl()
            {
                // Display a StringInputForm to obtain a persisted control string.
                StringInputForm inputForm = new StringInputForm();

                if (inputForm.ShowDialog() != DialogResult.OK)
                    return;
                if (inputForm.TBox.Text.Length < 2)
                    return;

                // Obtain an IDesignerHost for the design-mode document.
                IDesignerHost host = (IDesignerHost)
                    this.Component.Site.GetService(typeof(IDesignerHost));

                //<Snippet2>
                // Create a Web control from the HTML markup.
                System.Web.UI.Control ctrl =
                    ControlParser.ParseControl(host, inputForm.TBox.Text.Trim());
                //</Snippet2>

                // Create a Web control toolbox item for the type of the control
                System.Web.UI.Design.WebControlToolboxItem item =
                    new System.Web.UI.Design.WebControlToolboxItem(ctrl.GetType());

                // Add the Web control toolbox item to the toolbox
                IToolboxService toolService = (IToolboxService)
                    this.Component.Site.GetService(typeof(IToolboxService));
                if (toolService != null)
                    toolService.AddToolboxItem(item);
                else
                    throw new Exception("IToolboxService was not found.");
            }
        }
    }

    // Simple text display control hosts the ControlParserPersisterDesigner.
    [DesignerAttribute(typeof(ControlParserPersisterDesigner),
         typeof(IDesigner))]
    public class ControlParserPersisterDesignerControl :
        System.Web.UI.WebControls.WebControl
    {
        private string _text;

        [Bindable(true),
            Category("Appearance"),
            DefaultValue("")]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public ControlParserPersisterDesignerControl()
            : base()
        {
            _text = "Right-click here to access control persistence " +
                "methods in design mode";
        }

        protected override void Render(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }

    // Provides a form with a list for selection.
    internal class ControlSelectionForm : Form
    {
        private System.Web.UI.Control[] controlArray;
        public System.Windows.Forms.ListBox controlList;

        public ControlSelectionForm(System.Web.UI.Control[] controlArray)
        {
            this.controlArray = controlArray;

            this.Size = new Size(400, 500);
            this.Text = "Control Selection Form";

            this.SuspendLayout();

            System.Windows.Forms.Label label1 =
                new System.Windows.Forms.Label();
            label1.Text = "Select a control to parse:";
            label1.Size = new Size(240, 20);
            label1.Location = new Point(10, 10);
            this.Controls.Add(label1);

            controlList = new System.Windows.Forms.ListBox();
            controlList.Size = new Size(370, 400);
            controlList.Location = new Point(10, 30);
            controlList.Anchor = AnchorStyles.Left | AnchorStyles.Top |
                AnchorStyles.Bottom | AnchorStyles.Right;
            this.Controls.Add(controlList);

            System.Windows.Forms.Button okButton =
                new System.Windows.Forms.Button();
            okButton.Text = "OK";
            okButton.Size = new Size(80, 24);
            okButton.Location =
                new Point(this.Width - 100, this.Height - 60);
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.OK;
            this.Controls.Add(okButton);

            System.Windows.Forms.Button cancelButton =
                new System.Windows.Forms.Button();
            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(80, 24);
            cancelButton.Location =
                new Point(this.Width - 200, this.Height - 60);
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.DialogResult = DialogResult.Cancel;
            this.Controls.Add(cancelButton);

            for (int i = 0; i < controlArray.Length; i++)
                controlList.Items.Add(controlArray[i].UniqueID);

            this.ResumeLayout();
        }
    }

    // Provides a form with a multiline text box display.
    internal class StringDisplayForm : Form
    {
        private System.Windows.Forms.TextBox tbox = 
            new System.Windows.Forms.TextBox();

        public System.Windows.Forms.TextBox TBox
        {
            get { return tbox; }
            set { tbox = value; }
        }

        public StringDisplayForm(string displayText)
        {
            this.Size = new Size(400, 300);
            this.Text = "Control Persistence String";

            this.SuspendLayout();
            TBox.Multiline = true;
            TBox.Size = new Size(this.Width - 40, this.Height - 90);
            TBox.Text = displayText;
            this.Controls.Add(TBox);

            System.Windows.Forms.Button okButton =
                new System.Windows.Forms.Button();
            okButton.Text = "OK";
            okButton.Size = new Size(80, 24);
            okButton.Location =
                new Point(this.Width - 100, this.Height - 60);
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.OK;
            this.Controls.Add(okButton);

            this.ResumeLayout();
        }
    }

    // Provides a form with a multiline text box for input.
    internal class StringInputForm : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox tbox = 
            new System.Windows.Forms.TextBox();

        public System.Windows.Forms.TextBox TBox
        {
            get { return tbox; }
        }

        public StringInputForm()
        {
            this.Size = new Size(400, 300);
            this.Text = "Input Control Persistence String";

            this.SuspendLayout();
            tbox = new System.Windows.Forms.TextBox();
            tbox.Multiline = true;
            tbox.Size = new Size(this.Width - 40, this.Height - 90);
            tbox.Text = "";
            this.Controls.Add(tbox);

            System.Windows.Forms.Button okButton =
                new System.Windows.Forms.Button();
            okButton.Text = "OK";
            okButton.Size = new Size(80, 24);
            okButton.Location =
                new Point(this.Width - 100, this.Height - 60);
            okButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            okButton.DialogResult = DialogResult.OK;
            this.Controls.Add(okButton);

            System.Windows.Forms.Button cancelButton =
                new System.Windows.Forms.Button();
            cancelButton.Text = "Cancel";
            cancelButton.Size = new Size(80, 24);
            cancelButton.Location =
                new Point(this.Width - 200, this.Height - 60);
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelButton.DialogResult = DialogResult.Cancel;
            this.Controls.Add(cancelButton);

            this.ResumeLayout();
        }
    }
}
//</Snippet1>