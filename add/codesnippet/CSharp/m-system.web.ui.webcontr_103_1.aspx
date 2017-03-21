            // Create a new ListItemCollection.
            ListItemCollection listBoxData = new ListItemCollection();
            // Add items to the collection.
            listBoxData.Add(new ListItem("apples"));
            listBoxData.Add(new ListItem("bananas"));
            listBoxData.Add(new ListItem("cherries"));
            listBoxData.Add("grapes");
            listBoxData.Add("mangos");
            listBoxData.Add("oranges");
            // Set the ListItemCollection as the data source for ListBox1.
            ListBox1.DataSource = listBoxData;
            ListBox1.DataBind();