  void ContactsListView_ItemInserting(Object sender, ListViewInsertEventArgs e)
  {
    // Iterate through the values to verify if they are not empty.
    foreach (DictionaryEntry de in e.Values)
    {
      if (de.Value == null)
      {
        Message.Text = "Cannot insert an empty value.";
        e.Cancel = true;
      }
    }
  }