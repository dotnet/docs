using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication12
{
    public class Form1 : Form
    {
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
    
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // <Snippet1>
            // This is an example of some common ToolStrip property settings.
            // 
            toolStrip1.AllowDrop = false;
            toolStrip1.AllowItemReorder = true;
            toolStrip1.AllowMerge = false;
            toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            toolStrip1.AutoSize = false;
            toolStrip1.CanOverflow = false;
            toolStrip1.Cursor = System.Windows.Forms.Cursors.Cross;
            toolStrip1.DefaultDropDownDirection = System.Windows.Forms.ToolStripDropDownDirection.BelowRight;
            toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            toolStrip1.GripMargin = new System.Windows.Forms.Padding(3);
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripButton1});
            toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Margin = new System.Windows.Forms.Padding(1);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            toolStrip1.ShowItemToolTips = false;
            toolStrip1.Size = new System.Drawing.Size(109, 273);
            toolStrip1.Stretch = true;
            toolStrip1.TabIndex = 0;
            toolStrip1.TabStop = true;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.TextDirection = System.Windows.Forms.ToolStripTextDirection.Vertical90;
            // </Snippet1>
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new System.Drawing.Size(23, 270);
            toolStripButton1.Text = "toolStripButton1";
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(292, 273);
            Controls.Add(toolStrip1);
            Name = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);

        }
    }
}