// <Snippet0>
using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication2
{
    public class Form1 : Form
    {
        private ToolStrip toolStrip1;
        private ToolStripTextBox toolStripTextBox1;
    
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
            toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripTextBox1});
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(292, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // <Snippet1>
            // This code example demonstrates the syntax for setting
            // various ToolStripTextBox properties.
            // 
            toolStripTextBox1.AcceptsReturn = true;
            toolStripTextBox1.AcceptsTab = true;
            toolStripTextBox1.AutoCompleteCustomSource.AddRange(new string[] {
            "This is line one.",
            "Second line.",
            "Another line."});
            toolStripTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            toolStripTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            toolStripTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            toolStripTextBox1.HideSelection = false;
            toolStripTextBox1.MaxLength = 32000;
            toolStripTextBox1.Name = "toolStripTextBox1";
            toolStripTextBox1.ShortcutsEnabled = false;
            toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            toolStripTextBox1.Text = "STRING1\r\nSTRING2\r\nSTRING3\r\nSTRING4";
            toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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