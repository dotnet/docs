Private Sub EditValue()
   Dim rowtoedit As Integer = 1
   Dim myCurrencyManager As CurrencyManager = _
   CType(Me.BindingContext(ds.Tables("Suppliers")), CurrencyManager)
   myCurrencyManager.Position = rowtoedit
   Dim dgc As DataGridColumnStyle = _
   dataGrid1.TableStyles(0).GridColumnStyles(0)
   dataGrid1.BeginEdit(dgc, rowtoedit)
   ' Insert code to edit the value.
   dataGrid1.EndEdit(dgc, rowtoedit, False)
End Sub 
