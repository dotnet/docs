    Sub Main()
        For Each number In Power(2, 8)
            Console.Write(number & " ")
        Next
        ' Output: 2 4 8 16 32 64 128 256
        Console.ReadKey()
    End Sub

    Private Iterator Function Power(
    ByVal base As Integer, ByVal highExponent As Integer) _
    As System.Collections.Generic.IEnumerable(Of Integer)

        Dim result = 1

        For counter = 1 To highExponent
            result = result * base
            Yield result
        Next
    End Function