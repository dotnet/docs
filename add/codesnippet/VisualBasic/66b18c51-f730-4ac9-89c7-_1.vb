    Public ReadOnly Property Keys() As ICollection Implements IDictionary.Keys
        Get

            ' Return an array where each item is a key.
            ' Note: Declaring keyArray() to have a size of ItemsInUse - 1
            '       ensures that the array is properly sized, in VB.NET
            '       declaring an array of size N creates an array with
            '       0 through N elements, including N, as opposed to N - 1
            '       which is the default behavior in C# and C++.
            Dim keyArray() As Object = New Object(ItemsInUse - 1) {}
            Dim n As Integer
            For n = 0 To ItemsInUse - 1
                keyArray(n) = items(n).Key
            Next n

            Return keyArray
        End Get
    End Property