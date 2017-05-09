'<Snippet1>
Public Module Calculator

    Public Function Decrement(ByVal input As Integer) As Integer

        If (input = Integer.MinValue) Then _
            Throw New ArgumentOutOfRangeException("input", "input must be greater than Int32.MinValue")

        input = input - 1
        Return input

    End Function

End Module
'</Snippet1>