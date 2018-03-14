// System.Windows.Forms.TreeNodeCollection.Clear
// System.Windows.Forms.TreeNodeCollection.AddRange

/*
   The following program demonstrates the 'Clear' and 'AddRange' methods of 
   the 'TreeNodeCollection' class. It creates two 'TreeView' objects, the first 
   object contains the customer list and the second object is empty. The user
   is provided with the option to add or remove a 'TreeNode'.
    
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class myTreeNodeCollectionForm : Form
{
   private Button myButtonAddAll;
   private Button myButtonAdd;
   private TreeView myTreeViewBase;
   private TreeView myTreeViewCustom;
   private Button myButtonRemoveAll;
   public myTreeNodeCollectionForm()
   {
      InitializeComponent();
      FillMyTreeView();
      myButtonAddAll.Click += new EventHandler(MyButtonAddAllClick);
      myButtonAdd.Click += new EventHandler(MyButtonAddClick);
      myButtonRemoveAll.Click += new EventHandler(MyButtonRemoveAllClick);
   }
// <Snippet2>
// <Snippet1>
private void MyButtonAddAllClick(object sender, EventArgs e)
{
   // Get the 'myTreeNodeCollection' from the 'myTreeViewBase' TreeView.
   TreeNodeCollection myTreeNodeCollection = myTreeViewBase.Nodes;
   // Create an array of 'TreeNodes'.
   TreeNode[] myTreeNodeArray = new TreeNode[myTreeViewBase.Nodes.Count];
   // Copy the tree nodes to the 'myTreeNodeArray' array.
   myTreeViewBase.Nodes.CopyTo(myTreeNodeArray,0);
   // Remove all the tree nodes from the 'myTreeViewBase' TreeView.
   myTreeViewBase.Nodes.Clear();
   // Add the 'myTreeNodeArray' to the 'myTreeViewCustom' TreeView.
   myTreeViewCustom.Nodes.AddRange(myTreeNodeArray);
}
// </Snippet1>
// </Snippet2>


   private void MyButtonRemoveAllClick(object sender, EventArgs e)
   {
      // Get the 'myTreeNodeCollection' from the 'myTreeViewCustom' TreeView.
      TreeNodeCollection myTreeNodeCollection = myTreeViewCustom.Nodes;
      // Create an array of 'TreeNodes'.
      TreeNode[] myTreeNodeArray = new TreeNode[myTreeViewCustom.Nodes.Count];
      // Copy the tree nodes to the 'myTreeNodeArray' array.
      myTreeViewCustom.Nodes.CopyTo(myTreeNodeArray,0);
      // Remove all the tree nodes from the 'myTreeViewCustom' TreeView.
      myTreeViewCustom.Nodes.Clear();
      // Add the 'myTreeNodeArray' to the 'myTreeViewBase' TreeView.
      myTreeViewBase.Nodes.AddRange(myTreeNodeArray);
   }
   private void MyButtonAddClick(object sender, EventArgs e)
   {
      TreeNodeCollection myTreeNodeCollection = myTreeViewBase.Nodes;
      foreach(TreeNode myTreeNode in myTreeNodeCollection)
      {
         if (myTreeNode.IsSelected == true)
         {
            // Remove the selected node from the 'myTreeViewBase' TreeView.
            myTreeViewBase.Nodes.Remove(myTreeNode);
            // Add the selected node to the 'myTreeViewCustom' TreeView.
            myTreeViewCustom.Nodes.Add(myTreeNode);
         }
      }
   }
   private void FillMyTreeView()
   {
      ArrayList customerArray = new ArrayList(); 
      // Add customers to the ArrayList of 'MyCustomerClass' objects.
      for(int x=1; x<=10; x++)
      {
         customerArray.Add(new MyCustomerClass("Customer" + x.ToString()));
      }

      // Add orders to each 'MyCustomerClass' object in the ArrayList.
      foreach(MyCustomerClass myCustomerClass1 in customerArray)
      {
         for(int y=1; y<=5; y++)
         {
            myCustomerClass1.CustomerOrders.Add(
               new MyOrder("Order" + y.ToString()));
         }
      }
        
      // Supress repainting until all the objects have been created.
      myTreeViewBase.BeginUpdate();

      // Clear the 'TreeView' each time the method is called.
      myTreeViewBase.Nodes.Clear();
      TreeNodeCollection myTreeNodeCollectionCustomer = myTreeViewBase.Nodes;
      // Add a root treenode for each 'MyCustomerClass' object in the ArrayList.
      foreach(MyCustomerClass myCustomerClass2 in customerArray)
      {
         myTreeNodeCollectionCustomer.Add(
            new TreeNode(myCustomerClass2.CustomerName));
         TreeNodeCollection myTreeNodeCollectionOrders =  
            myTreeNodeCollectionCustomer
            [customerArray.IndexOf(myCustomerClass2)].Nodes;
         // Add a child treenode for each 'MyOrder' object.
         foreach(MyOrder myOrder1 in myCustomerClass2.CustomerOrders)
         {
            myTreeNodeCollectionOrders.Add(new TreeNode(myOrder1.OrderID));
            TreeNode myTreeNodeOrder = myTreeNodeCollectionOrders
               [myCustomerClass2.CustomerOrders.IndexOf(myOrder1)];
         }
      }
      myTreeViewBase.SelectedImageIndex = 0;
      // Begin repainting the 'TreeView'.
      myTreeViewBase.EndUpdate();
   }
   private void InitializeComponent()
   {
      this.myTreeViewBase = new TreeView();
      this.myButtonAddAll = new Button();
      this.myButtonAdd = new Button();
      this.myTreeViewCustom = new TreeView();
      this.myButtonRemoveAll = new Button();
      this.SuspendLayout();
      this.myTreeViewBase.ImageIndex = -1;
      this.myTreeViewBase.Location = new Point(64, 16);
      this.myTreeViewBase.Name = "myTreeViewBase";
      this.myTreeViewBase.SelectedImageIndex = -1;
      this.myTreeViewBase.Size = new Size(160, 192);
      this.myTreeViewBase.TabIndex = 0;
      this.myButtonAddAll.Location = new Point(248, 112);
      this.myButtonAddAll.Name = "myButtonAddAll";
      this.myButtonAddAll.Size = new Size(96, 23);
      this.myButtonAddAll.TabIndex = 2;
      this.myButtonAddAll.Text = "Add   >>";
      this.myButtonAdd.Location = new Point(248, 48);
      this.myButtonAdd.Name = "myButtonAdd";
      this.myButtonAdd.Size = new Size(96, 23);
      this.myButtonAdd.TabIndex = 3;
      this.myButtonAdd.Text = "Add     >";
      this.myTreeViewCustom.ImageIndex = -1;
      this.myTreeViewCustom.Location = new Point(376, 16);
      this.myTreeViewCustom.Name = "myTreeViewCustom";
      this.myTreeViewCustom.SelectedImageIndex = -1;
      this.myTreeViewCustom.Size = new Size(168, 192);
      this.myTreeViewCustom.TabIndex = 1;
      this.myButtonRemoveAll.Location = new Point(248, 176);
      this.myButtonRemoveAll.Name = "myButtonRemoveAll";
      this.myButtonRemoveAll.Size = new Size(96, 23);
      this.myButtonRemoveAll.TabIndex = 4;
      this.myButtonRemoveAll.Text = "<<   Remove ";
      this.ClientSize = new Size(616, 273);
      this.Controls.Add(this.myButtonRemoveAll);
      this.Controls.Add(this.myButtonAdd);
      this.Controls.Add(this.myButtonAddAll);
      this.Controls.Add(this.myTreeViewCustom);
      this.Controls.Add(this.myTreeViewBase);
      this.Name = "myTreeNodeCollectionForm";
      this.Text = "TreeNodeCollection class Sample";
      this.ResumeLayout(false);
   }
   static void Main() 
   {
      Application.Run(new myTreeNodeCollectionForm());
   }
}
public class MyCustomerClass
{
   public ArrayList CustomerOrders;
   public string CustomerName;
   public MyCustomerClass(string name)
   {
      CustomerName = name;
      CustomerOrders = new ArrayList(); 
   }
}
public class MyOrder
{
   public string OrderID;
   public MyOrder(string orderID )
   {
      this.OrderID = orderID;
   }
}
