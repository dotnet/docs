// The following code example demonstrates the use of ListView.Clear() 
// and ListViewItem.Selected members.
//
// This snippet example requires a form that contains a ListView 
// called ListView1, on a form, with the View property set to Details.  
// The form also requires a button called button1.

 

using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	internal System.Windows.Forms.Button Button1;
	internal System.Windows.Forms.ListView ListView1;

	public Form1() : base()
	{        

		InitializeListView();

		this.Button1 = new System.Windows.Forms.Button();
		this.SuspendLayout();
   		this.Button1.Location = new System.Drawing.Point(80, 192);
		this.Button1.Name = "Button1";
		this.Button1.Size = new System.Drawing.Size(96, 32);
		this.Button1.TabIndex = 1;
		this.Button1.Text = "See lunch menu";
		this.Button1.Click += new System.EventHandler(Button1_Click);
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.Button1);
		this.Controls.Add(this.ListView1);
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Name = "Form1";
		this.Text = "Meal Selection";
		this.ResumeLayout(false);
	}

	//<snippet1>
	//<snippet2>
	private void InitializeListView()
	{
		// Set up the inital values for the ListView and populate it.
		this.ListView1 = new ListView();
		this.ListView1.Dock = DockStyle.Top;
		this.ListView1.Location = new System.Drawing.Point(0, 0);
		this.ListView1.Size = new System.Drawing.Size(292, 130);
		this.ListView1.View = View.Details;
		this.ListView1.FullRowSelect = true;

		string[] breakfast = new string[]{"Continental Breakfast", 
			"Pancakes and Sausage", "Denver Omelet", "Eggs & Bacon", 
			"Bagel & Cream Cheese"};

		string[] breakfastPrices = new string[]{"3.09", "4.09", 
			"4.19", "4.79", "2.09"};

		PopulateMenu("Breakfast", breakfast, breakfastPrices);
	}

	private void PopulateMenu(string meal, 
		string[] menuItems, string[] menuPrices)
	{
		ColumnHeader columnHeader1 = new ColumnHeader();
		columnHeader1.Text = meal + " Choices";
		columnHeader1.TextAlign = HorizontalAlignment.Left;
		columnHeader1.Width = 146;

		ColumnHeader columnHeader2 = new ColumnHeader();
		columnHeader2.Text = "Price";
		columnHeader2.TextAlign = HorizontalAlignment.Center;
		columnHeader2.Width = 142;

		this.ListView1.Columns.Add(columnHeader1);
		this.ListView1.Columns.Add(columnHeader2);

		for(int count=0; count < menuItems.Length; count++)
		{
			ListViewItem listItem = 
				new ListViewItem(menuItems[count]);
			listItem.SubItems.Add(menuPrices[count]);
			ListView1.Items.Add(listItem);
		}

		// Use the Selected property to select the first item on 
		// the list.
		ListView1.Focus();
		ListView1.Items[0].Selected = true;
	}
        //</snippet2>


	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		// Create new values for the ListView, clear the list, 
		// and repopulate it.
		string[] lunch = new string[]{"Hamburger", "Grilled Cheese",
			"Soup & Salad", "Club Sandwich", "Hotdog"};

		string[] lunchPrices = new string[]{"4.09", "5.09", "5.19", 
			"4.79", "2.09"};

		ListView1.Clear();

		PopulateMenu("Lunch", lunch, lunchPrices);
		Button1.Enabled = false;
	}
	//</snippet1>

	[System.STAThread]
	public static void Main()
	{
		Application.Run(new Form1());
	}
}
 

