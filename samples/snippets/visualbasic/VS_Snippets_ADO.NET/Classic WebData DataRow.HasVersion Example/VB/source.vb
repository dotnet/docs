imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid
Protected Edit1 As TextBox

' <Snippet1>
Private Sub CheckVersionBeforeAccept()
    ' Assuming the DataGrid is bound to a DataTable.
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim row As DataRow = table.Rows(DataGrid1.CurrentCell.RowNumber)
    row.BeginEdit
    row(1) = Edit1.Text
    If row.HasVersion(datarowversion.Proposed) Then
       If row(1, DataRowVersion.Current) Is _
            row(1, DataRowversion.Proposed) Then
          Console.WriteLine("The original and the proposed are the same")
          row.CancelEdit
          Exit Sub
       Else
          row.AcceptChanges
       End If
    Else
       Console.WriteLine("No new values proposed")
    End If
End Sub
' </Snippet1>

End Class
