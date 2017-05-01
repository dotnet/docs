Imports System
Imports System.Net
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Web

<ServiceBehavior(InstanceContextMode:=InstanceContextMode.Single)> _
Public Class Service
    Implements ICustomerCollection

    Dim counter As Integer = 0
    Dim customers As New Hashtable()
    Dim writeLock As New Object()


    Public Function AddCustomer(ByVal customer As Customer) As Customer Implements ICustomerCollection.AddCustomer
        SyncLock (writeLock)
            ' <Snippet0>
            counter = counter + 1

            Dim match As UriTemplateMatch = WebOperationContext.Current.IncomingRequest.UriTemplateMatch
            Dim template As New UriTemplate("{id}")

            customer.Uri = template.BindByPosition(match.BaseUri, counter.ToString())
            customers(counter.ToString()) = customer
            WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(customer.Uri)
            ' </Snippet0>
            Return customer
        End SyncLock
    End Function

    Public Sub DeleteCustomer(ByVal id As String) Implements ICustomerCollection.DeleteCustomer
        If Not customers.ContainsKey(id) Then
            WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound()
        Else
            SyncLock (writeLock)
                customers.Remove(id)
            End SyncLock
        End If
    End Sub

    Public Function GetCustomer(ByVal id As String) As Customer Implements ICustomerCollection.GetCustomer
        Dim c As Customer = Me.customers(id)

        If c Is Nothing Then
            WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound()
            Return Nothing
        End If
        Return c
    End Function

    Public Function GetCustomers() As System.Collections.Generic.List(Of Customer) Implements ICustomerCollection.GetCustomers
        Dim list As New List(Of Customer)()
        SyncLock (writeLock)
            For Each c As Customer In Me.customers.Values
                list.Add(c)
            Next
        End SyncLock
        Return list
    End Function

    Public Function UpdateCustomer(ByVal id As String, ByVal newCustomer As Customer) As Customer Implements ICustomerCollection.UpdateCustomer
        If Not customers.ContainsKey(id) Then
            WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound()
            Return Nothing
        End If

        SyncLock (writeLock)
            customers(id) = newCustomer
        End SyncLock

        Return newCustomer
    End Function
End Class
        
