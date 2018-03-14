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
    Private Sub DataTableRowChanged()
        Dim custTable As DataTable = New DataTable("Customers")
        ' add columns
        custTable.Columns.Add("id", Type.GetType("System.Int32"))
        custTable.Columns.Add("name", Type.GetType("System.String"))
        custTable.Columns.Add("address", Type.GetType("System.String"))

        ' set PrimaryKey
        custTable.Columns("id").Unique = True
        custTable.PrimaryKey = New DataColumn() {custTable.Columns("id")}

        ' add a RowChanged event handler for the table.
        AddHandler custTable.RowChanged, _
               New DataRowChangeEventHandler(AddressOf Row_Changed)


        ' add ten rows
        Dim id As Integer
        For id = 1 To 10
            custTable.Rows.Add( _
   New Object() {id, String.Format("customer{0}", id), _
            String.Format("address{0}", id)})
        Next

        custTable.AcceptChanges()

        ' change the name column in all the rows
        Dim row As DataRow
        For Each row In custTable.Rows
            row("name") = String.Format("vip{0}", row("id"))
        Next

    End Sub

    Private Sub Row_Changed(ByVal sender As Object, _
    ByVal e As DataRowChangeEventArgs)
        Console.WriteLine("Row_Changed Event: name={0}; action={1}", _
         e.Row("name"), e.Action)
    End Sub
    ' </Snippet1>

End Module
