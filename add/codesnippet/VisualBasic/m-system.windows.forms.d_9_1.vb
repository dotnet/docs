Public Class Form1: Inherits Form

Protected dataGrid1 As DataGrid


Private Sub SetNullText()
   Dim dgeCol As MyGridColumn
   ' Assumes a column named Status exists.
   dgeCol = CType(DataGrid1.TableStyles("Customers"). _
   GridColumnStyles("Status"), MyGridColumn)
   dgeCol.EnterNull
End Sub

End Class

Public Class MyGridColumn
Inherits DataGridTextBoxColumn
   Public Sub EnterNull()
      me.EnterNullValue
   End Sub
End Class
      