        ListView indentedListView;

        private void InitializeIndentedListViewItems()
        {
            indentedListView = new ListView();
            indentedListView.Width = 200;

            // View must be set to Details to use IndentCount.
            indentedListView.View = View.Details;
            indentedListView.Columns.Add("Indented Items", 150);
           
            // Create an image list and add an image.
            ImageList list = new ImageList();
            list.Images.Add(new Bitmap(typeof(Button), "Button.bmp"));

            // SmallImageList must be set when using IndentCount.
            indentedListView.SmallImageList = list;

            ListViewItem item1 = new ListViewItem("Click", 0);
            item1.IndentCount = 1;
            ListViewItem item2 = new ListViewItem("OK", 0);
            item2.IndentCount = 2;
            ListViewItem item3 = new ListViewItem("Cancel", 0);
            item3.IndentCount = 3;
            indentedListView.Items.AddRange(new ListViewItem[] { item1, item2, item3 });

            // Add the controls to the form.
            this.Controls.Add(indentedListView);

        }