// System.Windows.Forms.TreeNodeCollection.Count
// System.Windows.Forms.TreeNodeCollection.CopyTo()
/*
   The following program demonstrates 'Count' property and 'CopyTo'
   method of 'System.Windows.Forms.TreeNodeCollection' class. It
   creates a TreeView with two TreeNodes and gets the collection of
   TreeNodes. It copies the collection into an array
   and displays the count of the collection and the elements of the
   array.
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
      // Add TreeNodes.
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
      CopyTreeNodes();
   }

// <Snippet2>
// <Snippet1>
private void CopyTreeNodes()
{
   // Get the collection of TreeNodes.
   TreeNodeCollection myNodeCollection = myTreeView.Nodes;
   int myCount = myNodeCollection.Count;

   myLabel.Text += "Number of nodes in the collection :" + myCount;
   myLabel.Text += "\n\nElements of the Array after Copying from the collection :\n";
   // Create an Object array.
   Object[] myArray = new Object[myCount];
   // Copy the collection into an array.
   myNodeCollection.CopyTo(myArray,0);
   for(int i=0; i<myArray.Length; i++)
   {
      myLabel.Text += ((TreeNode)myArray[i]).Text + "\n";
   }
}
// </Snippet1>
// </Snippet2>
}
