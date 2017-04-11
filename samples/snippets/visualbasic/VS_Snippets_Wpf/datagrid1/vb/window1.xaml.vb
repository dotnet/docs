Imports System.Data
Imports System.Configuration

Class Window1
    Dim dt As New DataTable()
    Dim myData As New AdventureWorksLT2008DataSet()
    'CustomerGrid.ItemsSource = myData.Customer;
    Dim custDataTable As New AdventureWorksLT2008DataSet.CustomerDataTable()


    Dim custTableAdapter As New AdventureWorksLT2008DataSetTableAdapters.CustomerTableAdapter()



    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        custTableAdapter.Fill(custDataTable)

        '<Snippet2>
        'Set the DataGrid's DataContext to be a filled DataTable
        CustomerGrid.DataContext = custDataTable
        '</Snippet2>
    End Sub
End Class
