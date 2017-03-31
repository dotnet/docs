Option Explicit On
Option Strict On

Imports System
Imports System.Data

Module Module1

    Sub Main()
        DemonstrateRowVersion()
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub DemonstrateRowVersion()
        Dim i As Integer
        ' Create a DataTable with one column.
        Dim table As New DataTable("Table")
        Dim column As New DataColumn("Column")
        table.Columns.Add(column)

        ' Add ten rows.
        Dim row As DataRow
        For i = 0 To 9
            row = table.NewRow()
            row("Column") = "item " + i.ToString()
            table.Rows.Add(row)
        Next i
        table.AcceptChanges()

        ' Create a DataView with the table.
        Dim view As New DataView(table)

        ' Change one row's value:
        table.Rows(1)("Column") = "Hello"

        ' Add one row:
        row = table.NewRow()
        row("Column") = "World"
        table.Rows.Add(row)

        ' Set the RowStateFilter to display only added and modified rows.
        view.RowStateFilter = _
           DataViewRowState.Added Or DataViewRowState.ModifiedCurrent

        ' Print those rows. Output includes "Hello" and "World".
        PrintView(view, "ModifiedCurrent and Added")

        ' Set filter to display only originals of modified rows.
        view.RowStateFilter = DataViewRowState.ModifiedOriginal
        PrintView(view, "ModifiedOriginal")

        ' Delete three rows.
        table.Rows(1).Delete()
        table.Rows(2).Delete()
        table.Rows(3).Delete()

        ' Set the RowStateFilter to display only deleted rows.
        view.RowStateFilter = DataViewRowState.Deleted
        PrintView(view, "Deleted")

        ' Set filter to display only current rows.
        view.RowStateFilter = DataViewRowState.CurrentRows
        PrintView(view, "Current")

        ' Set filter to display only unchanged rows.
        view.RowStateFilter = DataViewRowState.Unchanged
        PrintView(view, "Unchanged")

        ' Set filter to display only original rows.
        ' Current values of unmodified rows are also returned.
        view.RowStateFilter = DataViewRowState.OriginalRows
        PrintView(view, "OriginalRows")
    End Sub

    Private Sub PrintView(ByVal view As DataView, ByVal label As String)
        Console.WriteLine(ControlChars.Cr + label)
        Dim i As Integer
        For i = 0 To view.Count - 1
            Console.WriteLine(view(i)("Column"))
            Console.WriteLine("DataRowView.RowVersion: {0}", _
                view(i).RowVersion)
        Next i
    End Sub
    ' </Snippet1>

End Module
