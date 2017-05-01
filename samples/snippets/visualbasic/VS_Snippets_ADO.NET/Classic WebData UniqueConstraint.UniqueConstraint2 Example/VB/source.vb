Option Strict On
Option Explicit On

Imports System.Data

Module Module1

    Sub Main()
        MakeTableWithUniqueConstraint()
        Console.ReadLine()
    End Sub

    ' <Snippet1>
    Private Sub MakeTableWithUniqueConstraint()
        ' Create a DataTable with 2 DataColumns.
        Dim dataTable As New DataTable("dataTable")
        Dim idColumn As New DataColumn( _
            "ID", System.Type.GetType("System.Int32"))
        Dim nameColumn As New DataColumn( _
            "Name", System.Type.GetType("System.String"))
        dataTable.Columns.Add(idColumn)
        dataTable.Columns.Add(nameColumn)

        ' Run procedure to create a constraint.
        AddUniqueConstraint(dataTable)

        ' Add one row to the table.
        Dim dataRow As DataRow
        dataRow = dataTable.NewRow()
        dataRow("ID") = 1
        dataRow("Name") = "John"
        dataTable.Rows.Add(dataRow)

        ' Display the constraint name.
        Console.WriteLine(dataTable.Constraints(0).ConstraintName)

        ' Try to add an identical row,
        ' which throws an exception.
        Try
            dataRow = dataTable.NewRow()
            dataRow("ID") = 1
            dataRow("Name") = "John"
            dataTable.Rows.Add(dataRow)
        Catch ex As Exception
            Console.WriteLine("Exception Type: {0}", ex.GetType())
            Console.WriteLine("Exception Message: {0}", ex.Message)
        End Try
    End Sub

    Private Sub AddUniqueConstraint(ByVal dataTable As DataTable)
        ' Create the DataColumn array.
        Dim dataColumns(1) As DataColumn
        dataColumns(0) = dataTable.Columns("ID")
        dataColumns(1) = dataTable.Columns("Name")

        ' Create the constraint on both columns.
        Dim uniqueConstraint As UniqueConstraint = _
            New UniqueConstraint("idNameConstraint", dataColumns)
        dataTable.Constraints.Add(uniqueConstraint)
    End Sub
    ' </Snippet1>

End Module
