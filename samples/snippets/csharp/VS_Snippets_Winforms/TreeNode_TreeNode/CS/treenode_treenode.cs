// System.Windows.Forms.TreeNode.ImageIndex
// System.Windows.Forms.TreeNode.SelectedImageIndex
// System.Windows.Forms.TreeView.ImageIndex
// System.Windows.Forms.TreeView.SelectedImageIndex
// System.Windows.Forms.TreeView.ImageList
// System.Windows.Forms.TreeNode.TreeNode(string,int,int)
// System.Windows.Forms.TreeNode.TreeNode(string,int,int,TreeNode[])
/*
   The following example demonstrates the constructors 
   'TreeNode(string,int,int)' and 'TreeNode(string,int,int,TreeNode[])' of 
   the 'TreeNode' class. This example displays customerinformation in a
   'TreeView' control. The root tree nodes display customer names, and the
   child tree nodes display the order numbers assigned to each customer. 
*/

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;



public class TreeNode_Checked : Form
{
	private int rootImageIndex;
	private int selectedCustomerImageIndex;
	private int unselectedCustomerImageIndex;
	private int selectedOrderImageIndex;
	private int unselectedOrderImageIndex;
	private TreeView myTreeView;
	
	public TreeNode_Checked()
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

   	FillTreeView();

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

private void FillTreeView()
{
	// Load the images in an ImageList.
	ImageList myImageList = new ImageList();
	myImageList.Images.Add(Image.FromFile("Default.gif"));
	myImageList.Images.Add(Image.FromFile("SelectedDefault.gif"));
	myImageList.Images.Add(Image.FromFile("Root.gif"));
	myImageList.Images.Add(Image.FromFile("UnselectedCustomer.gif"));
	myImageList.Images.Add(Image.FromFile("SelectedCustomer.gif"));
	myImageList.Images.Add(Image.FromFile("UnselectedOrder.gif"));
	myImageList.Images.Add(Image.FromFile("SelectedOrder.gif"));
	
	// Assign the ImageList to the TreeView.
	myTreeView.ImageList = myImageList;
	
	// Set the TreeView control's default image and selected image indexes.
	myTreeView.ImageIndex = 0;
	myTreeView.SelectedImageIndex = 1;

	/* Set the index of image from the 
	ImageList for selected and unselected tree nodes.*/
	this.rootImageIndex = 2;
	this.selectedCustomerImageIndex = 3;
	this.unselectedCustomerImageIndex = 4;
	this.selectedOrderImageIndex = 5;
	this.unselectedOrderImageIndex = 6;
	
	// Create the root tree node.
	TreeNode rootNode = new TreeNode("CustomerList");
	rootNode.ImageIndex = rootImageIndex;
	rootNode.SelectedImageIndex = rootImageIndex;
      
	// Add a main root tree node.
	myTreeView.Nodes.Add(rootNode);

	// Add a root tree node for each Customer object in the ArrayList.
	foreach(Customer myCustomer in customerArray)
	{
		// Add a child tree node for each Order object.
		int countIndex=0;
		TreeNode[] myTreeNodeArray = new TreeNode[myCustomer.CustomerOrders.Count];
		foreach(Order myOrder in myCustomer.CustomerOrders)
		{
			// Add the Order tree node to the array.
			myTreeNodeArray[countIndex] = new TreeNode(myOrder.OrderID,
			  unselectedOrderImageIndex, selectedOrderImageIndex);
			countIndex++;
		}
		// Add the Customer tree node.
		TreeNode customerNode = new TreeNode(myCustomer.CustomerName,
			unselectedCustomerImageIndex, selectedCustomerImageIndex, myTreeNodeArray);
		myTreeView.Nodes[0].Nodes.Add(customerNode);
	}
}
// </Snippet1>  


   private void InitializeComponent()
   {
      this.myTreeView = new TreeView();
      this.SuspendLayout();
      this.myTreeView.ImageIndex = -1;
      this.myTreeView.Location = new Point(8, 0);
      this.myTreeView.Name = "myTreeView";
      this.myTreeView.SelectedImageIndex = -1;
      this.myTreeView.Size = new Size(280, 152);
      this.myTreeView.TabIndex = 0;
      this.ClientSize = new Size(292, 273);
      this.Controls.Add(this.myTreeView);
      this.Name = "Form1";
      this.Text = "TreeNode Example";
      this.ResumeLayout(true);
   }

   static void Main() 
   {
      Application.Run(new TreeNode_Checked());
   }
}
