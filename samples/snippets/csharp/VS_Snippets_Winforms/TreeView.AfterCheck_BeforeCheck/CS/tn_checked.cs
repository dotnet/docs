using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TN_Checked
{
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.Button button1;
      private System.ComponentModel.Container components = null;


      public Form1()
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
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.button1 = new System.Windows.Forms.Button();

         this.SuspendLayout();
         // 
         // treeView1
         // 
         this.treeView1.CheckBoxes = true;
         this.treeView1.ImageIndex = -1;
         this.treeView1.Location = new System.Drawing.Point(8, 8);
         this.treeView1.Name = "treeView1";
         this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
            new System.Windows.Forms.TreeNode("Node3")}),new System.Windows.Forms.TreeNode("Node5")})})});

         this.treeView1.SelectedImageIndex = -1;
         this.treeView1.TabIndex = 0;
         this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.node_AfterCheck);
         this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(24, 128);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(72, 24);
         this.button1.TabIndex = 1;
         this.button1.Text = "button1";
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(200, 229);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {this.button1, this.treeView1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }


		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

//<snippet1>
// Updates all child tree nodes recursively.
private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
{
   foreach(TreeNode node in treeNode.Nodes)
   {
      node.Checked = nodeChecked;
      if(node.Nodes.Count > 0)
      {
         // If the current node has child nodes, call the CheckAllChildsNodes method recursively.
         this.CheckAllChildNodes(node, nodeChecked);
      }
   }
}

// NOTE   This code can be added to the BeforeCheck event handler instead of the AfterCheck event.
// After a tree node's Checked property is changed, all its child nodes are updated to the same value.
private void node_AfterCheck(object sender, TreeViewEventArgs e)
{
   // The code only executes if the user caused the checked state to change.
   if(e.Action != TreeViewAction.Unknown)
   {
      if(e.Node.Nodes.Count > 0)
      {
         /* Calls the CheckAllChildNodes method, passing in the current 
         Checked value of the TreeNode whose checked state changed. */
         this.CheckAllChildNodes(e.Node, e.Node.Checked);
      }
   }
}
//</snippet1>


      private void button1_Click(object sender, System.EventArgs e)
      {
         this.treeView1.Nodes[0].Nodes[0].Checked = true;
      }

      private void treeView1_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
      {
         MessageBox.Show( e.Node.ToString() + "\n" + e.Action.ToString(),"BeforeCheck");
      }

   }
}
