' <Snippet1>
Public Structure OrderOrderLine
    Implements IEquatable(Of OrderOrderLine)

    Public ReadOnly Property OrderId As Integer
    Public ReadOnly Property OrderLineId As Integer

    Public Sub New(ByVal orderId As Integer, ByVal orderLineId As Integer)
        Me.OrderId = orderId
        Me.OrderLineId = orderLineId
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        Return (TypeOf obj Is OrderOrderLine) AndAlso Equals(DirectCast(obj, OrderOrderLine))
    End Function

    Public Overloads Function Equals(other As OrderOrderLine) As Boolean Implements IEquatable(Of OrderOrderLine).Equals
        Return OrderId = other.OrderId AndAlso
               OrderLineId = other.OrderLineId
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return HashCode.Combine(OrderId, OrderLineId)
    End Function

End Structure

Module Program

    Sub Main(args As String())
        Dim hashSet As HashSet(Of OrderOrderLine) = New HashSet(Of OrderOrderLine)
        hashSet.Add(New OrderOrderLine(1, 1))
        hashSet.Add(New OrderOrderLine(1, 1))
        hashSet.Add(New OrderOrderLine(1, 2))
        Console.WriteLine($"Item count: {hashSet.Count}")
    End Sub

End Module
' The example displays the following output:
' Item count: 2.
' </Snippet1>