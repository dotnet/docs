    Public ReadOnly Property Values() As ICollection Implements IDictionary.Values
        Get
            ' Return an array where each item is a value.
            Dim valueArray() As Object = New Object(ItemsInUse - 1) {}
            Dim n As Integer
            For n = 0 To ItemsInUse - 1
                valueArray(n) = items(n).Value
            Next n

            Return valueArray
        End Get
    End Property