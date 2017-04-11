
// <Snippet0>
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace SimulateKeyPress
{
    class Form1 : Form
    {
        private Button button1 = new Button();

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        public Form1()
        {
            button1.Location = new Point(10, 10);
            button1.TabIndex = 0;
            button1.Text = "Click to automate Calculator";
            button1.AutoSize = true;
            button1.Click += new EventHandler(button1_Click);

            this.DoubleClick += new EventHandler(Form1_DoubleClick);
            this.Controls.Add(button1);
        }

        // <Snippet5>
        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName,
            string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        // Send a series of key presses to the Calculator application.
        private void button1_Click(object sender, EventArgs e)
        {
            // Get a handle to the Calculator application. The window class
            // and window name were obtained using the Spy++ tool.
            IntPtr calculatorHandle = FindWindow("CalcFrame","Calculator");

            // Verify that Calculator is a running process.
            if (calculatorHandle == IntPtr.Zero)
            {
                MessageBox.Show("Calculator is not running.");
                return;
            }

            // Make Calculator the foreground application and send it 
            // a set of calculations.
            SetForegroundWindow(calculatorHandle);
            SendKeys.SendWait("111");
            SendKeys.SendWait("*");
            SendKeys.SendWait("11");
            SendKeys.SendWait("=");
        }
        // </Snippet5>

        // <Snippet10>
        // Send a key to the button when the user double-clicks anywhere 
        // on the form.
        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            // Send the enter key to the button, which raises the click 
            // event for the button. This works because the tab stop of 
            // the button is 0.
            SendKeys.Send("{ENTER}");
        }
        // </Snippet10>
    }
}
// </Snippet0>