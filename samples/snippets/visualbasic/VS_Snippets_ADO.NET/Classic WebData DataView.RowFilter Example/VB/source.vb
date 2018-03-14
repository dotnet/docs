' <Snippet1>
Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected Text1 As TextBox
    Protected DataSet1 As DataSet

    Public Shared Sub Main()
        DemostrateDataView()
    End Sub

    Private Shared Sub DemostrateDataView()
        ' Create a DataTable with one column
        Dim dt As New DataTable("MyTable")
        Dim column As New DataColumn("Col", GetType(Integer))
        dt.Columns.Add(column)

        ' Add 5 rows on Added state
        For i As Integer = 0 To 4
            Dim row As DataRow = dt.NewRow()
            row("Col") = i
            dt.Rows.Add(row)
        Next

        ' Add 5 rows on Unchanged state
        For i As Integer = 5 To 9
            Dim row As DataRow = dt.NewRow()
            row("Col") = i
            dt.Rows.Add(row)
            ' Calling AcceptChanges will make the DataRowVersion change from Added to Unchanged in this case
            row.AcceptChanges()
        Next

        ' Create a DataView
        Dim dv As New DataView(dt)

        Console.WriteLine("Print unsorted, unfiltered DataView")
        PrintDataView(dv)

        ' Changing the Sort order to descending
        dv.Sort = "Col DESC"

        Console.WriteLine("Print sorted DataView. Sort = 'Col DESC'")
        PrintDataView(dv)

        ' Filter by an expression. Filter all rows where column 'Col' have values greater or equal than 3
        dv.RowFilter = "Col < 3"

        Console.WriteLine("Print sorted and Filtered DataView by RowFilter. RowFilter = 'Col > 3'")
        PrintDataView(dv)

        ' Removing Sort and RpwFilter to ilustrate RowStateFilter. DataView should contain all 10 rows back in the original order
        dv.Sort = [String].Empty
        dv.RowFilter = [String].Empty

        ' Show only Unchanged rows or last 5 rows
        dv.RowStateFilter = DataViewRowState.Unchanged

        Console.WriteLine("Print Filtered DataView by RowState. RowStateFilter =  DataViewRowState.Unchanged")
        PrintDataView(dv)
    End Sub

    Private Shared Sub PrintDataView(dv As DataView)
        ' Printing first DataRowView to demo that the row in the first index of the DataView changes depending on sort and filters
        Console.WriteLine("First DataRowView value is '{0}'", dv(0)("Col"))

        ' Printing all DataRowViews
        For Each drv As DataRowView In dv
            Console.WriteLine(vbTab & " {0}", drv("Col"))
        Next
    End Sub
End Class
' </Snippet1>