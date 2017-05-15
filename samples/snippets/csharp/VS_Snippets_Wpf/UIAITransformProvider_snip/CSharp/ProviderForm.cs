using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Automation;

namespace UIAITransformProvider_snip
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
            customControl = new CustomControl();
            customControl.Name = "CustomControl";

            // Add it to the form's controls. Among other things, this makes it possible for
            // UIAutomation to discover it, as it will become a child of the application window.
            this.Controls.Add(customControl);

            // Set some properties.
            customControl.Location = new Point(50, 20);
            customControl.TabIndex = 0;
        }

        /// <summary>
        /// Handles Exit button clicks.
        /// </summary>
        /// <param name="sender">Object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
        }
    }
}