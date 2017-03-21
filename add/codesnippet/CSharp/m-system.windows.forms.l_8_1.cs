		// Declare the ListView and Button for the example.
        ListView findListView = new ListView();
        Button findButton = new Button();

        private void InitializeFindListView()
        {
	    // Set up the location and event handling for the button.
            findButton.Click += new EventHandler(findButton_Click);
            findButton.Location = new Point(10, 10);
			
	    // Set up the location of the ListView and add some items.
	    findListView.Location = new Point(10, 30);
            findListView.Items.Add(new ListViewItem("angle bracket"));
            findListView.Items.Add(new ListViewItem("bracket holder"));
            findListView.Items.Add(new ListViewItem("bracket"));

            // Add the button and ListView to the form.
            this.Controls.Add(findButton);
            this.Controls.Add(findListView);
        }

		void findButton_Click(object sender, EventArgs e)
		{
	            // Call FindItemWithText, sending output to MessageBox.
		    ListViewItem item1 = findListView.FindItemWithText("brack");
			 if (item1 != null)
				 MessageBox.Show("Calling FindItemWithText passing 'brack': " 
                     + item1.ToString());
			 else
				 MessageBox.Show("Calling FindItemWithText passing 'brack': null");
		 }