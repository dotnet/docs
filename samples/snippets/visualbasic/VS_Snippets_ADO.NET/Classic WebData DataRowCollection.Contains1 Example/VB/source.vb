imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid
Protected label1 As Label

' <Snippet1>
 Private Sub ContainsArray()
    ' This example assumes that the DataTable object contains two
    ' DataColumn objects designated as primary keys.
    ' The table has two primary key columns.
    Dim arrKeyVals(1) As Object
    Dim table As DataTable = CType(DataGrid1.DataSource, DataTable)
    Dim rowCollection As DataRowCollection = table.Rows
    arrKeyVals(0) = "Hello"
    arrKeyVals(1) = "World"
    label1.Text = rowCollection.Contains(arrKeyVals).ToString()
 End Sub
' </Snippet1>

End Class
