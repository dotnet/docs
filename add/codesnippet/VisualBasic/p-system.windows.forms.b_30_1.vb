Private Sub ReturnBindingManagerBase()
   ' Get the BindingManagerBase for a DataView. 
   Dim bmCustomers As BindingManagerBase = _
      Me.BindingContext(myDataView)

   ' Get the BindingManagerBase for an ArrayList.
   Dim bmOrders As BindingManagerBase = _
      Me.BindingContext(myArrayList)

   ' Get the BindingManagerBase for a TextBox control.
   Dim baseArray As BindingManagerBase = _
      Me.BindingContext(Text1.DataBindings(0).DataSource)
End Sub
