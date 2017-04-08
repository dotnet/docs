imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
 Private Sub MakeDataTableAndDisplay()
    ' Create new DataTable.
    Dim table As New DataTable
 
    ' Declare DataColumn and DataRow variables.
    Dim column As DataColumn
    Dim row As DataRow
 
    ' Create new DataColumn, set DataType, ColumnName 
    ' and add to DataTable.    
    column = New DataColumn
    column.DataType = System.Type.GetType("System.Int32")
    column.ColumnName = "id"
    table.Columns.Add(column)
 
    ' Create second column.
    column = New DataColumn
    column.DataType = Type.GetType("System.String")
    column.ColumnName = "item"
    table.Columns.Add(column)
 
    ' Create new DataRow objects and add to DataTable.    
    Dim i As Integer
    For i = 0 To 10
       row = table.NewRow
       row("id") = i
       row("item") = "item " & i
       table.Rows.Add(row)
    Next i
 
    ' Set to DataGrid.DataSource property to the table.
    DataGrid1.DataSource = table
 End Sub
 ' </Snippet1>

End Class
