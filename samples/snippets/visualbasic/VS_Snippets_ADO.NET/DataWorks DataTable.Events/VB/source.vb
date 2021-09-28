Option Explicit On
Option Strict On

Imports System.Data

Module TestVB
    Sub Main()
        DataTableEvents()
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub DataTableEvents()

        Dim table As New DataTable("Customers")
        ' Add two columns, id and name.
        table.Columns.Add("id", Type.GetType("System.Int32"))
        table.Columns.Add("name", Type.GetType("System.String"))

        ' Set the primary key.
        table.Columns("id").Unique = True
        table.PrimaryKey = New DataColumn() {table.Columns("id")}

        ' Add a RowChanged event handler.
        AddHandler table.RowChanged, _
               New DataRowChangeEventHandler(AddressOf Row_Changed)

        ' Add a RowChanging event handler.
        AddHandler table.RowChanging, _
               New DataRowChangeEventHandler(AddressOf Row_Changing)

        ' Add a RowDeleted event handler.
        AddHandler table.RowDeleted, New _
               DataRowChangeEventHandler(AddressOf Row_Deleted)

        ' Add a RowDeleting event handler.
        AddHandler table.RowDeleting, New _
               DataRowChangeEventHandler(AddressOf Row_Deleting)

        ' Add a ColumnChanged event handler.
        AddHandler table.ColumnChanged, _
               New DataColumnChangeEventHandler(AddressOf Column_Changed)

        ' Add a ColumnChanging event handler for the table.
        AddHandler table.ColumnChanging, New _
               DataColumnChangeEventHandler(AddressOf Column_Changing)

        ' Add a TableNewRow event handler.
        AddHandler table.TableNewRow, New _
               DataTableNewRowEventHandler(AddressOf Table_NewRow)

        ' Add a TableCleared event handler.
        AddHandler table.TableCleared, New _
               DataTableClearEventHandler(AddressOf Table_Cleared)

        ' Add a TableClearing event handler.
        AddHandler table.TableClearing, New _
               DataTableClearEventHandler(AddressOf Table_Clearing)

        ' Add a customer.
        Dim row As DataRow = table.NewRow()
        row("id") = 1
        row("name") = "Customer1"
        table.Rows.Add(row)

        table.AcceptChanges()

        ' Change the customer name.
        table.Rows(0).Item("name") = "ChangedCustomer1"

        ' Delete the row.
        table.Rows(0).Delete()

        ' Clear the table.
        table.Clear()
    End Sub


    Private Sub Row_Changed(ByVal sender As Object, _
        ByVal e As DataRowChangeEventArgs)
        Console.WriteLine("Row_Changed Event: name={0}; action={1}", _
         e.Row("name"), e.Action)
    End Sub

    Private Sub Row_Changing(ByVal sender As Object, _
        ByVal e As DataRowChangeEventArgs)
        Console.WriteLine("Row_Changing Event: name={0}; action={1}", _
         e.Row("name"), e.Action)
    End Sub

    Private Sub Row_Deleted(ByVal sender As Object, _
        ByVal e As DataRowChangeEventArgs)
        Console.WriteLine("Row_Deleted Event: name={0}; action={1}", _
         e.Row("name", DataRowVersion.Original), e.Action)
    End Sub

    Private Sub Row_Deleting(ByVal sender As Object, _
        ByVal e As DataRowChangeEventArgs)
        Console.WriteLine("Row_Deleting Event: name={0}; action={1}", _
           e.Row("name"), e.Action)
    End Sub

    Private Sub Column_Changed(ByVal sender As Object, _
        ByVal e As DataColumnChangeEventArgs)
        Console.WriteLine("Column_Changed Event: ColumnName={0}; RowState={1}", _
           e.Column.ColumnName, e.Row.RowState)
    End Sub

    Private Sub Column_Changing(ByVal sender As Object, _
        ByVal e As DataColumnChangeEventArgs)
        Console.WriteLine("Column_Changing Event: ColumnName={0}; RowState={1}", _
           e.Column.ColumnName, e.Row.RowState)
    End Sub

    Private Sub Table_NewRow(ByVal sender As Object, _
    ByVal e As DataTableNewRowEventArgs)
        Console.WriteLine("Table_NewRow Event: RowState={0}", _
           e.Row.RowState.ToString())
    End Sub

    Private Sub Table_Cleared(ByVal sender As Object, _
        ByVal e As DataTableClearEventArgs)
        Console.WriteLine("Table_Cleared Event: TableName={0}; Rows={1}", _
           e.TableName, e.Table.Rows.Count.ToString())
    End Sub

    Private Sub Table_Clearing(ByVal sender As Object, _
        ByVal e As DataTableClearEventArgs)
        Console.WriteLine("Table_Clearing Event: TableName={0}; Rows={1}", _
           e.TableName, e.Table.Rows.Count.ToString())
    End Sub
    ' </Snippet1>
End Module
