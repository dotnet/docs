  protected void ContactsListView_ItemCanceling(object sender, ListViewCancelEventArgs e)
  {
    //Check the operation that raised the event
    if (e.CancelMode == ListViewCancelMode.CancelingEdit)
    {
      // The update operation was canceled. Display the 
      // primary key of the item.
      Message.Text = "Update for the ContactID " + 
        ContactsListView.DataKeys[e.ItemIndex].Value.ToString()  + " canceled.";
    }
    else
    {
      Message.Text = "Insert operation canceled."; 
    }
  }