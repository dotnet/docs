// <Snippet0>
using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public class Form1 : Form
    {
        private ToolStrip toolStrip1;
        private ToolStripComboBox toolStripComboBox1;
    
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
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripComboBox1});
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(292, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // <Snippet1>
            // The following code example demonstrates the syntax for setting
            // various ToolStripComboBox properties.
            // 
            toolStripComboBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "aaa",
            "bbb",
            "ccc"});
            toolStripComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            toolStripComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            toolStripComboBox1.DropDownHeight = 110;
            toolStripComboBox1.DropDownWidth = 122;
            toolStripComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            toolStripComboBox1.IntegralHeight = false;
            toolStripComboBox1.Items.AddRange(new object[] {
            "xxx",
            "yyy",
            "zzz"});
            toolStripComboBox1.MaxDropDownItems = 9;
            toolStripComboBox1.MergeAction = System.Windows.Forms.MergeAction.Insert;
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            toolStripComboBox1.Sorted = true;
            // </Snippet1>
            // 
            // Form1
            // 
            ClientSize = new System.Drawing.Size(292, 273);
            Controls.Add(toolStrip1);
            Name = "Form1";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
// </Snippet0>