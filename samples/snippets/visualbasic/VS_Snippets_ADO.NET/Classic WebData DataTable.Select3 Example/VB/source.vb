Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Sub GetRowsByFilter()

        Dim customerTable As DataTable = New DataTable("Customers")

        ' Add columns
        customerTable.Columns.Add("id", GetType(Integer))
        customerTable.Columns.Add("name", GetType(String))

        ' Set PrimaryKey
        customerTable.Columns("id").Unique = True
        customerTable.PrimaryKey = New DataColumn() _
            {customerTable.Columns("id")}

        ' add ten rows
        Dim id As Integer
        For id = 1 To 10
            customerTable.Rows.Add( _
            New Object() {id, String.Format("customer{0}", id)})
        Next id
        customerTable.AcceptChanges()

        ' add another ten rows
        For id = 11 To 20
            customerTable.Rows.Add( _
            New Object() {id, String.Format("customer{0}", id)})
        Next id

        Dim expression As String
        Dim sortOrder As String

        expression = "id > 5"
        ' Sort descending by CompanyName column.
        sortOrder = "name DESC"

        ' Use the Select method to find all rows matching the filter.
        Dim foundRows As DataRow() = _
            customerTable.Select(expression, sortOrder, _
            DataViewRowState.Added)

        PrintRows(foundRows, "filtered rows")

        foundRows = customerTable.Select()
        PrintRows(foundRows, "all rows")
    End Sub

    Private Sub PrintRows(ByVal rows() As DataRow, ByVal label As String)
        Console.WriteLine("\n{0}", label)
        If rows.Length <= 0 Then
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

End Module
