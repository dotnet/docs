Option Strict On
Imports System.Collections
Imports System.Collections.Generic
'<Snippet2>
Imports System.Runtime.CompilerServices

Module Module1

    <Extension()>
    Sub Add(ByVal genericList As List(Of Customer),
            ByVal id As Integer,
            ByVal name As String,
            ByVal orders As OrderCollection)

        genericList.Add(New Customer(id, name, orders))
    End Sub
End Module
'</Snippet2>

Module Module2
    Sub Main()
        '<Snippet3>
        Dim customerList = New List(Of Customer) From
          {
            {1, "John Rodman", New OrderCollection From {{9, 1, #6/12/2008#},
                                                         {8, 1, #6/11/2008#},
                                                         {5, 1, #5/1/2008#}}},
            {2, "Ariane Berthier", New OrderCollection From {{2, 2, #1/18/2008#},
                                                             {4, 2, #3/8/2008#},
                                                             {6, 2, #3/18/2008#},
                                                             {7, 2, #5/14/2008#},
                                                             {5, 2, #4/4/2008#}}},
             {3, "Brian Perry", New OrderCollection From {{1, 3, #1/15/2008#},
                                                          {3, 3, #3/8/2008#}}}
          }
        '</Snippet3>
    End Sub
End Module

'<Snippet4>
Public Class Customer
    Public Property Id As Integer
    Public Property Name As String
    Public Property Orders As OrderCollection

    Public Sub New(ByVal id As Integer, ByVal name As String, ByVal orders As OrderCollection)
        Me.Id = id
        Me.Name = name
        Me.Orders = orders
    End Sub
End Class

Public Class Order
    Public Property Id As Integer
    Public Property CustomerId As Integer
    Public Property OrderDate As DateTime

    Public Sub New(ByVal id As Integer,
                   ByVal customerId As Integer,
                   ByVal orderDate As DateTime)
        Me.Id = id
        Me.CustomerId = customerId
        Me.OrderDate = orderDate
    End Sub
End Class
'</Snippet4>

'<Snippet1>
Public Class OrderCollection
    Implements IEnumerable(Of Order)

    Dim items As New List(Of Order)

    Public Property Item(ByVal index As Integer) As Order
        Get
            Return CType(Me(index), Order)
        End Get
        Set(ByVal value As Order)
            items(index) = value
        End Set
    End Property

    Public Sub Add(ByVal id As Integer, ByVal customerID As Integer, ByVal orderDate As DateTime)
        items.Add(New Order(id, customerID, orderDate))
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of Order) Implements IEnumerable(Of Order).GetEnumerator
        Return items.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return Me.GetEnumerator()
    End Function
End Class
'</Snippet1>
