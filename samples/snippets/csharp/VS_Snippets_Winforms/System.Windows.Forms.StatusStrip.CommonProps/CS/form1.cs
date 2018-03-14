// <Snippet0>
using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication4
{
    public class Form1 : Form
    {
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
    
        public Form1()
        {
            InitializeComponent();
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private void InitializeComponent()
        {
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // The following code example demonstrates the syntax for setting
            // various StatusStrip properties.
            // <Snippet1>
            statusStrip1.Dock = System.Windows.Forms.DockStyle.Top;
            statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1});
            statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            statusStrip1.Location = new System.Drawing.Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.ShowItemToolTips = true;
            statusStrip1.Size = new System.Drawing.Size(292, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.Stretch = false;
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // </Snippet1>
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(292, 273);
            Controls.Add(statusStrip1);
            Name = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
// </Snippet0>