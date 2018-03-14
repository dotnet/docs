Option Explicit On
Option Strict On
Imports system
Imports system.data

Module Module1

    Sub Main()
        'Run a function to create a DataTable with one column.
        Dim dataTable As DataTable = MakeTable()
        GetColumnMapping(dataTable)
        Console.ReadLine()

    End Sub

    ' <Snippet1>
    Private Sub GetColumnMapping(ByVal dataTable As DataTable)
        Dim dataColumn As DataColumn
        For Each dataColumn In dataTable.Columns
            Console.WriteLine(dataColumn.ColumnMapping.ToString())
        Next dataColumn
    End Sub
    ' </Snippet1>


    Private Function MakeTable() As DataTable
        ' Make a simple table with one column.
        Dim dt As New DataTable("dataTable")
        Dim firstName As New DataColumn("FirstName", _
           Type.GetType("System.String"))
        dt.Columns.Add(firstName)
        Return dt
    End Function

End Module
