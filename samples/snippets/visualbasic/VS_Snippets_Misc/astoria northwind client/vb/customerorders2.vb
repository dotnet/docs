Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Imports System.Data.Services.Client
Imports NorthwindClient.Northwind

Partial Public Class CustomerOrders2
    Inherits Form

    Private context As NorthwindEntities
    Private Const svcUri As String = "http://localhost:12345/Northwind.svc/"
    Sub New()
        InitializeComponent()
    End Sub
    Private Sub CustomerOrders_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Initialize the context for the data service.
        context = New NorthwindEntities(New Uri(svcUri))

        '<snippetCustomersOrders2Binding>
        ' Create a new collection that contains all customers and related orders.
        Dim trackedCustomers As DataServiceCollection(Of Customer) = _
                New DataServiceCollection(Of Customer)(context.Customers.Expand("Orders"))
        '</snippetCustomersOrders2Binding>

        Try
            customersBindingSource.DataSource = trackedCustomers
        Catch ex As DataServiceQueryException
            MessageBox.Show("The query could not be completed:\n" + ex.ToString())
        Catch ex As InvalidOperationException
            MessageBox.Show("The following error occurred:\n" + ex.ToString())
        End Try
    End Sub
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        Try
            context.SaveChanges()
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
