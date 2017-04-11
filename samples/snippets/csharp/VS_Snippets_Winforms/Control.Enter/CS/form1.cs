using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ControlEnterEventEx
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // button1
            //
            this.button1.Location = new System.Drawing.Point(176, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.Enter += new System.EventHandler(this.button1_Enter);
            //
            // textBox1
            //
            this.textBox1.Location = new System.Drawing.Point(48, 104);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "textBox1";
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave);
            this.textBox1.Enter += new System.EventHandler(this.textBox1_Enter);
            //
            // Form1
            //
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.textBox1,
                                                                          this.button1});
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

        private void button1_Enter(object sender, System.EventArgs e)
        {

        }

        //<Snippet1>
        private void textBox1_Enter(object sender, System.EventArgs e)
        {
            // If the TextBox contains text, change its foreground and background colors.
            if (textBox1.Text != String.Empty)
            {
                textBox1.ForeColor = Color.Red;
                textBox1.BackColor = Color.Black;
                // Move the selection pointer to the end of the text of the control.
                textBox1.Select(textBox1.Text.Length, 0);
            }
        }

        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            // Reset the colors and selection of the TextBox after focus is lost.
            textBox1.ForeColor = Color.Black;
            textBox1.BackColor = Color.White;
            textBox1.Select(0,0);
        }
        //</Snippet1>


    }
}
