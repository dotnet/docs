        private ListView resizingListView = new ListView();
        private Button button1 = new Button();

        private void InitializeResizingListView()
        {
            // Set location and text for button.
            button1.Location = new Point(100, 15);
            button1.Text = "Resize";
            button1.Click += new EventHandler(button1_Click);

            // Set the ListView to details view.
            resizingListView.View = View.Details;

            //Set size, location and populate the ListView.
            resizingListView.Size = new Size(200, 100);
            resizingListView.Location = new Point(40, 40);
            resizingListView.Columns.Add("HeaderSize");
            resizingListView.Columns.Add("ColumnContent");
            ListViewItem listItem1 = new ListViewItem("Short");
            ListViewItem listItem2 = new ListViewItem("Tiny");
            listItem1.SubItems.Add(new ListViewItem.ListViewSubItem( 
                    listItem1, "Something longer"));
            listItem2.SubItems.Add(new ListViewItem.ListViewSubItem(
                listItem2, "Something even longer"));
            resizingListView.Items.Add(listItem1);
            resizingListView.Items.Add(listItem2);

            // Add the ListView and the Button to the form.
            this.Controls.Add(resizingListView);
            this.Controls.Add(button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resizingListView.AutoResizeColumn(0, 
                ColumnHeaderAutoResizeStyle.HeaderSize);
            resizingListView.AutoResizeColumn(1, 
                ColumnHeaderAutoResizeStyle.ColumnContent);
        }
