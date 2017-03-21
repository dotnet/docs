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