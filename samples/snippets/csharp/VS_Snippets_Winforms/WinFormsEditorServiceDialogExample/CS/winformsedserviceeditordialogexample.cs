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
    // Example UITypeEditor that uses the IWindowsFormsEditorService 
    // to display a Form.
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
    public class TestDialogEditor : UITypeEditor
    {
        public TestDialogEditor()
        {
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // Indicates that this editor can display a Form-based interface.
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(
            ITypeDescriptorContext context, 
            IServiceProvider provider, 
            object value)
        {
            // Attempts to obtain an IWindowsFormsEditorService.
            IWindowsFormsEditorService edSvc = 
                (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (edSvc == null)
            {
                return null;
            }
            
            // Displays a StringInputDialog Form to get a user-adjustable 
            // string value.
            using (StringInputDialog form = new StringInputDialog((string)value))
            {
                if (edSvc.ShowDialog(form) == DialogResult.OK)
                {
                    return form.inputTextBox.Text;
                }
            }

            // If OK was not pressed, return the original value
            return value;
        }        
    }

    // Example Form for entering a string.
    internal class StringInputDialog : Form
    {
        private System.Windows.Forms.Button ok_button;
        private System.Windows.Forms.Button cancel_button;
        public System.Windows.Forms.TextBox inputTextBox;

        public StringInputDialog(string text)
        {
            InitializeComponent();
            inputTextBox.Text = text;
        }

        private void InitializeComponent()
        {
            this.ok_button = new System.Windows.Forms.Button();
            this.cancel_button = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            this.ok_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.ok_button.Location = new System.Drawing.Point(180, 43);
            this.ok_button.Name = "ok_button";
            this.ok_button.TabIndex = 1;
            this.ok_button.Text = "OK";      
            this.ok_button.DialogResult = System.Windows.Forms.DialogResult.OK;            
            this.cancel_button.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.cancel_button.Location = new System.Drawing.Point(260, 43);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.TabIndex = 2;
            this.cancel_button.Text = "Cancel";            
            this.cancel_button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.inputTextBox.Location = new System.Drawing.Point(6, 9);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(327, 20);
            this.inputTextBox.TabIndex = 0;
            this.inputTextBox.Text = "";            
            this.inputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.ClientSize = new System.Drawing.Size(342, 73);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.inputTextBox,
                                                                          this.cancel_button,
                                                                          this.ok_button});
            this.MinimumSize = new System.Drawing.Size(350, 100);
            this.Name = "StringInputDialog";
            this.Text = "String Input Dialog";
            this.ResumeLayout(false);
        }
    }

    // Provides an example control that displays instructions in design mode,
    // with which the example UITypeEditor is associated.
    public class WinFormsEdServiceDialogExampleControl : UserControl
    {
        [EditorAttribute(typeof(TestDialogEditor), typeof(UITypeEditor))]
        public string TestDialogString
        {
            get
            {
                return localDialogTestString;
            }
            set
            {
                localDialogTestString = value;
            }
        }
        private string localDialogTestString;
      
        public WinFormsEdServiceDialogExampleControl()
        {
            localDialogTestString = "Test String"; 
            this.Size = new Size(210, 74);
            this.BackColor = Color.Beige;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if( this.DesignMode )
            {
                e.Graphics.DrawString("Use the Properties window to show", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 5);
                e.Graphics.DrawString("a Form dialog box, using the", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 17);
                e.Graphics.DrawString("IWindowsFormsEditorService, for", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 29);
                e.Graphics.DrawString("configuring this control's", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 41);
                e.Graphics.DrawString("TestDialogString property.", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 53);
            }
            else
            {
                e.Graphics.DrawString("This example requires design mode.", new Font("Arial", 8), new SolidBrush(Color.Black), 5, 5);
            }
        }
    }
}
//</Snippet1>