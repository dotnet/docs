    ' Explicitly specify a delegate type.
    Delegate Function MultipleOfTen(ByVal num As Integer) As Boolean

    ' This function matches the delegate type.
    Function IsMultipleOfTen(ByVal num As Integer) As Boolean
        Return num Mod 10 = 0
    End Function

    ' This method takes an input parameter of the delegate type. 
    ' The checkDelegate parameter could also be of 
    ' type Func(Of Integer, Boolean).
    Sub CheckForMultipleOfTen(ByVal values As Integer(),
                              ByRef checkDelegate As MultipleOfTen)
        For Each value In values
            If checkDelegate(value) Then
                Console.WriteLine(value & " is a multiple of ten.")
            Else
                Console.WriteLine(value & " is not a multiple of ten.")
            End If
        Next
    End Sub

    ' This method shows both an explicitly defined delegate and a
    ' lambda expression passed to the same input parameter.
    Sub CheckValues()
        Dim values = {5, 10, 11, 20, 40, 30, 100, 3}
        CheckForMultipleOfTen(values, AddressOf IsMultipleOfTen)
        CheckForMultipleOfTen(values, Function(num) num Mod 10 = 0)
    End Sub