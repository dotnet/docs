using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ToolBarStuff
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.TreeView treeView2;
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

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
		/// Required method for Designer support; do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.button1 = new System.Windows.Forms.Button();
         this.treeView2 = new System.Windows.Forms.TreeView();
         this.button2 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // treeView1
         // 
         this.treeView1.ImageIndex = -1;
         this.treeView1.Location = new System.Drawing.Point(8, 8);
         this.treeView1.Name = "treeView1";
         this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                              new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node5"),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node6"),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node7")}),
                                                                              new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node8"),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node9"),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node10")}),
                                                                              new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node11"),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node12"),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node13")}),
                                                                              new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node14", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                   new System.Windows.Forms.TreeNode("Node15")}),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node16"),
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node17")}),
                                                                              new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node18", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                   new System.Windows.Forms.TreeNode("Node19", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                                                                                                      new System.Windows.Forms.TreeNode("Node20", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                                                                                                                                                                                         new System.Windows.Forms.TreeNode("Node21")})})})})});
         this.treeView1.SelectedImageIndex = -1;
         this.treeView1.Size = new System.Drawing.Size(128, 224);
         this.treeView1.TabIndex = 0;
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(8, 240);
         this.button1.Name = "button1";
         this.button1.TabIndex = 1;
         this.button1.Text = "Move ->";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // treeView2
         // 
         this.treeView2.ImageIndex = -1;
         this.treeView2.Location = new System.Drawing.Point(144, 8);
         this.treeView2.Name = "treeView2";
         this.treeView2.SelectedImageIndex = -1;
         this.treeView2.Size = new System.Drawing.Size(144, 224);
         this.treeView2.TabIndex = 2;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(192, 240);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(96, 23);
         this.button2.TabIndex = 3;
         this.button2.Text = "Delete [0] Node";
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(292, 273);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.button2,
                                                                      this.treeView2,
                                                                      this.button1,
                                                                      this.treeView1});
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

// <snippet1>
private void button1_Click(object sender, EventArgs e)
{
   // If neither TreeNodeCollection is read-only, move the 
   // selected node from treeView1 to treeView2.
   if(!treeView1.Nodes.IsReadOnly && !treeView2.Nodes.IsReadOnly)
   {
      if(treeView1.SelectedNode != null)
      {
         TreeNode tn = treeView1.SelectedNode;
         treeView1.Nodes.Remove(tn);
         treeView2.Nodes.Insert(treeView2.Nodes.Count, tn);
      }
   }
}
// </snippet1>

// <snippet2>
private void button2_Click(object sender, EventArgs e)
{
   // Delete the first TreeNode in the collection 
   // if the Text property is "Node0." 
   if(this.treeView1.Nodes[0].Text == "Node0")
   {
      this.treeView1.Nodes.RemoveAt(0);
   }
}
// </snippet2>


	}
}
