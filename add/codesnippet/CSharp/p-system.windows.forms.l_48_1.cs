        private ListView positionListView;
        private ListViewItem moveItem;
        private Button button1;

        private void InitializePositionedListViewItems()
        {
            // Set some basic properties on the ListView and button.
            positionListView = new ListView();
            positionListView.Height = 200;
            button1 = new Button();
            button1.Location = new Point(160, 30);
            button1.AutoSize = true;
            button1.Text = "Click to reposition";
            button1.Click += new System.EventHandler(button1_Click);

            // View must be set to icon view to use the Position property.
            positionListView.View = View.LargeIcon;
          
            // Create the items and add them to the ListView.
            ListViewItem item1 = new ListViewItem("Click");
            ListViewItem item2 = new ListViewItem("OK");
            moveItem = new ListViewItem("Move");
            positionListView.Items.AddRange(new ListViewItem[] 
                { item1, item2, moveItem });

            // Add the controls to the form.
            this.Controls.Add(positionListView);
            this.Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            moveItem.Position = new Point(30, 30);
        }