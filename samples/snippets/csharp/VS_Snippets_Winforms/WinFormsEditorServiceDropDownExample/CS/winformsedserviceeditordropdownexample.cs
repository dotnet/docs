//<Snippet1>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IWindowsFormsEditorServiceExample
{	
    // Example UITypeEditor that uses the IWindowsFormsEditorService to 
    // display a drop-down control.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")] 
    public class TestDropDownEditor : System.Drawing.Design.UITypeEditor
    {
        public TestDropDownEditor()
        {
        }
	
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            // Indicates that this editor can display a control-based 
            // drop-down interface.
            return UITypeEditorEditStyle.DropDown;
        }
	
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            // Attempts to obtain an IWindowsFormsEditorService.
            IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if( edSvc == null )
                return value;       
            
            // Displays a drop-down control.
            StringInputControl inputControl = new StringInputControl((string)value, edSvc);
            edSvc.DropDownControl(inputControl);
            return inputControl.inputTextBox.Text;
        }
    }

    // Example control for entering a string.
    internal class StringInputControl : System.Windows.Forms.UserControl
    {
        public System.Windows.Forms.TextBox inputTextBox;
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
        private IWindowsFormsEditorService edSvc;

        public StringInputControl(string text, IWindowsFormsEditorService edSvc)
        {
            InitializeComponent();
            inputTextBox.Text = text;
            // Stores IWindowsFormsEditorService reference to use to 
            // close the control.
            this.edSvc = edSvc;
        }

        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.inputTextBox.Location = new System.Drawing.Point(6, 7);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(336, 20);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Text = "";
            this.ok_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok_button.Location = new System.Drawing.Point(186, 38);
            this.ok_button.Name = "ok_button";
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";
            this.ok_button.Click += new EventHandler(this.CloseControl);
            this.cancel_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;            
            this.cancel_button.Location = new System.Drawing.Point(267, 38);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Cancel";
            this.cancel_button.Click += new EventHandler(this.CloseControl);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.cancel_button,
                                                                          this.ok_button,
                                                                          this.inputTextBox});
            this.Name = "StringInputControl";
            this.Size = new System.Drawing.Size(350, 70);
            this.ResumeLayout(false);
        }

        private void CloseControl(object sender, EventArgs e)
        {
            edSvc.CloseDropDown();
        }
    }
    
    // Provides an example control that displays instructions in design mode,
    // with which the example UITypeEditor is associated.
    public class WinFormsEdServiceDropDownExampleControl : UserControl
    {
        [EditorAttribute(typeof(TestDropDownEditor), typeof(UITypeEditor))]
        public string TestDropDownString
        {
            get
            {
                return localDropDownTestString;
            }
            set
            {       
                localDropDownTestString = value;
            }
        }
        
        private string localDropDownTestString;

        public WinFormsEdServiceDropDownExampleControl()
        {
            localDropDownTestString = "Test String";
            this.Size = new Size(210, 74);
            this.BackColor = Color.Beige;
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if( this.DesignMode )
            {
                e.Graphics.DrawString("Use the Properties window to show", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 5);
                e.Graphics.DrawString("a drop-down control, using the", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 17);
                e.Graphics.DrawString("IWindowsFormsEditorService, for", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 29);
                e.Graphics.DrawString("configuring this control's", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 41);
                e.Graphics.DrawString("TestDropDownString property.", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 53);
            }
            else
            {
                e.Graphics.DrawString("This example requires design mode.", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 5);
            }
        }
    }
}
//</Snippet1>
