'<snippet10>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Class MainWindow
    Inherits Window

    '<snippet11>
    Private nwBindingSource As System.Windows.Forms.BindingSource
    Private nwDataSet As NorthwindDataSet
    Private customersTableAdapter As New NorthwindDataSetTableAdapters.CustomersTableAdapter()
    Private ordersTableAdapter As New NorthwindDataSetTableAdapters.OrdersTableAdapter()
    '</snippet11>

    '<snippet12>
    Public Sub New()
        InitializeComponent()

        ' Create a DataSet for the Customers data.
        Me.nwDataSet = New NorthwindDataSet()
        Me.nwDataSet.DataSetName = "nwDataSet"

        ' Create a BindingSource for the Customers data.
        Me.nwBindingSource = New System.Windows.Forms.BindingSource()
        Me.nwBindingSource.DataMember = "Customers"
        Me.nwBindingSource.DataSource = Me.nwDataSet

    End Sub
    '</snippet12>

    '<snippet13>
    Private Sub Window_Loaded( _
    ByVal sender As Object, _
    ByVal e As RoutedEventArgs)

        ' Fill the Customers table adapter with data.
        Me.customersTableAdapter.ClearBeforeFill = True
        Me.customersTableAdapter.Fill(Me.nwDataSet.Customers)

        ' Fill the Orders table adapter with data.
        Me.ordersTableAdapter.Fill(Me.nwDataSet.Orders)

        ' Assign the BindingSource to 
        ' the data context of the main grid.
        Me.mainGrid.DataContext = Me.nwBindingSource

        ' Assign the BindingSource to 
        ' the data source of the list box.
        Me.listBox1.ItemsSource = Me.nwBindingSource

        ' Because this is a master/details form, the DataGridView
        ' requires the foreign key relating the tables.
        Me.dataGridView1.DataSource = Me.nwBindingSource
        Me.dataGridView1.DataMember = "FK_Orders_Customers"

        ' Handle the currency management aspect of the data models.
        ' Attach an event handler to detect when the current item 
        ' changes via the WPF ListBox. This event handler synchronizes
        ' the list collection with the BindingSource.
        '

        Dim cv As BindingListCollectionView = _
            CollectionViewSource.GetDefaultView(Me.nwBindingSource)

        AddHandler cv.CurrentChanged, AddressOf WPF_CurrentChanged

    End Sub
    '</snippet13>

    '<snippet14>
    ' This event handler updates the current item 
    ' of the data binding.
    Private Sub WPF_CurrentChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim cv As BindingListCollectionView = sender
        Me.nwBindingSource.Position = cv.CurrentPosition
    End Sub
    '</snippet14>

End Class
'</snippet10>