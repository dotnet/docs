Imports System.Collections.ObjectModel

Class Window1
    '<SnippetAdd1>
    Public Sub New()
        '</SnippetAdd1>

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim dt As AdventureWorksLT2008DataSet.CustomerDataTable = GetData()

        DG1.DataContext = dt

        DG2.DataContext = dt

        '<SnippetAdd2>
        'Create a new column to add to the DataGrid
        Dim textcol As New DataGridTextColumn()
        'Create a Binding object to define the path to the DataGrid.ItemsSource property 
        'The column inherits its DataContext from the DataGrid, so you don't set the source
        Dim b As New Binding("LastName")
        'Set the properties on the new column
        textcol.Binding = b
        textcol.Header = "Last Name"
        'Add the column to the DataGrid

        DG2.Columns.Add(textcol)
    End Sub
    '</SnippetAdd2>

    Public Function GetData() As AdventureWorksLT2008DataSet.CustomerDataTable
        Dim custadapter As New AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter()
        Dim custdata As New AdventureWorksLT2008DataSet.CustomerDataTable()
        custadapter.Fill(custdata)

        Return custdata
    End Function

    '<SnippetVisible2>
    Private Sub DG1_AutoGeneratingColumn(ByVal sender As Object, ByVal e As DataGridAutoGeneratingColumnEventArgs)
        'Set properties on the columns during auto-generation
        Select Case e.Column.Header.ToString()
            Case "LastName"
                e.Column.CanUserSort = False
                e.Column.Visibility = Visibility.Visible
                Exit Select
            Case "FirstName"
                e.Column.Visibility = Visibility.Visible
                Exit Select
            Case "CompanyName"
                e.Column.Visibility = Visibility.Visible
                Exit Select
            Case "EmailAddress"
                e.Column.Visibility = Visibility.Visible
                Exit Select
            Case Else
                e.Column.Visibility = Visibility.Collapsed
                Exit Select

        End Select
    End Sub

    Private Sub CheckBox_Checked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        'Make each column in the collection visible
        For Each col As DataGridColumn In DG1.Columns
            col.Visibility = Visibility.Visible
        Next
    End Sub

    Private Sub CheckBox_Unchecked(ByVal sender As Object, ByVal e As RoutedEventArgs)
        'Get the columns collection
        Dim columns As ObservableCollection(Of DataGridColumn) = DG1.Columns

        'set the visibility for each column so only 4 columns are visible
        For Each col As DataGridColumn In columns
            Select Case col.Header.ToString()
                Case "LastName"
                    col.Visibility = Visibility.Visible
                    Exit Select
                Case "FirstName"
                    col.Visibility = Visibility.Visible
                    Exit Select
                Case "CompanyName"
                    col.Visibility = Visibility.Visible
                    Exit Select
                Case "EmailAddress"
                    col.Visibility = Visibility.Visible
                    Exit Select
                Case Else
                    col.Visibility = Visibility.Collapsed
                    Exit Select
            End Select

        Next
    End Sub
    '</SnippetVisible2>

    '<SnippetDelete2>
    Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        'Delete the first column whether visible or not
        DG1.Columns.RemoveAt(0)
    End Sub
    '</SnippetDelete2>
End Class
