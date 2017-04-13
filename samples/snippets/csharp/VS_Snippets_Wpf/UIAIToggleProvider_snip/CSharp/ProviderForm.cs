using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UIAIToggleProvider_snip
{
    public partial class ProviderForm : Form
    {
        CustomControl customControl;

         /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProviderForm());
        }

       public ProviderForm()
        {
            InitializeComponent();

            // Create an instance of the custom control.
            customControl = new CustomControl(this, new Rectangle(5, 5, 50, 200));
            customControl.Name = "CustomControl";

            // Add it to the form's controls. Among other things, this makes it possible for
            // UIAutomation to discover it, as it will become a child of the application window.
            this.Controls.Add(customControl);

            // Set some properties.
            customControl.Location = new Point(50, 20);
            customControl.TabIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}