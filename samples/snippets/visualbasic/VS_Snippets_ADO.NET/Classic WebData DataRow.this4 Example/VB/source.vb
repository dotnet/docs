imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form
Protected DataGrid1 As DataGrid

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub DataGrid1_Click _
    (ByVal sender As System.Object, ByVal e As System.EventArgs)
    
    ' Set the current row using the RowNumber property 
    ' of the CurrentCell.
    Dim currentRow As DataRow = _
        CType(DataGrid1.DataSource, DataTable). _
        Rows(DataGrid1.CurrentCell.RowNumber)

    ' Print the current value of the column named "FirstName."
    Console.WriteLine(currentRow("FirstName", _
        DataRowVersion.Current).ToString())
End Sub
' </Snippet1>

End Class
