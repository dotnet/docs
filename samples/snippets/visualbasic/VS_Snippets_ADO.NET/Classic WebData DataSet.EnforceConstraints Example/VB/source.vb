imports System
imports System.Xml
imports System.Data
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub DemonstrateEnforceConstraints()
    ' Create a DataSet with one table, one column and 
    ' a UniqueConstraint.
    Dim dataSet As DataSet = New DataSet("dataSet")
    Dim table As DataTable = New DataTable("table")
    Dim column As DataColumn = New DataColumn("col1")
    column.Unique = True
    table.Columns.Add(column)
    dataSet.Tables.Add(table)
    Console.WriteLine("constraints.count: " _
        & table.Constraints.Count)

    ' add five rows.
    Dim row As DataRow
    Dim i As Integer
    For i = 0 To 4
       row = table.NewRow()
       row("col1") = i
       table.Rows.Add(row)
    Next
    table.AcceptChanges()
     
    dataSet.EnforceConstraints = False
    ' Change the values of all rows to 1.
    Dim thisRow As DataRow
    For Each thisRow In table.rows
       thisRow("col1") = 1
    Next
 
    Try
        dataSet.EnforceConstraints = True
    Catch e As System.Data.ConstraintException
	    ' Process exception and return.
        Console.WriteLine("Exception of type {0} occurred.", _
            e.GetType().ToString())
    End Try
End Sub
' </Snippet1>

End Class
