Imports System.Data

Class Window1

    Private clipboard As String = "Fake Company Name"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim dt As AdventureWorksLT2008DataSet.CustomerDataTable = GetData()

        DG1.DataContext = dt

    End Sub

    Public Function GetData() As AdventureWorksLT2008DataSet.CustomerDataTable
        Dim custadapter As New AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter()
        Dim custdata As New AdventureWorksLT2008DataSet.CustomerDataTable()
        custadapter.Fill(custdata)

        Return custdata
    End Function



    '<Snippet2>
    Private Sub DG1_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)
        'Get the newly selected rows
        Dim selectedrows As System.Collections.IList = e.AddedItems

        'Get the object associated with each newly selected row
        For Each row As DataRowView In selectedrows
            Dim editable As Boolean = row.DataView.AllowEdit
            If editable = True Then
                'Copy a new value into the CompanyName, where clipboard contains a string
                Dim cr As AdventureWorksLT2008DataSet.CustomerRow = DirectCast(row.Row, AdventureWorksLT2008DataSet.CustomerRow)
                cr.BeginEdit()
                cr.CompanyName = clipboard
                cr.EndEdit()
            End If
        Next
    End Sub
    '</Snippet2>

    '<Snippet3>
    Private Sub DG1_SelectedCellsChanged(ByVal sender As Object, ByVal e As SelectedCellsChangedEventArgs)
        'Get the newly selected cells
        Dim selectedcells As IList(Of DataGridCellInfo) = e.AddedCells

        'Get the value of each newly selected cell
        For Each di As DataGridCellInfo In selectedcells
            'Cast the DataGridCellInfo.Item to the source object type
            'In this case the ItemsSource is a DataTable and individual items are DataRows
            Dim dvr As DataRowView = DirectCast(di.Item, DataRowView)

            'Clear values for all newly selected cells
            Dim cr As AdventureWorksLT2008DataSet.CustomerRow = DirectCast(dvr.Row, AdventureWorksLT2008DataSet.CustomerRow)
            cr.BeginEdit()
            cr.SetField(di.Column.DisplayIndex, "")

            cr.EndEdit()
        Next
    End Sub
    '</Snippet3>

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
