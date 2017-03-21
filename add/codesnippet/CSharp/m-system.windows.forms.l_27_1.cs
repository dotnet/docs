        private ListView listView1;

        private void  InitializeListView1(){
            listView1 = new ListView();
            
            // Set the view to details to show subitems.
            listView1.View = View.Details;
           
            // Add some columns and set the width.
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Number");
            listView1.Columns.Add("Description");
            listView1.Width = 175;

            // Create some items and subitems; add the to the ListView.
            ListViewItem item1 = new ListViewItem("Widget");
            item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, "14"));
            item1.SubItems.Add(new ListViewItem.ListViewSubItem(item1, 
                "A description of Widget"));
            ListViewItem item2 = new ListViewItem("Bracket");
            item2.SubItems.Add(new ListViewItem.ListViewSubItem(item2, "8"));
            listView1.Items.Add(item1);
            listView1.Items.Add(item2);
            
            // Add the ListView to the form.
            this.Controls.Add(listView1);
            listView1.MouseDown += new MouseEventHandler(listView1_MouseDown);
        }

        void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Get the item at the mouse pointer.
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);

            ListViewItem.ListViewSubItem subItem = null;
            
            // Get the subitem 120 pixels to the right.
            if (info != null)
                if (info.Item != null)
                    subItem = info.Item.GetSubItemAt(e.X + 120, e.Y);
            
            // Show the text of the subitem, if found.
            if (subItem != null)
                MessageBox.Show(subItem.Text);
        }