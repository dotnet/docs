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