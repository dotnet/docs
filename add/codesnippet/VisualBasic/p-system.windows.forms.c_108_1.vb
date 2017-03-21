Private Sub Grid_Navigate(sender As Object, e As NavigateEventArgs)
   If e.Forward Then
      Dim ds As DataSet = CType(grid.DataSource, DataSet)
      Dim cm As CurrencyManager = _
      CType(BindingContext(ds,"Customers.CustOrders"), CurrencyManager)
      ' Cast the IList to a DataView to set the AllowNew property.
      Dim dv As DataView = CType(cm.List, DataView)
      dv.AllowNew = false
   End If
End Sub