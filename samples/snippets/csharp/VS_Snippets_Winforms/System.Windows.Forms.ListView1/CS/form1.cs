// The following Snippet code example demonstrates using the: 
// ListView.MultiSelect, ListView.SelectedItems, 
// ListView.SelectIndices, SelectedIndexCollection, 
// SelectedListViewItemCollection ListView.SelectedIndexChanged event, 
// and ListView.HeaderStyle members and the SelectedIndexCollection and
// SelectedListViewItemCollection classes.

 
using System.Windows.Forms;
using System.Drawing;
using System;

public class Form1:
	System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializeComponent();
		InitializeListView();
		HookupEvents();
	}

	internal System.Windows.Forms.ListView ListView1;
	internal System.Windows.Forms.TextBox TextBox1;
	internal System.Windows.Forms.Label Label1;

	private void InitializeComponent()
	{

		this.TextBox1 = new System.Windows.Forms.TextBox();
		this.Label1 = new System.Windows.Forms.Label();
		this.SuspendLayout();
		this.TextBox1.Location = new System.Drawing.Point(88, 168);
		this.TextBox1.Name = "TextBox1";
		this.TextBox1.Size = new System.Drawing.Size(120, 20);
		this.TextBox1.TabIndex = 1;
		this.TextBox1.Text = "";
		this.Label1.Location = new System.Drawing.Point(32, 168);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(48, 23);
		this.Label1.TabIndex = 2;
		this.Label1.Text = "Total: $";
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Label1);
		this.Controls.Add(this.TextBox1);

		this.Name = "Form1";
		this.Text = "Breakfast Menu";
		this.ResumeLayout(false);
		
		

	}

	[System.STAThreadAttribute]
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet1>
	// This method adds two columns to the ListView, setting the Text 
	// and TextAlign, and Width properties of each ColumnHeader.  The 
	// HeaderStyle property is set to NonClickable since the ColumnClick 
	// event is not handled.  Finally the method adds ListViewItems and 
	// SubItems to each column.
	private void InitializeListView()
	{
		this.ListView1 = new System.Windows.Forms.ListView();
		this.ListView1.BackColor = System.Drawing.SystemColors.Control;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Top;
		this.ListView1.Location = new System.Drawing.Point(0, 0);
		this.ListView1.Name = "ListView1";
		this.ListView1.Size = new System.Drawing.Size(292, 130);
		this.ListView1.TabIndex = 0;
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.MultiSelect = true;
		this.ListView1.HideSelection = false;
		this.ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		
		ColumnHeader columnHeader1 = new ColumnHeader();
		columnHeader1.Text = "Breakfast Item";
		columnHeader1.TextAlign = HorizontalAlignment.Left;
		columnHeader1.Width = 146;

	 	ColumnHeader columnHeader2 = new ColumnHeader();
		columnHeader2.Text = "Price Each";
		columnHeader2.TextAlign = HorizontalAlignment.Center;
		columnHeader2.Width = 142;
  
		this.ListView1.Columns.Add(columnHeader1);
		this.ListView1.Columns.Add(columnHeader2);

		string[] foodList = new string[]{"Juice", "Coffee", 
			"Cereal & Milk", "Fruit Plate", "Toast & Jelly", 
			"Bagel & Cream Cheese"};
		string[] foodPrice = new string[]{"1.09", "1.09", "2.19", 
			"2.49", "1.49", "1.49"};
		
		for(int count=0; count < foodList.Length; count++)
		{
			ListViewItem listItem = new ListViewItem(foodList[count]);
			listItem.SubItems.Add(foodPrice[count]);
			ListView1.Items.Add(listItem);
		}
		this.Controls.Add(ListView1);
	}
	
	//</snippet1>

	private void HookupEvents() 
	{
		this.ListView1.SelectedIndexChanged += 
			new EventHandler(ListView1_SelectedIndexChanged_UsingItems);
		this.ListView1.SelectedIndexChanged += 
			new EventHandler(ListView1_SelectedIndexChanged_UsingIndices);
	}
	// You can access the selected items directly with the SelectedItems   
	// property or you can access them through the items' indices,  
	// using the SelectedIndices property.  The following methods show
	// the two approaches.


	//<snippet2>
	// Uses the SelectedItems property to retrieve and tally the price 
	// of the selected menu items.
	private void ListView1_SelectedIndexChanged_UsingItems(
		object sender, System.EventArgs e)
	{

		ListView.SelectedListViewItemCollection breakfast = 
			this.ListView1.SelectedItems;
		
		double price = 0.0;
		foreach ( ListViewItem item in breakfast )
		{
			price += Double.Parse(item.SubItems[1].Text);
		}

		// Output the price to TextBox1.
		TextBox1.Text = price.ToString();
	}
	//</snippet2>

	//<snippet3>
	// Uses the SelectedIndices property to retrieve and tally the  
	// price of the selected menu items.
	private void ListView1_SelectedIndexChanged_UsingIndices(
		object sender, System.EventArgs e)
	{

		ListView.SelectedIndexCollection indexes = 
			this.ListView1.SelectedIndices;
		
		double price = 0.0;
		foreach ( int index in indexes )
		{
			price += Double.Parse(
				this.ListView1.Items[index].SubItems[1].Text);
		}

		// Output the price to TextBox1.
		TextBox1.Text =  price.ToString();
	}
	//</snippet3>

}
 

