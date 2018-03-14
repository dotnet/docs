using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ControlRemovedEx
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(288, 32);
            this.button1.Name = "button1";
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Click += new System.EventHandler(this.addControl_Click);
            //
            // button2
            //
            this.button2.Location = new System.Drawing.Point(288, 72);
            this.button2.Name = "button2";
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.Click += new System.EventHandler(this.removeControl_Click);
            //
            // Form1
            //
            this.ClientSize = new System.Drawing.Size(376, 334);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.button2,
                                                                          this.button1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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

        //<Snippet1>
        // This example demonstrates the use of the ControlAdded and
        // ControlRemoved events. This example assumes that two Button controls
        // are added to the form and connected to the addControl_Click and
        // removeControl_Click event-handler methods.
        private void Form1_Load(object sender, System.EventArgs e)
        {
            // Connect the ControlRemoved and ControlAdded event handlers
            // to the event-handler methods.
            // ControlRemoved and ControlAdded are not available at design time.
            this.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.Control_Removed);
            this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_Added);
        }

        private void Control_Added(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            MessageBox.Show("The control named " + e.Control.Name + " has been added to the form.");
        }

        private void Control_Removed(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            MessageBox.Show("The control named " + e.Control.Name + " has been removed from the form.");
        }

        // Click event handler for a Button control. Adds a TextBox to the form.
        private void addControl_Click(object sender, System.EventArgs e)
        {
            // Create a new TextBox control and add it to the form.
            TextBox textBox1 = new TextBox();
            textBox1.Size = new Size(100,10);
            textBox1.Location = new Point(10,10);
            // Name the control in order to remove it later. The name must be specified
            // if a control is added at run time.
            textBox1.Name = "textBox1";

            // Add the control to the form's control collection.
            this.Controls.Add(textBox1);
        }

        // Click event handler for a Button control.
        // Removes the previously added TextBox from the form.
        private void removeControl_Click(object sender, System.EventArgs e)
        {
            // Loop through all controls in the form's control collection.
            foreach (Control tempCtrl in this.Controls)
            {
                // Determine whether the control is textBox1,
                // and if it is, remove it.
                if (tempCtrl.Name == "textBox1")
                {
                    this.Controls.Remove(tempCtrl);
                }
            }
        }
        //</Snippet1>
    }
}
