  void ContactsListView_ItemUpdating(Object sender, ListViewUpdateEventArgs e)
  {
    // Cancel the update operation if any of the fields is empty
    // or null.
    foreach (DictionaryEntry de in e.NewValues)
    {
      // Check if the value is null or empty.
      if (de.Value == null || de.Value.ToString().Trim().Length == 0)
      {
        Message.Text = "Cannot set a field to an empty value.";
        e.Cancel = true;
      }
    }
    
    // Convert the e-mail address to lowercase.
    String emailValue = e.NewValues["EmailAddress"].ToString();
    e.NewValues["EmailAddress"] = emailValue.ToLower();

  }