// System.Windows.Forms.TreeNode.Checked
// System.Windows.Forms.TreeNode.BackColor
/*
   The following example demonstrates the properties 'Checked' and
   'BackColor' of the 'TreeNode' class. This example displays customer
   information in a 'TreeView' control. The root tree nodes display 
   customer names, and the child tree nodes display the order numbers 
   assigned to each customer. It also displays selected nodes in a
   messagebox.
*/
using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;

public class Customer
{
   public ArrayList CustomerOrders;
   public string CustomerName;
   public Customer(string myName)
   {
      CustomerName = myName;
      CustomerOrders = new ArrayList(); 
   }
}
public class Order
{
   public string OrderID;
   public Order(string myOrderID )
   {
      this.OrderID = myOrderID;
   }
}
public class TreeNode_Bounds : Form
{
   private TreeView myTreeView;
   private Button myButton;
   public TreeNode_Bounds()
   {
      InitializeComponent();
      FillMyTreeView();
   }
   // ArrayList object to hold the Customer objects.
   private ArrayList customerArray = new ArrayList();
   private TreeNode rootNode;

   private void FillMyTreeView()
   {
      // Add customers to the ArrayList of 'Customer' objects.
      for(int x=1; x<=5; x++)
      {
         customerArray.Add(new Customer("Customer" + x.ToString()));
      }

      // Add orders to each 'Customer' object in the ArrayList.
      foreach(Customer customer1 in customerArray)
      {
         for(int y=1; y<=5; y++)
         {
            customer1.CustomerOrders.Add(new Order("Order" + y.ToString()));    
         }
      }
      // Supress repainting of the TreeView.
      myTreeView.BeginUpdate();

      // Clear the TreeView each time the method is called.
      myTreeView.Nodes.Clear();
      rootNode = new TreeNode();
      rootNode.Text = "CustomerList";

      // Add a main root treenode.
      myTreeView.Nodes.Add(rootNode);
      myTreeView.CheckBoxes = true;

      // Add a root treenode for each 'Customer' object in the ArrayList.
      foreach(Customer myCustomer in customerArray)
      {
         // Add a child treenode for each 'Order' object.
         int countIndex=0;
         TreeNode[] myTreeNodeArray = new TreeNode[5];
         foreach(Order myOrder in myCustomer.CustomerOrders)
         {
            myTreeNodeArray[countIndex] = new TreeNode(myOrder.OrderID);
            countIndex++;
         }
         TreeNode customerNode = new TreeNode(myCustomer
                           .CustomerName,myTreeNodeArray);
         myTreeView.Nodes[0].Nodes.Add(customerNode);
      }

      // Begin repainting the TreeView.
      myTreeView.EndUpdate();
   
   }


// <Snippet1> 
public void HighlightCheckedNodes()
{
   int countIndex = 0;
   string selectedNode = "Selected customer nodes are : ";
   foreach (TreeNode myNode in myTreeView.Nodes[0].Nodes)
   {
      // Check whether the tree node is checked.
      if(myNode.Checked)
      {
         // Set the node's backColor.
         myNode.BackColor = Color.Yellow;
         selectedNode += myNode.Text+" ";
         countIndex++;
      }
      else
         myNode.BackColor = Color.White;
   }

   if(countIndex > 0)
      MessageBox.Show(selectedNode);
   else
      MessageBox.Show("No nodes are selected");
}
// </Snippet1>


   private void MyButton_Click(object sender,EventArgs e)
   {  
      HighlightCheckedNodes();
   }

   
   private void InitializeComponent()
   {
      this.myTreeView = new System.Windows.Forms.TreeView();
      this.SuspendLayout();
      this.myTreeView.ImageIndex = -1;
      this.myTreeView.Location = new System.Drawing.Point(8, 0);
      this.myTreeView.Name = "myTreeView";
      this.myTreeView.SelectedImageIndex = -1;
      this.myTreeView.Size = new Size(280, 152);
      this.myTreeView.TabIndex = 0;
      this.ClientSize = new System.Drawing.Size(292, 273);
      this.myButton = new Button();
      this.Controls.AddRange(new System.Windows.Forms
         .Control[]{this.myButton,this.myTreeView});
      this.myButton.Location = new Point(80, 200);
      this.myButton.Size = new Size(140,25);
      this.myButton.Text = "Display Selected Nodes";
      this.myButton.Click += new EventHandler(MyButton_Click);
      this.Text = "TreeNode Example";
      this.ResumeLayout(false);

   }
   static void Main() 
   {
      Application.Run(new TreeNode_Bounds());
   }
}

