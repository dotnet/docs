  void ProductsListView_SelectedIndexChanging(Object sender, ListViewSelectEventArgs e)
  {
    ListViewItem item = (ListViewItem)ProductsListView.Items[e.NewSelectedIndex];
    Label l = (Label)item.FindControl("DiscontinuedDateLabel");

    if (String.IsNullOrEmpty(l.Text))
    {
      return;
    }

    DateTime discontinued = DateTime.Parse(l.Text);
    if (discontinued < DateTime.Now)
    {
      Message.Text = "You cannot select a discontinued item.";
      e.Cancel = true;
    }
  }