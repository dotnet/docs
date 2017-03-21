	private void InitializeListViewItems()
	{
		ListView1.View = View.List;
		

		Cursor[] favoriteCursors = new Cursor[]{Cursors.Help, 
			Cursors.Hand, Cursors.No, Cursors.Cross};

		// Populate the ListView control with the array of Cursors.
		foreach ( Cursor aCursor in favoriteCursors )
		{

			// Construct the ListViewItem object
			ListViewItem item = new ListViewItem();

			// Set the Text property to the cursor name.
			item.Text = aCursor.ToString();

			// Set the Tag property to the cursor.
			item.Tag = aCursor;

			// Add the ListViewItem to the ListView.
			ListView1.Items.Add(item);
		}
	}