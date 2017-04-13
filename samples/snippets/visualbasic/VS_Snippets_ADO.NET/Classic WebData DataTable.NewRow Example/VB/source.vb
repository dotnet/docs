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
    ' Create new DataTable and DataSource objects.
    Dim table As DataTable = New DataTable()

    ' Declare DataColumn and DataRow variables.
    Dim column As DataColumn 
    Dim row As DataRow 
    Dim view As DataView 

    ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
    column = New DataColumn()
    column.DataType = System.Type.GetType("System.Int32")
    column.ColumnName = "id"
    table.Columns.Add(column)
 
    ' Create second column.
    column = New DataColumn()
    column.DataType = Type.GetType("System.String")
    column.ColumnName = "item"
    table.Columns.Add(column)
 
    ' Create new DataRow objects and add to DataTable.    
    Dim i As Integer
    For i = 0 to 9 
       row = table.NewRow()
       row("id") = i
       row("item") = "item " & i
       table.Rows.Add(row)
    Next
    ' Create a DataView using the DataTable.
    view = New DataView(table)

    ' Set a DataGrid control's DataSource to the DataView.
    DataGrid1.DataSource = view
End Sub
' </Snippet1>

End Class
