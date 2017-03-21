
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