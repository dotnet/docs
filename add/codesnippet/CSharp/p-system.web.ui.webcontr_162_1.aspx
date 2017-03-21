  protected void DeleteButton_Click(object sender, EventArgs e)
  {
    //Check if an item is selected to delete it.
    if (ContactsListView.SelectedIndex >= 0)
      ContactsListView.DeleteItem(ContactsListView.SelectedIndex);
    else
      Message.Text = "No contact was selected.";
  }