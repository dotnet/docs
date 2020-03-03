Imports System.Collections.Generic
Imports System.Linq
Imports System.Collections.ObjectModel

'<Snippet2>
Class Window1
    Public Shared FreezeColumnCommand As New RoutedUICommand()

    Public Sub New()
        InitializeComponent()

        'GetData connects to the database and returns the data in a table.
        Dim dt As AdventureWorksLT2008DataSet.SalesOrderDetailDataTable = GetData()

        DG1.DataContext = dt
    End Sub
    '</Snippet2>

    Public Function GetData() As AdventureWorksLT2008DataSet.SalesOrderDetailDataTable
        Dim custadapter As New AdventureWorksLT2008DataSetTableAdapters.SalesOrderDetailTableAdapter()
        Dim custdata As New AdventureWorksLT2008DataSet.SalesOrderDetailDataTable()
        custadapter.Fill(custdata)

        Return custdata
    End Function

    '<Snippet3>
    Private Sub CommandBinding_Executed(ByVal sender As Object, ByVal e As ExecutedRoutedEventArgs)
        'Get the column header that started the command and move that column left to freeze it.
        Dim header As System.Windows.Controls.Primitives.DataGridColumnHeader = DirectCast(e.OriginalSource, System.Windows.Controls.Primitives.DataGridColumnHeader)
        If header.Column.IsFrozen = True Then
            Exit Sub
        Else
            header.Column.DisplayIndex = DG1.FrozenColumnCount
            DG1.FrozenColumnCount += 1


        End If
    End Sub
    '</Snippet3>
End Class
