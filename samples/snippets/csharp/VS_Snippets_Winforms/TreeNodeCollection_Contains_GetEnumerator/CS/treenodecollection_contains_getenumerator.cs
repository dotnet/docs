// System.Windows.Forms.TreeNodeCollection.Contains()
// System.Windows.Forms.TreeNodeCollection.GetEnumerator()
/*
   The following program demonstrates 'Contains' and 'GetEnumerator'
   methods of 'System.Windows.Forms.TreeNodeCollection' class. It
   creates a TreeView with two TreeNodes and gets the collection of
   TreeNodes. It checks for a TreeNode in the collection and also
   gets an Enumerator to iterate through the collection.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


public class MyForm : Form
{
   private TreeView myTreeView;
   private TreeNode myTreeNode1;
   private TreeNode myTreeNode2;
   private Label myLabel;
   private Container components = null;

   public MyForm()
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
      this.myTreeView = new TreeView();
      this.myLabel = new Label();
      this.SuspendLayout();
      //
      // myTreeView
      //
      this.myTreeView.ImageIndex = -1;
      this.myTreeView.Name = "treeView1";
      this.myTreeView.SelectedImageIndex = -1;
      this.myTreeView.TabIndex = 0;
      // Create TreeNodes.
      myTreeNode1= new TreeNode("Node1");
      myTreeNode2= new TreeNode("Node2");
      this.myTreeView.Nodes.AddRange(new TreeNode[]
                                             {myTreeNode1,myTreeNode2});
      //
      // myLabel
      //
      this.myLabel.Location = new Point(8, 136);
      this.myLabel.Name = "myLabel";
      this.myLabel.Size = new Size(248, 112);
      this.myLabel.TabIndex = 1;
      //
      // MyForm
      //
      this.ClientSize = new Size(292, 273);
      this.Controls.AddRange(new Control[]
                              { this.myLabel,this.myTreeView});
      this.Name = "MyForm";
      this.Text = "MyForm";
      this.Load += new EventHandler(this.MyForm_Load);
      this.ResumeLayout(false);
   }

   [STAThread]
   static void Main()
   {
      Application.Run(new MyForm());
   }

   private void MyForm_Load(object sender, EventArgs e)
   {
	EnumerateTreeNodes();
   }

// <snippet2>
// <snippet1>
private void EnumerateTreeNodes()
{
   TreeNodeCollection myNodeCollection = myTreeView.Nodes;
   // Check for a node in the collection.
   if (myNodeCollection.Contains(myTreeNode2))
   {
      myLabel.Text += "Node2 is at index: " + myNodeCollection.IndexOf(myTreeNode2);
   }
   myLabel.Text += "\n\nElements of the TreeNodeCollection:\n";

   // Create an enumerator for the collection.
   IEnumerator myEnumerator = myNodeCollection.GetEnumerator();
   while(myEnumerator.MoveNext())
   {
      myLabel.Text += ((TreeNode)myEnumerator.Current).Text +"\n";
   }
}
// </snippet1>
// </snippet2>


}
