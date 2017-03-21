  void ProductsListView_ItemEditing(Object sender, ListViewEditEventArgs e)
  {
    ListViewItem item = ProductsListView.Items[e.NewEditIndex];
    Label dateLabel = (Label)item.FindControl("DiscontinuedDateLabel");
    
    if (String.IsNullOrEmpty(dateLabel.Text))
      return;
    
    //Verify if the item is discontinued.
    DateTime discontinuedDate = DateTime.Parse(dateLabel.Text);
    if (discontinuedDate < DateTime.Now)
    {
      Message.Text = "You cannot edit a discontinued item.";
      e.Cancel = true;
      ProductsListView.SelectedIndex = -1;
    }       
  }