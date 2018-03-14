// System.Windows.Forms.TreeNode.TreeNode()
// System.Windows.Forms.TreeNode.TreeNode(string,TreeNode[])
// System.Windows.Forms.TreeNode.Bounds
// System.Windows.Forms.TreeNode.ForeColor
// System.Windows.Forms.TreeNode.NodeFont
// System.Windows.Forms.TreeNode.Text
// System.Windows.Forms.TreeNode.Tag
// System.Windows.Forms.TreeView.ItemHeight
/*
   The following example demonstrates the constructors 'TreeNode()'
   and 'TreeNode(string,TreeNode[])' and the property 'Bounds' of the
   'TreeNode' class. This example displays customer information in a 
   'TreeView' control. The root tree nodes display customer names, and 
   the child tree nodes display the order numbers assigned to each 
   customer. 
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


public class TreeNode_Bounds : Form
{
   private TreeView myTreeView;
   private Button myButton;
   private Label mylabel;
   private ComboBox myComboBox;
   public TreeNode_Bounds()
   {
      InitializeComponent();
      FillMyTreeView();
   }
   // ArrayList object to hold the 'Customer' objects.
   private ArrayList customerArray = new ArrayList();

   private void FillMyTreeView()
   {
      // Add customers to the ArrayList of 'Customer' objects.
      for(int xIndex=1; xIndex<=5; xIndex++)
      {
         customerArray.Add(new Customer("Customer" + xIndex.ToString()));
      }

      // Add orders to each 'Customer' object in the ArrayList.
      foreach(Customer customer1 in customerArray)
      {
         for(int yIndex=1; yIndex<=5; yIndex++)
         {
            customer1.CustomerOrders.Add(new Order("Order" + yIndex.ToString()));    
         }
      }
      // Supress repainting of the TreeView.
      myTreeView.BeginUpdate();

      // Clear the TreeView each time the method is called.
      myTreeView.Nodes.Clear();

      AddRootNodes();

      // Begin repainting the TreeView.
      myTreeView.EndUpdate();
   }

// <Snippet1>
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

public void AddRootNodes()
{
   // Add a root node to assign the customer nodes to.
   TreeNode rootNode = new TreeNode();
   rootNode.Text = "CustomerList";
   // Add a main root treenode.
   myTreeView.Nodes.Add(rootNode);

   // Add a root treenode for each 'Customer' object in the ArrayList.
   foreach(Customer myCustomer in customerArray)
   {
      // Add a child treenode for each Order object.
      int i = 0;
      TreeNode[] myTreeNodeArray = new TreeNode[5];
      foreach(Order myOrder in myCustomer.CustomerOrders)
      {
         myTreeNodeArray[i] = new TreeNode(myOrder.OrderID);
         i++;
      }
      TreeNode customerNode = new TreeNode(myCustomer.CustomerName,
        myTreeNodeArray);
		// Display the customer names with and Orange font.
		customerNode.ForeColor = Color.Orange;
		// Store the Customer object in the Tag property of the TreeNode.
		customerNode.Tag = myCustomer;
      myTreeView.Nodes[0].Nodes.Add(customerNode);
   }
}
// </Snippet1>  


// <Snippet2> 
   private void Button1_Click(object sender,EventArgs e)
   {
      myTreeView.ItemHeight = 5;
      myTreeView.SelectedNode.NodeFont = new Font("Arial",5);

      // Get the font size from combobox.
      string selectedString = myComboBox.SelectedItem.ToString();
      int myNodeFontSize = Int32.Parse(selectedString);

      // Set the font of root node.
      myTreeView.SelectedNode.NodeFont = new Font("Arial",myNodeFontSize);
      for(int i = 0; i < myTreeView.Nodes[0].Nodes.Count; i++)
      {
         // Set the font of child nodes.
         myTreeView.Nodes[0].Nodes[i].NodeFont =
           new Font("Arial",myNodeFontSize);
      }

      // Get the bounds of the tree node.
      Rectangle myRectangle = myTreeView.SelectedNode.Bounds;
      int myNodeHeight = myRectangle.Height;
      if(myNodeHeight < myNodeFontSize)
      {
         myNodeHeight = myNodeFontSize;
      }
      myTreeView.ItemHeight = myNodeHeight + 4;
   }
// </Snippet2>


   private void InitializeComponent()
   {
      this.myTreeView = new System.Windows.Forms.TreeView();
      this.myButton = new System.Windows.Forms.Button();
      this.myComboBox = new System.Windows.Forms.ComboBox();
      this.mylabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      this.myTreeView.ImageIndex = -1;
      this.myTreeView.Location = new System.Drawing.Point(8, 0);
      this.myTreeView.Name = "myTreeView";
      this.myTreeView.SelectedImageIndex = -1;
      this.myTreeView.Size = new Size(280, 152);
      this.myTreeView.TabIndex = 0;
      this.myButton.Location = new System.Drawing.Point(104, 232);
      this.myButton.Name = "myButton";
      this.myButton.TabIndex = 2;
      this.myButton.Text = "Submit";
      this.myButton.Click += new System.EventHandler(this.Button1_Click);
      this.myComboBox.DropDownWidth = 121;
      this.myComboBox.Items.AddRange(new object[] {"6", "7", "8", "10", "12", "16", "18", "22"});
      this.myComboBox.Location = new System.Drawing.Point(112, 184);
      this.myComboBox.Name = "myComboBox";
      this.myComboBox.Size = new System.Drawing.Size(121, 21);
      this.myComboBox.TabIndex = 1;
      this.myComboBox.SelectedIndex = 0;
      this.myComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
      this.mylabel.Location = new System.Drawing.Point(0, 184);
      this.mylabel.Name = "mylabel";
      this.mylabel.TabIndex = 3;
      this.mylabel.Text = "Select a Height for TreeNode";
      this.mylabel.Size = new Size(100,50);
      this.ClientSize = new System.Drawing.Size(292, 273);
      this.Controls.AddRange(new System.Windows.Forms
                  .Control[] {this.mylabel,this.myButton,
                     this.myComboBox,this.myTreeView});
      this.Text = "TreeNode Example";
      this.ResumeLayout(false);
   }
   static void Main() 
   {
      Application.Run(new TreeNode_Bounds());
   }
}

