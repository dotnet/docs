using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ISelectionServiceExample
{
    public class Form1 : System.Windows.Forms.Form
    {
        private ISelectionServiceExample.ComponentClass componentClass1;

        private System.ComponentModel.Container components = null;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        // Required method for Designer support - do not modify
        // the contents of this method with the code editor.
        private void InitializeComponent()
        {
            this.componentClass1 = new ISelectionServiceExample.ComponentClass();
            this.SuspendLayout();
 
            // componentClass1
            this.componentClass1.Location = new System.Drawing.Point(80, 32);
            this.componentClass1.Name = "componentClass1";
            this.componentClass1.Size = new System.Drawing.Size(608, 296);
            this.componentClass1.TabIndex = 0;
            this.componentClass1.Load += new System.EventHandler(this.componentClass1_Load);
 
            // Form1
            this.ClientSize = new System.Drawing.Size(480, 285);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
			                    this.componentClass1});
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }
        #endregion

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        // The main entry point for the application.
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        private void componentClass1_Load(object sender, System.EventArgs e)
        {
        }
    }
}
