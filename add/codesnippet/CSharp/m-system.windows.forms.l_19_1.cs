    // Sets myListView to the groups created for the specified column.
    private void SetGroups(int column)
    {
        // Remove the current groups.
        myListView.Groups.Clear();

        // Retrieve the hash table corresponding to the column.
        Hashtable groups = (Hashtable)groupTables[column];

        // Copy the groups for the column to an array.
        ListViewGroup[] groupsArray = new ListViewGroup[groups.Count];
        groups.Values.CopyTo(groupsArray, 0);

        // Sort the groups and add them to myListView.
        Array.Sort(groupsArray, new ListViewGroupSorter(myListView.Sorting));
        myListView.Groups.AddRange(groupsArray);

        // Iterate through the items in myListView, assigning each 
        // one to the appropriate group.
        foreach (ListViewItem item in myListView.Items)
        {
            // Retrieve the subitem text corresponding to the column.
            string subItemText = item.SubItems[column].Text;

            // For the Title column, use only the first letter.
            if (column == 0) 
            {
                subItemText = subItemText.Substring(0, 1);
            }

            // Assign the item to the matching group.
            item.Group = (ListViewGroup)groups[subItemText];
        }
    }