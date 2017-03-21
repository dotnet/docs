    // Creates a Hashtable object with one entry for each unique
    // subitem value (or initial letter for the parent item)
    // in the specified column.
    private Hashtable CreateGroupsTable(int column)
    {
        // Create a Hashtable object.
        Hashtable groups = new Hashtable();

        // Iterate through the items in myListView.
        foreach (ListViewItem item in myListView.Items)
        {
            // Retrieve the text value for the column.
            string subItemText = item.SubItems[column].Text;

            // Use the initial letter instead if it is the first column.
            if (column == 0) 
            {
                subItemText = subItemText.Substring(0, 1);
            }

            // If the groups table does not already contain a group
            // for the subItemText value, add a new group using the 
            // subItemText value for the group header and Hashtable key.
            if (!groups.Contains(subItemText))
            {
                groups.Add( subItemText, new ListViewGroup(subItemText, 
                    HorizontalAlignment.Left) );
            }
        }

        // Return the Hashtable object.
        return groups;
    }