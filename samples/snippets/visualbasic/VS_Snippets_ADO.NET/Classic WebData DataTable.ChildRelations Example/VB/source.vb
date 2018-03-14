imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Public Sub GetChildRowsFromDataRelation()
    ' For each row in the table, get the child rows using the
    ' ChildRelations. For each item in the array, print the value
    ' of each column.
    Dim table As DataTable = CreateDataSet().Tables("Customers")

    Dim childRows() As DataRow
    Dim relation as DataRelation
    Dim row as DataRow
    For Each  relation In table.ChildRelations
        For Each row In table.Rows
            PrintRowValues(new DataRow() {row}, "Parent Row")
            childRows = row.GetChildRows(relation)
            ' Print values of rows.
            PrintRowValues(childRows, "child rows")
        Next row
    Next relation
End Sub

Public Function CreateDataSet() As DataSet
    ' create a DataSet with one table, two columns
    Dim dataSet As DataSet
    dataSet = new DataSet()

    ' create Customer table
    Dim table As DataTable
    table = new DataTable("Customers")

    dataSet.Tables.Add(table)
    table.Columns.Add("customerId", _
        GetType(Integer)).AutoIncrement = true
    table.Columns.Add("name", GetType(String))
    table.PrimaryKey = new DataColumn() _
        { table.Columns("customerId") }

    ' create Orders table
    table = new DataTable("Orders")
    dataSet.Tables.Add(table)
    table.Columns.Add("orderId", GetType(Integer)).AutoIncrement = true
    table.Columns.Add("customerId", GetType(Integer))
    table.Columns.Add("amount", GetType(Double))
    table.PrimaryKey = new DataColumn() { table.Columns("orderId") }

    ' create relation
    dataSet.Relations.Add(dataSet.Tables("Customers").Columns("customerId"), _
        dataSet.Tables("Orders").Columns("customerId"))
	
    ' populate the tables
    Dim orderId As Integer = 1
    Dim customerId As Integer
    Dim i As Integer
    For customerId = 1 To 10
        ' add customer record
        dataSet.Tables("Customers").Rows.Add( _
            new object() { customerId, _
            string.Format("customer{0}", customerId) })
		
        ' add 5 order records for each customer

        For i = 1 To 5
            dataSet.Tables("Orders").Rows.Add( _
                new object() { orderId, customerId, orderId * 10 })
	    
	    orderId = orderId+1 
	Next
    Next

    CreateDataSet = dataSet
End Function

private sub PrintRowValues(rows() As DataRow, label As String)
    Console.WriteLine("\n{0}", label)
    If rows.Length <= 0
        Console.WriteLine("no rows found")
        Exit Sub
    End If

    Dim row As DataRow
    Dim column As DataColumn

    For Each row In rows
        For Each column In row.Table.Columns
            Console.Write("\table {0}", row(column))
        Next column
        Console.WriteLine()
    Next row
End Sub
' </Snippet1>

End Class
