//<Snippet1>
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
//</Snippet1>

namespace csOSFeature.IsPresent.Snippet
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1 ()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent ();
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose (bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose ();
                }
            }

            base.Dispose (disposing);
        }

		#region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            // 
// Form1
// 
            this.ClientSize = new System.Drawing.Size (292, 273);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler (this.Form1_Load);
        }
		#endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.Run (new Form1 ());
        }

        private void Form1_Load (object sender, System.EventArgs e)
        {
        }

//<Snippet2>
        // Gets the caret width based upon the operating system or default value.
        private int GetCaretWidth ()
        {    

            // Check to see if the operating system supports the caret width metric. 
            if (OSFeature.IsPresent(SystemParameter.CaretWidthMetric))
            {

                // If the operating system supports this metric,
                // return the value for the caret width metric. 

                return SystemInformation.CaretWidth;
            } else

                // If the operating system does not support this metric,
                // return a custom default value for the caret width.

                return 1;
        }
//</Snippet2>
    }
}
