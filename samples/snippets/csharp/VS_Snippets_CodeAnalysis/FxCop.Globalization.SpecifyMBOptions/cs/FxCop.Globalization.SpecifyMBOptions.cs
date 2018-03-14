//<Snippet1>
using System;
using System.Globalization;
using System.Resources;
using System.Windows.Forms;

namespace GlobalizationLibrary
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            SomeForm myForm = new SomeForm();
            // Uncomment the following line to test the right-to-left feature.
            //myForm.RightToLeft = RightToLeft.Yes;
            Application.Run(myForm);
        }
    }

    public class SomeForm : Form
    {
        private ResourceManager _Resources;
        private Button _Button;
        public SomeForm()
        {
            _Resources = new ResourceManager(typeof(SomeForm));
            _Button = new Button();
            _Button.Click += new EventHandler(Button_Click);
            Controls.Add(_Button);
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Switch the commenting on the following 4 lines to test the form.
            // string text = "Text";
            // string caption = "Caption";
            string text = _Resources.GetString("messageBox.Text");
            string caption = _Resources.GetString("messageBox.Caption");
            RtlAwareMessageBox.Show((Control)sender, text, caption,
            MessageBoxButtons.OK, MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1, (MessageBoxOptions)0);
        }
    }

    public static class RtlAwareMessageBox
    {
        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaultButton, MessageBoxOptions options)
        {
            if (IsRightToLeft(owner))
            {
                options |= MessageBoxOptions.RtlReading |
                MessageBoxOptions.RightAlign;
            }

            return MessageBox.Show(owner, text, caption,
            buttons, icon, defaultButton, options);
        }

        private static bool IsRightToLeft(IWin32Window owner)
        {
            Control control = owner as Control;
            
            if (control != null)
            {
                return control.RightToLeft == RightToLeft.Yes;
            }

            // If no parent control is available, ask the CurrentUICulture
            // if we are running under right-to-left.
            return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
        }
    }
}
//</Snippet1>
