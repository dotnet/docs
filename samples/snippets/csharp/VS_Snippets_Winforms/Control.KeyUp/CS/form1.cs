using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ControlKeyUpEx
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox textBox1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // textBox1
            //
            this.textBox1.Location = new System.Drawing.Point(120, 80);
            this.textBox1.Name = "textBox1";
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "";
            this.textBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseUp);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            //
            // Form1
            //
            this.ClientSize = new System.Drawing.Size(464, 326);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.textBox1});
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

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

        private void textBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {

        }

        //<Snippet1>
        // This example demonstrates how to use the KeyUp event with the Help class to display
        // pop-up style help to the user of the application. When the user presses F1, the Help
        // class displays a pop-up window, similar to a ToolTip, near the control. This example assumes
        // that a TextBox control, named textBox1, has been added to the form and its KeyUp
        // event has been contected to this event handler method.
        private void textBox1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            // Determine whether the key entered is the F1 key. Display help if it is.
            if(e.KeyCode == Keys.F1)
            {
                // Display a pop-up help topic to assist the user.
                Help.ShowPopup(textBox1, "Enter your first name", new Point(textBox1.Right, this.textBox1.Bottom));
            }
        }
        //</Snippet1>
    }
}
