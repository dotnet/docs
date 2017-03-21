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
	