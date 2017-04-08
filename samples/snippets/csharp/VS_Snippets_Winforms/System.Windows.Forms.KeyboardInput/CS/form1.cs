
// This sample compiles a set of miscellaneous code snippets that demonstrate
// different levels of user input control.

// <Snippet0>
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KeyboardInput
{
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    class Form1 : Form
    {
        // The following Windows message value is defined in Winuser.h.
        private int WM_KEYDOWN = 0x100;
        CustomTextBox CustomTextBox1 = new CustomTextBox();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
        {
            this.AutoSize = true;
            this.Controls.Add(CustomTextBox1);
            CustomTextBox1.KeyPress +=
                new KeyPressEventHandler(CustomTextBox1_KeyPress);
        }

        // <Snippet5>
        // Consume and modify several character keys.
        void CustomTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                // <Snippet6>
                // Consume 'A' and 'a'.
                case (char)65:
                case (char)97:
                    MessageBox.Show("Control.KeyPress: '" +
                        e.KeyChar.ToString() + "' consumed.");
                    e.Handled = true;
                    break;
                // </Snippet6>

                // <Snippet7>
                // Detect 'B', modify it to 'A', and forward the key.
                case (char)66:
                    MessageBox.Show("Control.KeyPress: '" +
                        e.KeyChar.ToString() + "' replaced by 'A'.");
                    e.KeyChar = (char)65;
                    e.Handled = false;
                    break;

                // Detect 'b', modify it to 'a', and forward the key.
                case (char)98:
                    MessageBox.Show("Control.KeyPress: '" +
                        e.KeyChar.ToString() + "' replaced by 'a'.");
                    e.KeyChar = (char)97;
                    e.Handled = false;
                    break;
                // </Snippet7>
            }
        }
        // </Snippet5>
    }
[System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")]
    public class CustomTextBox : TextBox
    {
        // The following Windows message value is defined in Winuser.h.
        private int WM_KEYDOWN = 0x100;

        public CustomTextBox()
        {
            this.Size = new Size(100, 100);
            this.AutoSize = false;
        }

        // <Snippet10>
        // <Snippet12>
        // Detect F1 through F9 during preprocessing and modify F3.
        public override bool PreProcessMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys keyCode = (Keys)m.WParam & Keys.KeyCode;

                // Detect F1 through F9.
                switch (keyCode)
                {
                    case Keys.F1:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:

                        MessageBox.Show("Control.PreProcessMessage: '" +
                          keyCode.ToString() + "' pressed.");

                        // Replace F3 with F1, so that ProcessKeyMessage will  
                        // receive F1 instead of F3.
                        if (keyCode == Keys.F3)
                        {
                            m.WParam = (IntPtr)Keys.F1;
                            MessageBox.Show("Control.PreProcessMessage: '" +
                                keyCode.ToString() + "' replaced by F1.");
                        }
                        break;
                }
            }

            // Send all other messages to the base method.
            return base.PreProcessMessage(ref m);
        }
        // </Snippet12>

        // Detect F1 through F9 during processing.
        protected override bool ProcessKeyMessage(ref Message m)
        {
            if (m.Msg == WM_KEYDOWN)
            {
                Keys keyCode = (Keys)m.WParam & Keys.KeyCode;

                // Detect F1 through F9.
                switch (keyCode)
                {
                    case Keys.F1:
                    case Keys.F2:
                    case Keys.F3:
                    case Keys.F4:
                    case Keys.F5:
                    case Keys.F6:
                    case Keys.F7:
                    case Keys.F8:
                    case Keys.F9:

                        MessageBox.Show("Control.ProcessKeyMessage: '" +
                          keyCode.ToString() + "' pressed.");
                        break;
                }
            }

            // Send all messages to the base method.
            return base.ProcessKeyMessage(ref m);
        }
        // </Snippet10>
    }
}
// </Snippet0>