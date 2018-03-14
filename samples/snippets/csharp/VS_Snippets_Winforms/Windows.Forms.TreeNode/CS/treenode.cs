using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Foo
{
	public class Form1 : System.Windows.Forms.Form
	{
      private System.Windows.Forms.TreeView treeView1;
      private System.Windows.Forms.StatusBar statusBar1;

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

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
         this.treeView1 = new System.Windows.Forms.TreeView();
         this.statusBar1 = new System.Windows.Forms.StatusBar();
         this.SuspendLayout();
         // 
         // treeView1
         // 
         this.treeView1.ImageIndex = -1;
         this.treeView1.Location = new System.Drawing.Point(8, 8);
         this.treeView1.Name = "treeView1";
         this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
                                                                              new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                  new System.Windows.Forms.TreeNode("Node4", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                                                                                                    new System.Windows.Forms.TreeNode("Node5")})})}),
                                                                              new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node6", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                  new System.Windows.Forms.TreeNode("Node7", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                                                                                                    new System.Windows.Forms.TreeNode("Node8")})})}),
                                                                              new System.Windows.Forms.TreeNode("Node2", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                new System.Windows.Forms.TreeNode("Node9", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                  new System.Windows.Forms.TreeNode("Node10", new System.Windows.Forms.TreeNode[] {
                                                                                                                                                                                                                                                                                                                                     new System.Windows.Forms.TreeNode("Node11")})})})});
         this.treeView1.SelectedImageIndex = -1;
         this.treeView1.Size = new System.Drawing.Size(128, 144);
         this.treeView1.TabIndex = 0;
         this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
         this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
         this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
         // 
         // statusBar1
         // 
         this.statusBar1.Location = new System.Drawing.Point(0, 247);
         this.statusBar1.Name = "statusBar1";
         this.statusBar1.Size = new System.Drawing.Size(256, 22);
         this.statusBar1.TabIndex = 2;
         this.statusBar1.Text = "statusBar1";
         // 
         // Form1
         // 
         this.ClientSize = new System.Drawing.Size(256, 269);
         this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                      this.statusBar1,
                                                                      this.treeView1});
         this.Name = "Form1";
         this.Text = "Form1";
         this.ResumeLayout(false);

      }
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

// <snippet1>
private void treeView1_MouseDown(object sender, MouseEventArgs e)
{
   switch(e.Button)
   {
      // Remove the TreeNode under the mouse cursor 
      // if the right mouse button was clicked. 
      case MouseButtons.Right:
         treeView1.GetNodeAt(e.X, e.Y).Remove();
         break;
      
      // Toggle the TreeNode under the mouse cursor 
      // if the middle mouse button (mouse wheel) was clicked. 
      case MouseButtons.Middle:
         treeView1.GetNodeAt(e.X, e.Y).Toggle();
         break;
   }
}
// </snippet1>

//<snippet2>
private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
{  
   /* Display the Text and Index of the 
    * selected tree node's Parent. */
   if(e.Node.Parent!= null && 
     e.Node.Parent.GetType() == typeof(TreeNode) )
   {
      statusBar1.Text = "Parent: " + e.Node.Parent.Text + "\n"
         + "Index Position: " + e.Node.Parent.Index.ToString();
   }
   else
   {
      statusBar1.Text = "No parent node.";
   }
}
// </snippet2>

// <snippet3>
private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
{
   // Create a copy of the e.Node from its Handle.
   TreeNode tn = TreeNode.FromHandle(e.Node.TreeView, e.Node.Handle);
   tn.Text += "Copy";
   // Remove the e.Node so it can be replaced with tn.
   e.Node.Remove();
   // Add tn to the TreeNodeCollection.
   treeView1.Nodes.Add(tn);
}
// </snippet3>



      


	}
}
