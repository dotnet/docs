// System.Windows.Forms.TreeNode.Expand()
// System.Windows.Forms.TreeNode.Collapse()
// System.Windows.Forms.TreeNode.EnsureVisible()
// System.Windows.Forms.TreeNode.Clone()

/* The following program demonstrates 'Expand', 'Collapse',
   'EnsureVisible' and 'Clone' methods of 'System.Windows.Forms.TreeNode' 
   class. It creates a TreeView, adds 10 TreeNode objects to it and
   expands node1,collapses node1 and makes a clone to Node 9 and add it to Node7. */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyTreeNode
{
   public class Form1 : Form
   {
      private TreeView treeView1;
      private ArrayList myCustomerList = new ArrayList();
      private Button button1;
      private Button button2;
      private Button button3;
      private Button button4;
      private Container components = null;

      public Form1()
      {
         // Required for Windows Form Designer support.
         InitializeComponent();

         AddTreeNode();
      }

      // Clean up any resources being used.
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

      // The main entry point for the application.
      static void Main() 
      {
         Application.Run(new Form1());
      }

      // Required method for Designer support.
      private void InitializeComponent()
      {
         this.treeView1 = new TreeView();
         this.button1   = new Button();
         this.button2   = new Button();
         this.button3   = new Button();
         this.button4   = new Button();
         this.SuspendLayout();

         this.treeView1.ImageIndex = -1;
         this.treeView1.Location   = new Point(32, 48);
         this.treeView1.Name       = "treeView1";
         this.treeView1.SelectedImageIndex = -1;
         this.treeView1.Size       = new Size(168, 96);
         this.treeView1.TabIndex   = 0;

         this.button1.Location = new Point(40, 160);
         this.button1.Name     = "button1";
         this.button1.Size     = new Size(160, 23);
         this.button1.TabIndex = 1;
         this.button1.Text     = "Expand Customer1 Node";
         this.button1.Click   += new System.EventHandler(this.button1_Click);

         this.button2.Location = new Point(40, 185);
         this.button2.Name     = "button2";
         this.button2.Size     = new Size(160, 23);
         this.button2.TabIndex = 2;
         this.button2.Text     = "Collapse Customer1 Node";

         this.button3.Location = new Point(40, 210);
         this.button3.Name     = "button3";
         this.button3.Size     = new Size(160, 23);
         this.button3.TabIndex = 3;
         this.button3.Text     = "EnsureVisible Order7 Node";
         this.button3.Click   += new System.EventHandler(this.button3_Click);

         this.button4.Location = new Point(40, 235);
         this.button4.Name     = "button4";
         this.button4.Size     = new Size(160, 23);
         this.button4.TabIndex = 4;
         this.button4.Text     = "Clone Customer9 Node";
         this.button4.Click   += new System.EventHandler(this.button4_Click);

         this.ClientSize        = new Size(240, 273);
         this.Controls.AddRange(new Control[] {this.button4,
                                               this.button3,
                                               this.button2,
                                               this.button1,
                                               this.treeView1});
         this.Name = "Form1";
         this.Text = "Demonstrating TreeNode members";
         this.ResumeLayout(false);
      }

      // Add TreeNode to the TreeView.
      private void AddTreeNode()
      {
         // Add customers to ArrayList of Customer objects.
         for (int i=1; i < 11; i++)
         {
            myCustomerList.Add(new Customer("Customer" + i.ToString()));
         }

         // Add orders to each Customer object in the ArrayList.
         int x = 1;
         foreach(Customer Customer1 in myCustomerList)
         {
            Customer1.MyOrders.Add(new Order("Order" + x.ToString()));
            x++;
         }

         // Prevent repainting of TreeView until all objects have been created.
         treeView1.BeginUpdate();

         // Clear the TreeView each time the method is called.
         treeView1.Nodes.Clear();

         // Add a root TreeNode for each Customer object in the ArrayList.
         foreach(Customer Customer2 in myCustomerList)
         {
            treeView1.Nodes.Add(new TreeNode(Customer2.myCustomerName));

            // Add a child TreeNode to each Customer TreeNode.
            foreach(Order Order2 in Customer2.MyOrders)
            {
               treeView1.Nodes[myCustomerList.IndexOf(Customer2)].Nodes.Add(
                        new TreeNode(Order2.myOrderName));
            }
         }
      }

// <Snippet1>
private void button1_Click(object sender, System.EventArgs e)
{
   if (treeView1.SelectedNode.IsExpanded)
   {
      treeView1.SelectedNode.Collapse();
      MessageBox.Show(treeView1.SelectedNode.Text + 
        " tree node collapsed.");
   }
   else
   {
      treeView1.SelectedNode.Expand();
      MessageBox.Show(treeView1.SelectedNode.Text + 
        " tree node expanded.");
   }
}
// </Snippet1>

      
// <Snippet2>
private void button3_Click(object sender, System.EventArgs e)
{
   TreeNode lastNode = treeView1.Nodes[treeView1.Nodes.Count - 1].
     Nodes[treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1];

   if (!lastNode.IsVisible)
   {
      lastNode.EnsureVisible();
      MessageBox.Show(lastNode.Text + " tree node is visible.");
   }
}
// </Snippet2>

      
// <Snippet3>
private void button4_Click(object sender, System.EventArgs e)
{
   TreeNode lastNode = treeView1.Nodes[treeView1.Nodes.Count - 1].
     Nodes[treeView1.Nodes[treeView1.Nodes.Count - 1].Nodes.Count - 1];

   // Clone the last child node.
   TreeNode clonedNode = (TreeNode) lastNode.Clone();

   // Insert the cloned node as the first root node.
   treeView1.Nodes.Insert(0, clonedNode);
   MessageBox.Show(lastNode.Text + 
     " tree node cloned and added to " + treeView1.Nodes[0].Text);
}
// </Snippet3>


   }

   // Define a Customer Class.
   public class Customer
   {
      public string myCustomerName;
      public ArrayList MyOrders = new ArrayList();
      public Customer(string name)
      {
         myCustomerName = name;
      }
   }

   // Define an Order Class which will be associated to a customer.
   public class Order
   {
      public string myOrderName;
      public Order(string name1)
      {
         myOrderName = name1;
      }
   }
}