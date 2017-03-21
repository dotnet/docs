	private void PopulateListView()
	{
		ListView1.Width = 270;
		ListView1.Location = new System.Drawing.Point(10, 10);

		// Declare and construct the ColumnHeader objects.
		ColumnHeader header1, header2;
		header1 = new ColumnHeader();
		header2 = new ColumnHeader();

		// Set the text, alignment and width for each column header.
		header1.Text = "File name";
		header1.TextAlign = HorizontalAlignment.Left;
		header1.Width = 70;

		header2.TextAlign = HorizontalAlignment.Left;
		header2.Text = "Location";
		header2.Width = 200;

		// Add the headers to the ListView control.
		ListView1.Columns.Add(header1);
		ListView1.Columns.Add(header2);

        // Specify that each item appears on a separate line.
        ListView1.View = View.Details;
        
        // Populate the ListView.Items property.
		// Set the directory to the sample picture directory.
		System.IO.DirectoryInfo dirInfo = 
			new System.IO.DirectoryInfo(
			"C:\\Documents and Settings\\All Users" +
			"\\Documents\\My Pictures\\Sample Pictures");
		

		// Get the .jpg files from the directory
		System.IO.FileInfo[] files = dirInfo.GetFiles("*.jpg");

		// Add each file name and full name including path
		// to the ListView.
		if (files != null)
		{
			foreach ( System.IO.FileInfo file in files )
			{
				ListViewItem item = new ListViewItem(file.Name);
				item.SubItems.Add(file.FullName);
				ListView1.Items.Add(item);
			}
		}
	}