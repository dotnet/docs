'<Snippet00>
'<Snippet01>
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private masterDataGridView As New DataGridView()
    Private masterBindingSource As New BindingSource()
    Private detailsDataGridView As New DataGridView()
    Private detailsBindingSource As New BindingSource()

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    ' Initializes the form.
    Public Sub New()

        masterDataGridView.Dock = DockStyle.Fill
        detailsDataGridView.Dock = DockStyle.Fill

        Dim splitContainer1 As New SplitContainer()
        splitContainer1.Dock = DockStyle.Fill
        splitContainer1.Orientation = Orientation.Horizontal
        splitContainer1.Panel1.Controls.Add(masterDataGridView)
        splitContainer1.Panel2.Controls.Add(detailsDataGridView)

        Me.Controls.Add(splitContainer1)
        Me.Text = "DataGridView master/detail demo"

    End Sub
    '</Snippet01>

    '<Snippet10>
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Load

        ' Bind the DataGridView controls to the BindingSource
        ' components and load the data from the database.
        masterDataGridView.DataSource = masterBindingSource
        detailsDataGridView.DataSource = detailsBindingSource
        GetData()

        ' Resize the master DataGridView columns to fit the newly loaded data.
        masterDataGridView.AutoResizeColumns()

        ' Configure the details DataGridView so that its columns automatically
        ' adjust their widths when the data changes.
        detailsDataGridView.AutoSizeColumnsMode = _
            DataGridViewAutoSizeColumnsMode.AllCells

    End Sub
    '</Snippet10>

    '<Snippet20>
    Private Sub GetData()

        Try
            ' Specify a connection string. Replace the given value with a 
            ' valid connection string for a Northwind SQL Server sample
            ' database accessible to your system.
            Dim connectionString As String = _
                "Integrated Security=SSPI;Persist Security Info=False;" & _
                "Initial Catalog=Northwind;Data Source=localhost"
            Dim connection As New SqlConnection(connectionString)

            ' Create a DataSet.
            Dim data As New DataSet()
            data.Locale = System.Globalization.CultureInfo.InvariantCulture

            ' Add data from the Customers table to the DataSet.
            Dim masterDataAdapter As _
                New SqlDataAdapter("select * from Customers", connection)
            masterDataAdapter.Fill(data, "Customers")

            ' Add data from the Orders table to the DataSet.
            Dim detailsDataAdapter As _
                New SqlDataAdapter("select * from Orders", connection)
            detailsDataAdapter.Fill(data, "Orders")

            ' Establish a relationship between the two tables.
            Dim relation As New DataRelation("CustomersOrders", _
                data.Tables("Customers").Columns("CustomerID"), _
                data.Tables("Orders").Columns("CustomerID"))
            data.Relations.Add(relation)

            ' Bind the master data connector to the Customers table.
            masterBindingSource.DataSource = data
            masterBindingSource.DataMember = "Customers"

            ' Bind the details data connector to the master data connector,
            ' using the DataRelation name to filter the information in the 
            ' details table based on the current row in the master table. 
            detailsBindingSource.DataSource = masterBindingSource
            detailsBindingSource.DataMember = "CustomersOrders"
        Catch ex As SqlException
            MessageBox.Show("To run this example, replace the value of the " & _
                "connectionString variable with a connection string that is " & _
                "valid for your system.")
        End Try

    End Sub
    '</Snippet20>

    '<Snippet02>
End Class
'</Snippet02>
'</Snippet00>