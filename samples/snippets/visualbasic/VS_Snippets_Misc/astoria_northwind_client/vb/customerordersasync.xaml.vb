'<snippetWpfDataBindingAsync>
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports NorthwindClient.Northwind
Imports System.Data.Services.Client
Imports System.Windows.Threading

'/ <summary>
'/ Interaction logic for OrderItems.xaml
'/ </summary>
Partial Public Class CustomerOrdersAsync
    Inherits Window

    Dim context As NorthwindEntities
    Private Shared customerBinding As DataServiceCollection(Of Customer)
    Private Const customerCountry As String = "Germany"

    ' Change this URI to the service URI for your implementation.
    Private Const svcUri As String = "http://localhost:12345/Northwind.svc/"

    ' Define a persisted result.
    Private Shared currentResult As IAsyncResult

    Delegate Sub DispatcherDelegate()

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Initialize the context.
        context = New NorthwindEntities(New Uri(svcUri))

        ' Define the delegate to callback into the process
        Dim callback As AsyncCallback = AddressOf OnQueryCompleted

        ' Define a query that returns customers and orders for a specific country.
        Dim query As DataServiceQuery(Of Customer) = _
        context.Customers.Expand("Orders") _
        .AddQueryOption("filter", "Country eq '" + customerCountry + "'")

        Try
            ' Begin asynchronously saving changes Imports the 
            ' specified handler and query object state.
            query.BeginExecute(callback, query)

        Catch ex As DataServiceClientException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub OnQueryCompleted(ByVal result As IAsyncResult)
        ' Persist the query result for the delegate.
        currentResult = result

        ' Use the Dispatcher to ensure that the 
        ' asynchronous call returns in the correct thread.
        Dispatcher.BeginInvoke(New DispatcherDelegate(AddressOf QueryCompletedByDispatcher))
    End Sub
    ' Handle the query callback.        
    Private Sub QueryCompletedByDispatcher()
        Try
            ' Get the original query back from the result.
            Dim query = CType(currentResult.AsyncState, DataServiceQuery(Of Customer))

            ' Instantiate the binding collection imports the 
            ' results of the query execution.
            customerBinding = New DataServiceCollection(Of Customer)( _
                        query.EndExecute(currentResult))

            ' Bind the collection to the root element of the UI.
            Me.LayoutRoot.DataContext = customerBinding
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub saveChangesButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Define the delegate to callback into the process
        Dim callback As AsyncCallback = AddressOf OnSaveChangesCompleted

        Try
            ' Start the asynchronous call to save changes.
            context.BeginSaveChanges(callback, Nothing)
        Catch ex As DataServiceClientException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
    Private Sub OnSaveChangesCompleted(ByVal result As IAsyncResult)
        ' Persist the query result for the delegate.
        currentResult = result

        ' Use the Dispatcher to ensure that the operation returns in the UI thread.
        Me.Dispatcher.BeginInvoke(New DispatcherDelegate(AddressOf SaveChangesCompletedByDispatcher))
        ' Handle the query callback.
    End Sub
    Private Sub SaveChangesCompletedByDispatcher()
        Try
            ' Complete the save changes operation.
            context.EndSaveChanges(currentResult)
        Catch ex As DataServiceRequestException
            MessageBox.Show(ex.ToString())
        End Try
    End Sub
End Class
'</snippetWpfDataBindingAsync>
