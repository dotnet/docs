// <Snippet0>
using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication5
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
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripStatusLabel1});
            statusStrip1.Location = new System.Drawing.Point(0, 248);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(292, 25);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            
            // 
            // <Snippet1>
            // 
            toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            toolStripStatusLabel1.IsLink = true;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(246, 20);
            toolStripStatusLabel1.Spring = true;
            toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            toolStripStatusLabel1.Alignment = ToolStripItemAlignment.Left;
            // </Snippet1>
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