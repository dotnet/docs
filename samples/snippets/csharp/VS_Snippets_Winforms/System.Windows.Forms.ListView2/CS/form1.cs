
// The following code example demonstrates using the ListView.CheckedItems, 
// CheckedItem.CheckState, ListView.BeginUpdate, and ListView.EndUpdate 
// members, along with instances of the ListViewCheckedItemCollection, 
// and ItemCheckEventArgs classes


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
		// Connect the events with the methods that handle them.
		this.ListView1.ItemCheck += 
			new ItemCheckEventHandler(ListView1_ItemCheck1);
		this.ListView1.ItemCheck += 
			new ItemCheckEventHandler(ListView1_ItemCheck2);

		
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

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}

	//<snippet1>
	private void InitializeListView()
	{
		this.ListView1 = new System.Windows.Forms.ListView();

		// Set properties such as BackColor and DockStyle and Location.
		this.ListView1.BackColor = System.Drawing.SystemColors.Control;
		this.ListView1.Dock = System.Windows.Forms.DockStyle.Top;
		this.ListView1.Location = new System.Drawing.Point(0, 0);
		this.ListView1.Size = new System.Drawing.Size(292, 130);
		this.ListView1.View = System.Windows.Forms.View.Details;
		this.ListView1.HideSelection = false;

		// Allow the user to select multiple items.
		this.ListView1.MultiSelect = true;

		// Show CheckBoxes in the ListView.
		this.ListView1.CheckBoxes = true;
		
		//Set the column headers and populate the columns.
		ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
		
		ColumnHeader columnHeader1 = new ColumnHeader();
		columnHeader1.Text = "Breakfast Choices";
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
			"2.79", "2.09", "2.69"};
		
		int count;

		// Members are added one at a time, so call BeginUpdate to ensure 
		// the list is painted only once, rather than as each list item is added.
		ListView1.BeginUpdate();

		for(count = 0; count < foodList.Length; count++)
		{
			ListViewItem listItem = new ListViewItem(foodList[count]);
			listItem.SubItems.Add(foodPrice[count]);
			ListView1.Items.Add(listItem);
		}

		//Call EndUpdate when you finish adding items to the ListView.
		ListView1.EndUpdate();
		this.Controls.Add(this.ListView1);
	}
	//</snippet1>

	//<snippet2>
	double price = 0.0;

	// Handles the ItemCheck event. The method uses the CurrentValue
	// property of the ItemCheckEventArgs to retrieve and tally the  
	// price of the menu items selected.  
	private void ListView1_ItemCheck1(object sender, 
		System.Windows.Forms.ItemCheckEventArgs e)
	{
		if (e.CurrentValue==CheckState.Unchecked)
		{
			price += Double.Parse(
				this.ListView1.Items[e.Index].SubItems[1].Text);
		}
		else if((e.CurrentValue==CheckState.Checked))
		{
			price -= Double.Parse(
				this.ListView1.Items[e.Index].SubItems[1].Text);
		}

		// Output the price to TextBox1.
		TextBox1.Text = price.ToString();
	}
	//</snippet2>


	//<snippet3>
	// Handles the ItemChecked event.  The method loops through all the 
	// checked items and tallies a new price each time an item is 
	// checked or unchecked. It outputs the price to TextBox1.
	private void ListView1_ItemCheck2(object sender, 
		System.Windows.Forms.ItemCheckEventArgs e)
	{
		double price = 0.0;
		ListView.CheckedListViewItemCollection checkedItems = 
			ListView1.CheckedItems;
		
		foreach ( ListViewItem item in checkedItems )
		{
			price += Double.Parse(item.SubItems[1].Text);
		}
		if (e.CurrentValue==CheckState.Unchecked)
		{
			price += Double.Parse(
				this.ListView1.Items[e.Index].SubItems[1].Text);
		}
		else if((e.CurrentValue==CheckState.Checked))
		{
			price -= Double.Parse(
				this.ListView1.Items[e.Index].SubItems[1].Text);
		}
		// Output the price to TextBox1.
		TextBox1.Text = price.ToString();
	}
	//</snippet3>

}



