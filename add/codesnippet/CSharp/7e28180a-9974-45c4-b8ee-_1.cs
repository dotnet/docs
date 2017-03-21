      	private ListView resizingListView2 = new ListView();
        private Button resizeButton = new Button();

        private void InitializeResizingListView2()
        {
            // Set location and text for button.
            resizeButton.Location = new Point(100, 15);
            button1.Text = "Resize";
            button1.Click += new EventHandler(button1_Click);

            // Set the ListView to details view.
            resizingListView2.View = View.Details;

            //Set size, location and populate the ListView.
            resizingListView2.Size = new Size(200, 100);
            resizingListView2.Location = new Point(40, 40);
            resizingListView2.Columns.Add("HeaderSize");
            resizingListView2.Columns.Add("ColumnContent");
            ListViewItem listItem1 = new ListViewItem("Short");
            ListViewItem listItem2 = new ListViewItem("Tiny");
            listItem1.SubItems.Add(new ListViewItem.ListViewSubItem(
                    listItem1, "Something longer"));
            listItem2.SubItems.Add(new ListViewItem.ListViewSubItem(
                listItem2, "Something even longer"));
            resizingListView2.Items.Add(listItem1);
            resizingListView2.Items.Add(listItem2);

            // Add the ListView and the Button to the form.
            this.Controls.Add(resizingListView2);
            this.Controls.Add(resizeButton);
        }

        private void resizeButton_Click(object sender, EventArgs e)
        {
            resizingListView2.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }