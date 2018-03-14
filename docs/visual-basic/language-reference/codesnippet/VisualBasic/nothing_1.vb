Module Module1

    Sub Main()
        Dim ts As TestStruct
        Dim i As Integer
        Dim b As Boolean

        ' The following statement sets ts.Name to Nothing and ts.Number to 0.
        ts = Nothing

        ' The following statements set i to 0 and b to False.
        i = Nothing
        b = Nothing

        Console.WriteLine("ts.Name: " & ts.Name)
        Console.WriteLine("ts.Number: " & ts.Number)
        Console.WriteLine("i: " & i)
        Console.WriteLine("b: " & b)

        Console.ReadKey()
    End Sub

    Public Structure TestStruct
        Public Name As String
        Public Number As Integer
    End Structure
End Module