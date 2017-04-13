// System.Windows.Forms.TreeNode.PrevVisibleNode
// System.Windows.Forms.TreeNode.PrevNode
// System.Windows.Forms.TreeNode.NextVisibleNode
// System.Windows.Forms.TreeNode.NextNode
// System.Windows.Forms.TreeNode.LastNode
// System.Windows.Forms.TreeNode.FirstNode
// System.Windows.Forms.TreeNode.TreeView
// System.Windows.Forms.TreeNode.IsSelected


/*
   The following program demonstrates the 'NodeFont', 'Parent', 'Text' and 'PrevVisibleNode'
   properties of the 'TreeNode' class. It creates a TreeView consisting of customer nodes
   and 'order' as its child nodes. It also provides option for the user to change the font
   and text of the node.
*/
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

public class MyTreeNodeForm : System.Windows.Forms.Form
{
	private TreeView myTreeView;
	private Button myButton;
	private ComboBox myComboBox;
	private Label myLabel1;
	private Label myLabel3;
	private Label myLabel4;
	private TextBox myTextBox;
	public MyTreeNodeForm()
	{
		InitializeComponent();
		myButton.Click += new EventHandler(MyButtonClick);
		FillMyTreeView();
	}


	private void MyButtonClick(object sender,EventArgs e)
	{
		TreeNode selectedNode = null;
		foreach (TreeNode node in this.myTreeView.Nodes)
		{
			// See if the root tree node is selected.
			if(node.IsSelected)
			{
				selectedNode = node;
				break;
			}
			
			// Recurse through the TreeNodeCollection.
			selectedNode = GetSelectedNode(node);
			if(selectedNode != null)
			{
				break;
			}
		}

		// Display the previous visible node.
		if(selectedNode != null)
		{
			SelectNode(selectedNode);
		}
	}

	// <Snippet1>
	private void SelectNode(TreeNode node)
	{
		if(node.IsSelected)
		{
			// Determine which TreeNode to select.
			switch(myComboBox.Text)
			{
				case "Previous":
					node.TreeView.SelectedNode = node.PrevNode;
					break;
				case "PreviousVisible":
					node.TreeView.SelectedNode = node.PrevVisibleNode;
					break;
				case "Next":
					node.TreeView.SelectedNode = node.NextNode;
					break;
				case "NextVisible":
					node.TreeView.SelectedNode = node.NextVisibleNode;
					break;
				case "First":
					node.TreeView.SelectedNode = node.FirstNode;
					break;
				case "Last":
					node.TreeView.SelectedNode = node.LastNode;
					break;
			}
		}
		node.TreeView.Focus();
	}
	// </Snippet1>
   

	private TreeNode GetSelectedNode(TreeNode treeNode)
	{
		// Check each node recursively.
		foreach (TreeNode node in treeNode.Nodes)
		{
			if(node.IsSelected)
			{
				// Return the TreeNode if it is selected.
				return node;
			}
		}
		return null;
	}
		
	

	// ArrayList object to hold the 'MyCustomerClass' objects.
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
		myTreeView.BeginUpdate();

		// Clear the 'TreeView' each time the method is called.
		myTreeView.Nodes.Clear();
		TreeNodeCollection myTreeNodeCollectionCustomer = myTreeView.Nodes;
		// Add a root treenode for each 'MyCustomerClass' object in the ArrayList.
		foreach(MyCustomerClass myCustomerClass2 in customerArray)
		{
			myTreeNodeCollectionCustomer.Add(
				new TreeNode(myCustomerClass2.CustomerName));
			TreeNodeCollection myTreeNodeCollectionOrders =
				myTreeNodeCollectionCustomer
				[customerArray.IndexOf(myCustomerClass2)].Nodes;
			// Add a child treenode for each MyOrder object.
			foreach(MyOrder myOrder1 in myCustomerClass2.CustomerOrders)
			{
				myTreeNodeCollectionOrders.Add(new TreeNode(myOrder1.OrderID));
				TreeNode myTreeNodeOrder = myTreeNodeCollectionOrders
					[myCustomerClass2.CustomerOrders.IndexOf(myOrder1)];
			}
		}
		myTreeView.SelectedImageIndex = 0;
		// Begin repainting the 'TreeView'.
		myTreeView.EndUpdate();
	}
	private void InitializeComponent()
	{
		this.myTreeView = new System.Windows.Forms.TreeView();
		this.myTextBox = new System.Windows.Forms.TextBox();
		this.myComboBox = new System.Windows.Forms.ComboBox();
		this.myLabel4 = new System.Windows.Forms.Label();
		this.myButton = new System.Windows.Forms.Button();
		this.myLabel1 = new System.Windows.Forms.Label();
		this.myLabel3 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		// 
		// myTreeView
		// 
		this.myTreeView.ImageIndex = -1;
		this.myTreeView.Location = new System.Drawing.Point(8, 16);
		this.myTreeView.Name = "myTreeView";
		this.myTreeView.SelectedImageIndex = -1;
		this.myTreeView.Size = new System.Drawing.Size(136, 328);
		this.myTreeView.TabIndex = 0;
		// 
		// myTextBox
		// 
		this.myTextBox.Location = new System.Drawing.Point(368, 96);
		this.myTextBox.Name = "myTextBox";
		this.myTextBox.Size = new System.Drawing.Size(128, 20);
		this.myTextBox.TabIndex = 9;
		this.myTextBox.Text = "TestNode";
		// 
		// myComboBox
		// 
		this.myComboBox.DropDownWidth = 121;
		this.myComboBox.Items.AddRange(new object[] {"PreviousVisible", "NextVisible", "Previous", "Next", "First", "Last"});
		this.myComboBox.Location = new System.Drawing.Point(368, 24);
		this.myComboBox.Name = "myComboBox";
		this.myComboBox.Size = new System.Drawing.Size(128, 21);
		this.myComboBox.TabIndex = 1;
		// 
		// myLabel4
		// 
		this.myLabel4.Location = new System.Drawing.Point(152, 96);
		this.myLabel4.Name = "myLabel4";
		this.myLabel4.Size = new System.Drawing.Size(192, 16);
		this.myLabel4.TabIndex = 7;
		this.myLabel4.Text = "Change text of selected TreeNode to";
		// 
		// myButton
		// 
		this.myButton.Location = new System.Drawing.Point(368, 152);
		this.myButton.Name = "myButton";
		this.myButton.Size = new System.Drawing.Size(128, 23);
		this.myButton.TabIndex = 2;
		this.myButton.Text = "Apply";
		// 
		// myLabel1
		// 
		this.myLabel1.Location = new System.Drawing.Point(152, 216);
		this.myLabel1.Name = "myLabel1";
		this.myLabel1.Size = new System.Drawing.Size(408, 120);
		this.myLabel1.TabIndex = 4;
		// 
		// myLabel3
		// 
		this.myLabel3.Location = new System.Drawing.Point(152, 32);
		this.myLabel3.Name = "myLabel3";
		this.myLabel3.Size = new System.Drawing.Size(128, 16);
		this.myLabel3.TabIndex = 6;
		this.myLabel3.Text = "Select Font";
		// 
		// MyTreeNodeForm
		// 
		this.ClientSize = new System.Drawing.Size(624, 365);
		this.Controls.AddRange(new System.Windows.Forms.Control[] {
																						 this.myTextBox,
																						 this.myLabel4,
																						 this.myLabel3,
																						 this.myLabel1,
																						 this.myComboBox,
																						 this.myButton,
																						 this.myTreeView});
		this.Name = "MyTreeNodeForm";
		this.Text = "TreeNode class sample";
		this.ResumeLayout(false);

	}

	static void Main()
	{
		Application.Run(new MyTreeNodeForm());
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