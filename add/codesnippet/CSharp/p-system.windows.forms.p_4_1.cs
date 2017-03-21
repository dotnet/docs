
	// Declare a propertyGrid.
	internal PropertyGrid propertyGrid1;

	// Initialize propertyGrid1.
	private void InitializePropertyGrid()
	{
		propertyGrid1 = new PropertyGrid();
		propertyGrid1.Name = "PropertyGrid1";
		propertyGrid1.Location = new System.Drawing.Point(185, 20);
		propertyGrid1.Size = new System.Drawing.Size(150, 300);
		propertyGrid1.TabIndex = 5;

		// Set the sort to alphabetical and set Toolbar visible
		// to false, so the user cannot change the sort.
		propertyGrid1.PropertySort = PropertySort.Alphabetical;
		propertyGrid1.ToolbarVisible = false;
		propertyGrid1.Text = "Property Grid";

		// Add the PropertyGrid to the form, but set its
		// visibility to False so it will not appear when the form loads.
		propertyGrid1.Visible = false;
		this.Controls.Add(propertyGrid1);

	}