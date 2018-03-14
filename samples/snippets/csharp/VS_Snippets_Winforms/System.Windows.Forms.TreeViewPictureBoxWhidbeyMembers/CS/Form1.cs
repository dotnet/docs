using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TreeViewHitTest
{
    public class Form1 : Form
    {
        private PictureBox pictureBox1;
        private Button startButton;
        private ProgressBar progressBar1;
        private Button cancelButton;
        private TreeView treeView1;

        public Form1()
        {
            InitializeComponent();
            this.MouseDown += new MouseEventHandler(HandleMouseDown);
            cancelButton.Click += new EventHandler(startButton_Click);
            treeView1.MouseDown += new MouseEventHandler(HandleMouseDown);
            pictureBox1.LoadProgressChanged += new ProgressChangedEventHandler(pictureBox1_LoadProgressChanged);

        }
 //Demonstrates the TreeViewHitTest method, TreeViewHitTestInfo and TreeViewHitTestLocations    
//<snippet1>
        void HandleMouseDown(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo info = treeView1.HitTest(e.X, e.Y);
            if (info != null)
                MessageBox.Show("Hit the " + info.Location.ToString());
        }
 //</snippet1>


        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(112, 87);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "Node2";
            treeNode5.Text = "Node2";
            treeNode6.Name = "Node0";
            treeNode6.Text = "Node0";
            treeNode7.Name = "Node3";
            treeNode7.Text = "Node3";
            treeNode8.Name = "Node1";
            treeNode8.Text = "Node1";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode8});
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(112, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(21, 12);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "button1";
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 55);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(21, 101);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "button2";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.treeView1);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        //<snippet4>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            pictureBox1.CancelAsync();
        }
        //</snippet4> 
        //<snippet3>
        private void startButton_Click(object sender, EventArgs e)
        {
            // Ensure WaitOnLoad is false.
            pictureBox1.WaitOnLoad = false;

            // Load the image asynchronously.
            pictureBox1.LoadAsync(@"http://localhost/print.gif");
        }
        //</snippet3>

      //<snippet5>
        void pictureBox1_LoadProgressChanged(object sender, 
            ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        //</snippet5>

    }
}
