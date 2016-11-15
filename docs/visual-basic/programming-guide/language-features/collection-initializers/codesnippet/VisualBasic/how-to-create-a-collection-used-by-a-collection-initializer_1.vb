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