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
    Private Sub DataTableRowDeleted()
        Dim customerTable As DataTable = New DataTable("Customers")
        ' add columns
        customerTable.Columns.Add("id", Type.GetType("System.Int32"))
        customerTable.Columns.Add("name", Type.GetType("System.String"))
        customerTable.Columns.Add("address", Type.GetType("System.String"))

        ' set PrimaryKey
        customerTable.Columns("id").Unique = True
        customerTable.PrimaryKey = New DataColumn() {customerTable.Columns("id")}

        ' add a RowDeleted event handler for the table.
        AddHandler customerTable.RowDeleted, New _
               DataRowChangeEventHandler(AddressOf Row_Deleted)


        ' add ten rows
        Dim id As Integer
        For id = 1 To 10
            customerTable.Rows.Add( _
                New Object() {id, String.Format("customer{0}", id), _
            String.Format("address{0}", id)})
        Next

        customerTable.AcceptChanges()

        ' Delete all the rows
        Dim row As DataRow
        For Each row In customerTable.Rows
            row.Delete()
        Next
    End Sub

    Private Sub Row_Deleted(ByVal sender As Object, _
    ByVal e As DataRowChangeEventArgs)
        Console.WriteLine("Row_Deleted Event: name={0}; action={1}", _
         e.Row("name", DataRowVersion.Original), e.Action)
    End Sub
    ' </Snippet1>
End Module
