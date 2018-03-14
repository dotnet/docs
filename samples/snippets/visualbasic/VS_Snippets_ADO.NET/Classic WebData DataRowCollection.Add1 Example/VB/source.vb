imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub AddRow(ByVal table As DataTable)
    ' Create an array with three elements.
    Dim rowVals(2) As Object
    Dim rowCollection As DataRowCollection = table.Rows
    rowVals(0) = "hello"
    rowVals(1) = "world"
    rowVals(2) = "two"

    ' Add and return the new row.
    Dim row As DataRow = rowCollection.Add(rowVals) 
End Sub
' </Snippet1>

End Class
