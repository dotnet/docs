  Sub ProductsListView_ItemEditing(ByVal sender As Object, ByVal e As ListViewEditEventArgs)
    Dim item As ListViewItem = ProductsListView.Items(e.NewEditIndex)
    Dim dateLabel As Label = CType(item.FindControl("DiscontinuedDateLabel"), Label)
      
    If String.IsNullOrEmpty(dateLabel.Text) Then _
      Return
      
    'Verify if the item is discontinued.
    Dim discontinuedDate As DateTime = DateTime.Parse(dateLabel.Text)
    If discontinuedDate < DateTime.Now Then
      Message.Text = "You cannot edit a discontinued item."
      e.Cancel = True
      ProductsListView.SelectedIndex = -1
    End If
  End Sub