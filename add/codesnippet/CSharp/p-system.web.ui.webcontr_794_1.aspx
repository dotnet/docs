  void ContactsListView_ItemInserted(Object sender, ListViewInsertedEventArgs e)
  {
    if (e.Exception != null)
    {
      if (e.AffectedRows == 0)
      {
        e.KeepInInsertMode = true;
        Message.Text = "An exception occurred inserting the new Contact. " +
          "Please verify your values and try again.";
      }
      else
        Message.Text = "An exception occurred inserting the new Contact. " +
          "Please verify the values in the newly inserted item.";

      e.ExceptionHandled = true;
    }
  }