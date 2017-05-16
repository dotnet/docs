// <snippet10>
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomWinControls
{

    public class SimpleForm : System.Windows.Forms.Form
    {
        private FirstControl firstControl1;
    
        private System.ComponentModel.Container components = null;

        public SimpleForm()
        {
            InitializeComponent();
        }

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

        private void InitializeComponent()
        {
            this.firstControl1 = new FirstControl();
            this.SuspendLayout();

            // 
            // firstControl1
            // 
            this.firstControl1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.firstControl1.Location = new System.Drawing.Point(96, 104);
            this.firstControl1.Name = "firstControl1";
            this.firstControl1.Size = new System.Drawing.Size(75, 16);
            this.firstControl1.TabIndex = 0;
            this.firstControl1.Text = "Hello World";
            this.firstControl1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // SimpleForm
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.firstControl1);
            this.Name = "SimpleForm";
            this.Text = "SimpleForm";
            this.ResumeLayout(false);

        }
    
        [STAThread]
        static void Main() 
        {
            Application.Run(new SimpleForm());
        }


    }
}
// </snippet10>