Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

'<snippetCustomersOrdersUsing>
Imports System.Data.Services.Client
Imports NorthwindClient.Northwind

'</snippetCustomersOrdersUsing>

Partial Public Class CustomerOrders
    Inherits Form
    '<snippetCustomersOrdersDefinition>
    Private context As NorthwindEntities
    Private trackedCustomers As DataServiceCollection(Of Customer)
    Private Const customerCountry As String = "Germany"
    Private Const svcUri As String = "http:'localhost:12345/Northwind.svc/"
    '</snippetCustomersOrdersDefinition>

    Sub New()
        InitializeComponent()
    End Sub

    Private Sub CustomerOrders_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        '<snippetCustomersOrdersDataBinding>
        ' Initialize the context for the data service.
        context = New NorthwindEntities(New Uri(svcUri))
        Try
            ' Create a LINQ query that returns customers with related orders.
            Dim customerQuery = From cust In context.Customers.Expand("Orders") _
                                Where cust.Country = customerCountry _
                                Select cust

            '<snippetCustomersOrdersDataBindingSpecific>
            ' Create a new collection for binding based on the LINQ query.
            trackedCustomers = New DataServiceCollection(Of Customer)(customerQuery)

            'Bind the Customers combobox to the collection.
            customersComboBox.DisplayMember = "CustomerID"
            customersComboBox.DataSource = trackedCustomers
            '</snippetCustomersOrdersDataBindingSpecific>
        Catch ex As DataServiceQueryException
            MessageBox.Show("The query could not be completed:\n" + ex.ToString())
        Catch ex As InvalidOperationException
            MessageBox.Show("The following error occurred:\n" + ex.ToString())
            '</snippetCustomersOrdersDataBinding>
        End Try
    End Sub
    Private Sub customersComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles customersComboBox.SelectedIndexChanged

        ' Get the selected customer.
        Dim selectedCustomer As Customer = CType(Me.customersComboBox.SelectedItem, Customer)

        ' Bind the grid to the related Orders collection.
        ordersDataGridView.DataSource = selectedCustomer.Orders
    End Sub
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            context.SaveChanges()
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
