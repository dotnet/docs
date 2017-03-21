  protected void ContactsListView_ItemCreated(object sender, ListViewItemEventArgs e)
  {
    // Retrieve the current item.
    ListViewItem item = e.Item;

    // Verify if the item is a data item.
    if (item.ItemType == ListViewItemType.DataItem)
    {
      // Get the EmailAddressLabel Label control in the item.
      Label EmailAddressLabel = (Label)item.FindControl("EmailAddressLabel");
      
      // Display the e-mail address in italics.
      EmailAddressLabel.Font.Italic = true;
    }
  }