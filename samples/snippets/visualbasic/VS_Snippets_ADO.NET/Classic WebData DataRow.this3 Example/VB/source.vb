imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid
Protected label1 As Label

' <Snippet1>
Private Sub DataGrid1_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs)
    
    ' Set the current row using the RowNumber property of the CurrentCell.
    Dim currentRow As DataRow = CType(DataGrid1.DataSource, DataTable). _
       Rows(DataGrid1.CurrentCell.RowNumber)

    ' Get the value of the column 1 in the DataTable.
    label1.Text = currentRow(1, DataRowVersion.Current).ToString()
End Sub
' </Snippet1>

End Class
