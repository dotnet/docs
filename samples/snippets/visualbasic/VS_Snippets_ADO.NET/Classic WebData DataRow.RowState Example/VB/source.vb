imports System
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet

' <Snippet1>
Private Sub DemonstrateRowState()
    ' Run a function to create a DataTable with one column.
    Dim table As DataTable = MakeTable()
    Dim row As DataRow 
 
    ' Create a new DataRow.
    row = table.NewRow()
    ' Detached row.
    Console.WriteLine("New Row " & row.RowState)
 
    table.Rows.Add(row)
    ' New row.
    Console.WriteLine("AddRow " & row.RowState)
 
    table.AcceptChanges()
    ' Unchanged row.
    Console.WriteLine("AcceptChanges " & row.RowState)
 
    row("FirstName") = "Scott"
    ' Modified row.
    Console.WriteLine("Modified " & row.RowState)
 
    row.Delete()
    ' Deleted row.
    Console.WriteLine("Deleted " & row.RowState)
 End Sub
 
 Private Function MakeTable() As DataTable
    ' Make a simple table with one column.
    Dim table As DataTable = New DataTable("table")
    Dim dcFirstName As DataColumn = New DataColumn( _
        "FirstName", Type.GetType("System.String"))
    table.Columns.Add(dcFirstName)
    MakeTable = table
 End Function
 ' </Snippet1>

End Class
