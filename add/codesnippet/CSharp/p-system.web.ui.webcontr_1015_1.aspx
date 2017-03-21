  protected void ContactsListView_ItemDataBound(object sender, ListViewItemEventArgs e)
  {

    //Verify there is an item being edited.
    if (ContactsListView.EditIndex >= 0)
    {

      //Get the item object.
      ListViewDataItem dataItem = (ListViewDataItem)e.Item;

      // Check for an item in edit mode.
      if (dataItem.DisplayIndex == ContactsListView.EditIndex)
      {

        // Preselect the DropDownList control with the Title value
        // for the current item.

        // Retrieve the underlying data item. In this example
        // the underlying data item is a DataRowView object.        
        DataRowView rowView = (DataRowView)dataItem.DataItem;

        // Retrieve the Title value for the current item. 
        String title = rowView["Title"].ToString();

        // Retrieve the DropDownList control from the current row. 
        DropDownList list = (DropDownList)dataItem.FindControl("TitlesList");

        // Find the ListItem object in the DropDownList control with the 
        // title value and select the item.
        ListItem item = list.Items.FindByText(title);
        list.SelectedIndex = list.Items.IndexOf(item);
                        
      }
    }
  }