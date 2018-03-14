Option Explicit On
Option Strict On
Imports System
Imports System.Data


Module Module1

    Sub Main()
        DemonstrateRowState()
        Console.ReadLine()

    End Sub

    ' <Snippet1>
    Private Sub DemonstrateRowState()
        Dim i As Integer

        ' Create a DataTable with one column.
        Dim dataTable As New DataTable("dataTable")
        Dim dataColumn As New DataColumn("dataColumn")
        dataTable.Columns.Add(dataColumn)

        ' Add ten rows.
        Dim dataRow As DataRow
        For i = 0 To 9
            dataRow = dataTable.NewRow()
            dataRow("dataColumn") = "item " + i.ToString()
            dataTable.Rows.Add(dataRow)
        Next i
        dataTable.AcceptChanges()

        ' Create a DataView with the table.
        Dim dataView As New DataView(dataTable)

        ' Change one row's value:
        dataTable.Rows(1)("dataColumn") = "Hello"

        ' Add one row:
        dataRow = dataTable.NewRow()
        dataRow("dataColumn") = "World"
        dataTable.Rows.Add(dataRow)

        ' Set the RowStateFilter to display only Added and modified rows.
        dataView.RowStateFilter = _
        DataViewRowState.Added Or DataViewRowState.ModifiedCurrent

        ' Print those rows. Output = "Hello" "World";
        PrintView(dataView, "ModifiedCurrent and Added")

        ' Set filter to display on originals of modified rows.
        dataView.RowStateFilter = DataViewRowState.ModifiedOriginal
        PrintView(dataView, "ModifiedOriginal")

        ' Delete three rows.
        dataTable.Rows(1).Delete()
        dataTable.Rows(2).Delete()
        dataTable.Rows(3).Delete()

        ' Set the RowStateFilter to display only Added and modified rows.
        dataView.RowStateFilter = DataViewRowState.Deleted
        PrintView(dataView, "Deleted")

        'Set filter to display only current.
        dataView.RowStateFilter = DataViewRowState.CurrentRows
        PrintView(dataView, "Current")

        ' Set filter to display only unchanged rows.
        dataView.RowStateFilter = DataViewRowState.Unchanged
        PrintView(dataView, "Unchanged")

        ' Set filter to display only original rows.
        dataView.RowStateFilter = DataViewRowState.OriginalRows
        PrintView(dataView, "OriginalRows")
    End Sub

    Private Sub PrintView(ByVal dataView As DataView, ByVal label As String)
        Console.WriteLine(ControlChars.Cr + label)
        Dim i As Integer
        For i = 0 To dataView.Count - 1
            Console.WriteLine(dataView(i)("dataColumn"))
        Next i
    End Sub
    ' </Snippet1>

End Module
