        ListView iconListView = new ListView();
        TextBox previousItemBox = new TextBox();

        private void InitializeLocationSearchListView()
        {
            previousItemBox.Location = new Point(150, 20);

            // Create an image list for the icon ListView.
            iconListView.LargeImageList = new ImageList();
            iconListView.Height = 400;
            
            // Add an image to the ListView large icon list.
            iconListView.LargeImageList.Images.Add(
                new Bitmap(typeof(Control), "Edit.bmp"));

            // Set the view to large icon and add some items with the image
            // in the image list.
            iconListView.View = View.LargeIcon;
            iconListView.Items.AddRange(new ListViewItem[]{
                new ListViewItem("Amy Alberts", 0), 
                new ListViewItem("Amy Recker", 0), 
                new ListViewItem("Erin Hagens", 0), 
                new ListViewItem("Barry Johnson", 0), 
                new ListViewItem("Jay Hamlin", 0), 
                new ListViewItem("Brian Valentine", 0), 
                new ListViewItem("Brian Welker", 0), 
                new ListViewItem("Daniel Weisman", 0) });
            this.Controls.Add(iconListView);
            this.Controls.Add(previousItemBox);

            // Handle the MouseDown event to capture user input.
           iconListView.MouseDown +=
               new MouseEventHandler(iconListView_MouseDown);
            //iconListView.MouseWheel += new MouseEventHandler(iconListView_MouseWheel);   
        }

        void iconListView_MouseDown(object sender, MouseEventArgs e)
        {
            
            // Find the an item above where the user clicked.
            ListViewItem foundItem =
                iconListView.FindNearestItem(SearchDirectionHint.Up, e.X, e.Y);

            // Display the results in a textbox..
            if (foundItem != null)
                previousItemBox.Text = foundItem.Text;
            else
                previousItemBox.Text = "No item found";
        }