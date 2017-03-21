Private Sub SetTextBoxBgColor()
   Dim myGridTextBox As DataGridTextBox
   Dim myColumnTextColumn As DataGridTextBoxColumn
   ' Assumes there is a DataGridTextBoxColumn 
   ' already created in  the DataGrid control.
   myColumnTextColumn = CType(DataGrid1.TableStyles("Customers"). _
   GridColumnStyles("FirstName"), DataGridTextBoxColumn)
   myGridTextBox = CType(myColumnTextColumn.TextBox, _
   DataGridTextBox)
   ' Change the background color.
   myGridTextBox.BackColor = System.Drawing.Color.Red
End Sub