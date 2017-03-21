  protected void PreferredCheckBox_CheckedChanged(object sender, EventArgs e)
  {
    // Gets the CheckBox object that fired the event.
    CheckBox chkBox = (CheckBox) sender;

    // Gets the item that contains the CheckBox object. 
    ListViewDataItem item = (ListViewDataItem) chkBox.Parent.Parent;
    
    // Update the database with the changes.
    VendorsListView.UpdateItem(item.DisplayIndex, false);
  }