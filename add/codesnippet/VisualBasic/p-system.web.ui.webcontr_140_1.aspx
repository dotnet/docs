  Sub ProductsListView_SelectedIndexChanging(ByVal sender As Object, ByVal e As ListViewSelectEventArgs)

    Dim item As ListViewItem = CType(ProductsListView.Items(e.NewSelectedIndex), ListViewItem)  
    Dim l As Label = CType(item.FindControl("DiscontinuedDateLabel"), Label)

    If String.IsNullOrEmpty(l.Text) Then
      Return
    End If

    Dim discontinued As DateTime = DateTime.Parse(l.Text)
    If discontinued < DateTime.Now Then      
      Message.Text = "You cannot select a discontinued item."
      e.Cancel = True
    End If
  End Sub