//<Snippet1>
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
//</Snippet1>

namespace WindowsApplication1
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.IContainer components;
        /// <summary>
        /// Required designer variable.
        /// </summary>

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container ();

            System.Resources.ResourceManager resources = new System.Resources.ResourceManager (typeof(Form1));

            this.imageList1 = new System.Windows.Forms.ImageList (this.components);
            this.button1 = new System.Windows.Forms.Button ();
            this.SuspendLayout ();

// 
// imageList1
// 
            this.imageList1.ImageSize = new System.Drawing.Size (16, 16);
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject ("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName (0, "");
            this.imageList1.Images.SetKeyName (1, "");
            this.imageList1.Images.SetKeyName (2, "");
            this.imageList1.Images.SetKeyName (3, "");

// 
// button1
// 
            this.button1.Location = new System.Drawing.Point (103, 86);
            this.button1.Name = "button1";
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler (this.button1_Click);
//            this.button1.HelpRequested += new System.Windows.Forms.HelpEventHandler (this.button1_HelpRequested);

// 
// Form1
// 
            this.ClientSize = new System.Drawing.Size (365, 342);
            this.Controls.Add (this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout (false);
        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        //<Snippet2>
        // Display a message box with a Help button. Show a custom Help window
        // by handling the HelpRequested event.
        private DialogResult AlertMessageWithCustomHelpWindow ()
        {
            // Handle the HelpRequested event for the following message.
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler (this.Form1_HelpRequested);

            this.Tag = "Message with Help button.";

            // Show a message box with OK and Help buttons.
            DialogResult r = MessageBox.Show ("Message with Help button.", 
                                              "Help Caption", MessageBoxButtons.OK, 
                                              MessageBoxIcon.Question, 
                                              MessageBoxDefaultButton.Button1, 
                                              0, true);

            // Remove the HelpRequested event handler to keep the event
            // from being handled for other message boxes.
            this.HelpRequested -= new System.Windows.Forms.HelpEventHandler (this.Form1_HelpRequested);

            // Return the dialog box result.
            return r;
        }

        private void Form1_HelpRequested (System.Object sender, System.Windows.Forms.HelpEventArgs hlpevent)
        {
            // Create a custom Help window in response to the HelpRequested event.
            Form helpForm = new Form ();

            // Set up the form position, size, and title caption.
            helpForm.StartPosition = FormStartPosition.Manual;
            helpForm.Size = new Size (200, 400);
            helpForm.DesktopLocation = new Point (this.DesktopBounds.X + 
                                                  this.Size.Width, 
                                                  this.DesktopBounds.Top);
            helpForm.Text = "Help Form";

            // Create a label to contain the Help text.
            Label helpLabel = new Label ();

            // Add the label to the form and set its text.
            helpForm.Controls.Add (helpLabel);
            helpLabel.Dock = DockStyle.Fill;

            // Use the sender parameter to identify the context of the Help request.
            // The parameter must be cast to the Control type to get the Tag property.
            Control senderControl = sender as Control;

            helpLabel.Text = "Help information shown in response to user action on the '" + 
                              (string)senderControl.Tag + "' message.";

            // Set the Help form to be owned by the main form. This helps
            // to ensure that the Help form is disposed of.
            this.AddOwnedForm (helpForm);

            // Show the custom Help window.
            helpForm.Show ();

            // Indicate that the HelpRequested event is handled.
            hlpevent.Handled = true;
        }
        //</Snippet2>

        private void button1_Click (System.Object sender, System.EventArgs e)
        {

            DialogResult = AlertMessageWithCustomHelpWindow ();

            //<Snippet3>
            // Display a message box with a help button. 
            // The Help button opens the Mspaint.chm Help file.
            DialogResult r1 = MessageBox.Show ("Message with Help file.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, 
                                               "mspaint.chm");
            //</Snippet3>

            //<Snippet4>
            // Display a message box parented to the main form. 
            // The Help button opens the Mspaint.chm Help file.
            DialogResult r2 = MessageBox.Show (this, "Message with Help file.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, 
                                               "mspaint.chm");
            //</Snippet4>
            
            //<Snippet5>
            // Display a message box. The Help button opens 
            // the Mspaint.chm Help file and shows the Help contents 
            // on the Index tab.
            DialogResult r3 = MessageBox.Show ("Message with Help file and Help navigator.", 
                                               "Help Caption", MessageBoxButtons.OK,
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, "mspaint.chm", 
                                               HelpNavigator.Index);

            //</Snippet5>

            //<Snippet6>
            // Display message box parented to the main form. 
            // The Help button opens the Mspaint.chm Help file
            // and shows the Help contents on the Index tab.
            DialogResult r4 = MessageBox.Show (this, 
                                               "Message with Help file and Help navigator.", 
                                               "Help Caption", MessageBoxButtons.OK,
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, "mspaint.chm", 
                                               HelpNavigator.Index);

            //</Snippet6>

            //<Snippet7>
            // Display a message box. The Help button opens the Mspaint.chm Help file, 
            // shows index with the "ovals" keyword selected, and displays the
            // associated topic.
            DialogResult r5 = MessageBox.Show ("Message with Help file and Help navigator with additional parameter.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, "mspaint.chm", 
                                               HelpNavigator.KeywordIndex, "ovals");

            //</Snippet7>

            //<Snippet8>
            // Display message box parented to the main form. 
            // The Help button opens the Mspaint.chm Help file, 
            // shows index with the "ovals" keyword selected, and displays the
            // associated topic.
            DialogResult r6 = MessageBox.Show (this, 
                                               "Message with Help file and Help navigator with additional parameter.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 
                                               0, "mspaint.chm", 
                                               HelpNavigator.KeywordIndex, "ovals");

            //</Snippet8>
            
            //<Snippet9>
            // Display a message box. The Help button opens the Mspaint.chm Help file, 
            // and the "mspaint.chm::/paint_brush.htm" Help keyword shows the 
            // associated topic.
            DialogResult r7 = MessageBox.Show ("Message with Help file and keyword.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 0, 
                                               "mspaint.chm", 
                                               "mspaint.chm::/paint_brush.htm");
            //</Snippet9>

            //<Snippet10>
            // Display message box parented to the main form. 
            // The Help button opens the Mspaint.chm Help file, 
            // and the "mspaint.chm::/paint_brush.htm" Help keyword shows the 
            // associated topic.
            DialogResult r8 = MessageBox.Show (this, "Message with Help file and keyword.", 
                                               "Help Caption", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Question, 
                                               MessageBoxDefaultButton.Button1, 0, 
                                               "mspaint.chm", 
                                               "mspaint.chm::/paint_brush.htm");
            //</Snippet10>

        }


//        private void button1_HelpRequested (System.Object sender, System.Windows.Forms.HelpEventArgs hlpevent)
//        {
//            MessageBox.Show ("Help requested from button");
//        }

    }
}
