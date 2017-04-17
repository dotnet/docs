imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub DemonstrateDataView()
    ' Create one DataTable with one column.
    Dim table As DataTable = New DataTable("table")
    Dim colItem As DataColumn = New DataColumn("item", _
        Type.GetType("System.String"))
    table.Columns.Add(colItem)

    ' Add five items.
    Dim NewRow As DataRow
    Dim i As Integer
    For i = 0 To 4
    
    NewRow = table.NewRow()
    NewRow("item") = "Item " & i
    table.Rows.Add(NewRow)
    Next
    table.AcceptChanges()

    ' Create two DataView objects with the same table.
    Dim firstView As DataView = New DataView(table)
    Dim secondView As DataView = New DataView(table)
    
    ' Change the values in the table.
    table.Rows(0)("item") = "cat"
    table.Rows(1)("item") = "dog"
    
    ' Print current table values.
    PrintTableOrView(table, "Current Values in Table")
        
    ' Set first DataView to show only modified versions of original rows.
    firstView.RowStateFilter = DataViewRowState.ModifiedOriginal

    ' Print values.    
    PrintTableOrView(firstView, "First DataView: ModifiedOriginal")

    ' Add one New row to the second view.
    Dim rowView As DataRowView
    rowView = secondView.AddNew()
    rowView("item") = "fish"
    ' Set second DataView to show modified versions of 
    ' current rows, or New rows.
    secondView.RowStateFilter = DataViewRowState.ModifiedCurrent _
        Or DataViewRowState.Added
    ' Print modified and Added rows.
    PrintTableOrView(secondView, _
        "Second DataView: ModifiedCurrent or Added")
End Sub
    
Overloads Private Sub PrintTableOrView( _
    ByVal view As DataView, ByVal label As String)
    Console.WriteLine(label)
    Dim i As Integer
    For i = 0 To view.count - 1
    
    Console.WriteLine(view(i)("item"))
    Next
    Console.WriteLine()
End Sub
    
Overloads Private Sub PrintTableOrView( _
    ByVal table As DataTable, ByVal label As String)
    Console.WriteLine(label)
    Dim i As Integer
    For i = 0 To table.Rows.Count - 1
    Console.WriteLine(table.Rows(i)("item"))
    Next
    Console.WriteLine()
End Sub
' </Snippet1>

End Class
