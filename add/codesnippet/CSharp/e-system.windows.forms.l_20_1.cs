        ListView listView1 = new ListView();
        private void InitializeListView1()
        {
			// Initialize a ListView in detail view and add some columns.
            listView1.View = View.Details;
            listView1.Width = 200;
            listView1.Columns.Add("Column1");
            listView1.Columns.Add("Column2");

			// Associate a method with the ColumnWidthChangingEvent.
            listView1.ColumnWidthChanging += 
                new ColumnWidthChangingEventHandler(listView1_ColumnWidthChanging);
            this.Controls.Add(listView1);
        }
       
		// Handle the ColumnWidthChangingEvent.
        private void listView1_ColumnWidthChanging(object sender,  
            ColumnWidthChangingEventArgs e)
        {
			// Check if the new width is too big or too small.
            if (e.NewWidth > 100 || e.NewWidth < 5)
            {
				// Cancel the event and inform the user if the new
				// width does not meet the criteria.
                MessageBox.Show("Column width is too large or too small");
		        e.Cancel = true;
            }
        }
        