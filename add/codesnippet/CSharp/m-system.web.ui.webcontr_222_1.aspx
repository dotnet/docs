      // Copy the items in the ListItemCollection to an array before 
      // deleting them.     
      ListItem[] myListItemArray = new ListItem[ListBox1.Items.Count];
      ListBox1.Items.CopyTo(myListItemArray, 0);
      
      // Delete all the items from the ListBox.
      ListBox1.Items.Clear();
      DeleteLabel.Text = "<b>All items in the ListBox were deleted successfully." 
          + "</b><br /><b>The deleted items are:";
      String listResults="";
          foreach(ListItem myItem in myListItemArray)
          {
              listResults = listResults + myItem.Text + "<br />";
          }
      ResultsLabel.Text = listResults;