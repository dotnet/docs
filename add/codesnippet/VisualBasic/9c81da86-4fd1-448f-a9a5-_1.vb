Private Sub UpdateGridUI()
   ' Get the MyDataGridColumnStyle to update.
   ' MyDataGridColumnStyle is a class derived from DataGridColumnStyle.
   Dim myGridColumn As MyDataGridColumnStyle = CType _
   (dataGrid1.TableStyles(0).GridColumnStyles("CompanyName"), _
   MyDataGridColumnStyle)
   ' Call UpdateUI.
   myGridColumn.UpdateUI(myCurrencyManager, 10, "my new value")
End Sub 