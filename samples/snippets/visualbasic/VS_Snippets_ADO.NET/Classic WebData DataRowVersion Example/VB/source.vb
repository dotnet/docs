Option Explicit On
Option Strict On
Imports System
Imports System.Data


Module Module1

    Sub Main()
        CheckVersionBeforeAccept()
        Console.ReadLine()

    End Sub
    ' <Snippet1>
    Private Sub CheckVersionBeforeAccept()
        'Run a function to create a DataTable with one column.
        Dim dataTable As DataTable = MakeTable()

        Dim dataRow As DataRow = dataTable.NewRow()
        dataRow("FirstName") = "Marcy"
        dataTable.Rows.Add(dataRow)

        dataRow.BeginEdit()
        ' Edit data but keep the same value.
        dataRow(0) = "Marcy"
        ' Uncomment the following line to add a new value.
        ' dataRow(0) = "Richard"
        Console.WriteLine(String.Format("FirstName {0}", dataRow(0)))

        ' Compare the proposed version with the current.
        If dataRow.HasVersion(DataRowVersion.Proposed) Then
            If dataRow(0, DataRowVersion.Current) Is dataRow(0, DataRowVersion.Proposed) Then
                Console.WriteLine("The original and the proposed are the same.")
                dataRow.CancelEdit()
            Else
                dataRow.AcceptChanges()
                Console.WriteLine("The original and the proposed are different.")
            End If
        End If
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
