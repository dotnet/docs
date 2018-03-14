Option Explicit On
Option Strict On
Imports System
Imports System.Data
Imports System.Data.Common


Module Module1

    Sub Main()
        DemonstrateRowState()
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub DemonstrateRowState()
        'Run a function to create a DataTable with one column.
        Dim dataTable As DataTable = MakeTable()
        Dim dataRow As DataRow

        ' Create a new DataRow.
        dataRow = dataTable.NewRow()
        ' Detached row.
        Console.WriteLine(String.Format("New Row {0}", dataRow.RowState))

        dataTable.Rows.Add(dataRow)
        ' New row.
        Console.WriteLine(String.Format("AddRow {0}", dataRow.RowState))

        dataTable.AcceptChanges()
        ' Unchanged row.
        Console.WriteLine(String.Format("AcceptChanges {0}", dataRow.RowState))

        dataRow("FirstName") = "Scott"
        ' Modified row.
        Console.WriteLine(String.Format("Modified {0}", dataRow.RowState))

        dataRow.Delete()
        ' Deleted row.
        Console.WriteLine(String.Format("Deleted {0}", dataRow.RowState))
    End Sub

    Private Function MakeTable() As DataTable
        ' Make a simple table with one column.
        Dim dt As New DataTable("dataTable")
        Dim firstName As New DataColumn("FirstName", _
           Type.GetType("System.String"))
        dt.Columns.Add(firstName)
        Return dt
    End Function
    ' </Snippet1>


End Module
