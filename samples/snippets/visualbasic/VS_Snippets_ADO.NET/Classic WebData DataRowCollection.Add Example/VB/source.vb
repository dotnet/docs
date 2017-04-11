imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub ShowRows(Byval table As DataTable)
    ' Print the number of rows in the collection.
    Console.WriteLine(table.Rows.Count)

    Dim row  As DataRow
    ' Print the value of columns 1 in each row
    For Each row In table.Rows
        Console.WriteLine(row(1))
    Next
End Sub
 
Private Sub AddRow(ByVal table As DataTable)
    ' Instantiate a new row using the NewRow method.
    Dim newRow As DataRow = table.NewRow()
    ' Insert code to fill the row with values.

    ' Add the row to the DataRowCollection.
    table.Rows.Add(newRow)
End Sub
' </Snippet1>

End Class
