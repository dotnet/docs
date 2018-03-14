// System.Windows.Forms.TreeNode.ExpandAll()
// System.Windows.Forms.TreeNode.FirstNode
// System.Windows.Forms.TreeNode.ForeColor
// System.Windows.Forms.TreeNode.GetNodeCount(bool)
// System.Windows.Forms.TreeNode.IsEditing
// System.Windows.Forms.TreeNode.IsExpanded
// System.Windows.Forms.TreeNode.IsSelected
// System.Windows.Forms.TreeNode.FullPath
// System.Windows.Forms.TreeView.PathSeparator


/*
   The following example demonstrates the  properties 'FirstNode',
   'ForeColor', 'IsEditing','IsExpanded' and 'IsSelected', the methods
   'ExpandAll' and 'GetNodeCount(bool)' of the 'TreeNode' class. In the
   program, a form is created and to it 'TreeView', 'GroupBox',
   and two 'CheckBox' controls are added. A 'TreeView' control is
   associated with the class 'ContextMenu' so as to enable the user to change
   the content of a 'TreeNode'. The 'TreeView' control displays a
   hierarchical collection of 'Customer' objects which in turn contain
   'Order' objects.
*/

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;


public class MyTreeNode_FirstNode : Form
{
	private TreeView myTreeView;
	private GroupBox myGroupBox;
	private CheckBox myCheckBox;
	private CheckBox myCheckBox2;
	private Button myButton;
	private ContextMenu myContextMenu;
	private MenuItem myMenuItem;
	private TreeNode mySelectedNode;

	public MyTreeNode_FirstNode()
	{
		InitializeComponent();
		FillMyTreeView();
	}

	// ArrayList object to hold the 'Customer' objects.
	private ArrayList myCustomerArrayList = new ArrayList();

	private void FillMyTreeView()
	{
		// Add customers to the ArrayList of 'Customer' objects.
		for(int iIndex=1; iIndex<=10; iIndex++)
		{
			myCustomerArrayList.Add(new Customer("Customer" +
				iIndex.ToString()));
		}
		// Add orders to each 'Customer' object in the ArrayList.
		foreach(Customer myCustomer1 in myCustomerArrayList)
		{
			for(int jIndex =1; jIndex <=5; jIndex++)
			{
				myCustomer1.CustomerOrders.Add(new Order("Order" +
					jIndex.ToString()));
			}
		}

		// Suppress repainting the TreeView until it is fully created.
		myTreeView.BeginUpdate();
		// Clear the TreeView each time the method is called.
		myTreeView.Nodes.Clear();
		TreeNode myMainNode = new TreeNode("CustomerList");
		myTreeView.Nodes.Add(myMainNode);

		// Add a root treenode for each 'Customer' in the ArrayList.
		foreach(Customer myCustomer2 in myCustomerArrayList)
		{
			TreeNode myTreeNode1 =  new TreeNode(myCustomer2.CustomerName);
			myTreeNode1.ForeColor = Color.Orange;
			myTreeView.Nodes[0].Nodes.Add(myTreeNode1);
			// Add a child for each 'Order' in the current 'Customer'.
			foreach(Order myOrder1 in myCustomer2.CustomerOrders)
			{
				myTreeView.Nodes[0].Nodes[myCustomerArrayList.
					IndexOf(myCustomer2)].Nodes.Add(new TreeNode
					(myOrder1.OrderID));
			}
		}

		// Reset the cursor back to the default for all controls.
		Cursor.Current = Cursors.Default;
		// Begin repainting the TreeView.
		myTreeView.EndUpdate();
		if (myTreeView.Nodes[0].IsExpanded == false)
			myTreeView.Nodes[0].Expand();
	}

	private void InitializeComponent()
	{
		this.myMenuItem = new MenuItem();
		this.myCheckBox = new CheckBox();
		this.myButton = new Button();
		this.myCheckBox2 = new CheckBox();
		this.myTreeView = new TreeView();
		this.myContextMenu = new ContextMenu();
		this.myGroupBox = new GroupBox();
		this.myGroupBox.SuspendLayout();
		this.SuspendLayout();

		this.myMenuItem.Checked = true;
		this.myMenuItem.DefaultItem = true;
		this.myMenuItem.Index = 0;
		this.myMenuItem.Text = "Edit";
		this.myMenuItem.Click += new System.EventHandler(this.MenuItem1_Click);

		this.myCheckBox.Location = new System.Drawing.Point(24, 24);
		this.myCheckBox.Name = "myCheckBox";
		this.myCheckBox.TabIndex = 0;
		this.myCheckBox.Text = "Expand All";
		this.myCheckBox.CheckedChanged += new System.EventHandler(this.myCheckBox_CheckedChanged);

		this.myButton.Location = new System.Drawing.Point(136, 24);
		this.myButton.Name = "myCheckBox2";
		this.myButton.TabIndex = 1;
		this.myButton.Text = "Child Nodes";
		this.myButton.Click += new System.EventHandler(this.myButton_Click);

		this.myTreeView.ContextMenu = this.myContextMenu;
		this.myTreeView.ImageIndex = -1;
		this.myTreeView.LabelEdit = true;
		this.myTreeView.Location = new System.Drawing.Point(8, 0);
		this.myTreeView.Name = "myTreeView";
		this.myTreeView.SelectedImageIndex = -1;
		this.myTreeView.Size = new System.Drawing.Size(280, 152);
		this.myTreeView.TabIndex = 0;
		this.myTreeView.MouseDown += new MouseEventHandler(this.TreeView1_MouseDown);
		this.myTreeView.AfterLabelEdit += new NodeLabelEditEventHandler
			(this.TreeView1_AfterLabelEdit);

		this.myContextMenu.MenuItems.AddRange(new MenuItem[] {
																				  this.myMenuItem});


		this.myGroupBox.Controls.AddRange(new Control[] {
																			this.myButton,
																			this.myCheckBox});
		this.myGroupBox.Location = new System.Drawing.Point(8, 168);
		this.myGroupBox.Name = "myGroupBox";
		this.myGroupBox.Size = new System.Drawing.Size(272, 96);
		this.myGroupBox.TabIndex = 1;
		this.myGroupBox.TabStop = false;
		this.myGroupBox.Text = "myGroupBox";

		this.ClientSize = new System.Drawing.Size(292, 273);
		this.Controls.AddRange(new Control[] {
															 this.myGroupBox,
															 this.myTreeView});
		this.Name = "Form1";
		this.Text = "Form1";
		this.myGroupBox.ResumeLayout(false);
		this.ResumeLayout(false);

	}

	static void Main()
	{
		Application.Run(new MyTreeNode_FirstNode());
	}

// <Snippet1>
private void myCheckBox_CheckedChanged(object sender, System.EventArgs e)
{
   // If the check box is checked, expand all the tree nodes.
   if (myCheckBox.Checked == true)
   {
      myTreeView.ExpandAll();
   }
   else
   {
      // If the check box is not cheked, collapse the first tree node.
      myTreeView.Nodes[0].FirstNode.Collapse();
      MessageBox.Show("The first and last  node of CutomerList root node is collapsed");
   }
}
// </Snippet1>

// <Snippet2>
private void myButton_Click(object sender, System.EventArgs e)
{
   // Set the tree view's PathSeparator property.
   myTreeView.PathSeparator = ".";

   // Get the count of the child tree nodes contained in the SelectedNode.
   int myNodeCount = myTreeView.SelectedNode.GetNodeCount(true);
   decimal myChildPercentage = ((decimal)myNodeCount/
     (decimal)myTreeView.GetNodeCount(true)) * 100;

   // Display the tree node path and the number of child nodes it and the tree view have.
   MessageBox.Show("The '" + myTreeView.SelectedNode.FullPath + "' node has " 
     + myNodeCount.ToString() + " child nodes.\nThat is " 
     + string.Format("{0:###.##}", myChildPercentage) 
     + "% of the total tree nodes in the tree view control.");
}
// </Snippet2>


	// Save the tree node under the mouse pointer.
	private void TreeView1_MouseDown(object sender,MouseEventArgs e)
	{
		mySelectedNode = myTreeView.GetNodeAt(e.X, e.Y);
	}

	private void MenuItem1_Click(object sender, System.EventArgs e)
	{

		if (mySelectedNode != null && mySelectedNode.Parent != null)
		{
			myTreeView.SelectedNode = mySelectedNode;
			myTreeView.LabelEdit = true;
			mySelectedNode.BeginEdit();
			if (mySelectedNode.IsEditing == true)
				MessageBox.Show("The name of node being edited: "+
					mySelectedNode.Text);
			mySelectedNode.BeginEdit();

		}
		else
		{
			MessageBox.Show("No tree node selected or selected node is a "+
				"root node. Editing of root nodes is not allowed."+
				"Invalid selection");
		}
	}

	private void TreeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
	{
		if (e.Label != null)
		{
			if(e.Label.Length > 0)
			{
				if (e.Label.IndexOfAny(new char[]{'@', '.', ',', '!'})
					== -1)
				{
					// Stop editing without cancelling the label change.
					e.Node.EndEdit(false);
				}
				else
				{
					// Cancel the label edit action, place it in edit mode.
					e.CancelEdit = true;
					MessageBox.Show("Invalid tree node label.\n" +
						"The invalid characters are: '@','.', ',', '!'",
						"Node Label Edit");
					e.Node.BeginEdit();
				}
			}
			else
			{
				// Cancel the label edit action, place it in edit mode.
				e.CancelEdit = true;
				MessageBox.Show("Invalid tree node label."+
					"The label cannot be blank",
					"Node Label Edit");
				e.Node.BeginEdit();
			}
			this.myTreeView.LabelEdit = false;
		}
	}
}

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