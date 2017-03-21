  void ContactsListView_SelectedIndexChanged(Object sender, EventArgs e)
  {
    if (ContactsListView.SelectedIndex >= 0)
      ViewState["SelectedKey"] = ContactsListView.SelectedValue;
    else
      ViewState["SelectedKey"] = null;
  }
  
  void ContactsListView_DataBound(Object sender, EventArgs e)
  {
    for (int i = 0; i < ContactsListView.Items.Count; i++)
    {
      // Ignore values that cannot be cast as integer.
      try
      {
          if ((int)ContactsListView.DataKeys[i].Value == (int)ViewState["SelectedKey"])
              ContactsListView.SelectedIndex = i;
      }
      catch { }
    }
  }