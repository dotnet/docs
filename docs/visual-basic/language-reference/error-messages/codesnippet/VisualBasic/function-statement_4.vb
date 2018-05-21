Module Module1

    Sub Main()
        ' In the following function call, calcSum's local variables 
        ' are assigned the following values: args(0) = 4, args(1) = 3, 
        ' and so on. The displayed sum is 10.
        Dim returnedValue As Double = calcSum(4, 3, 2, 1)
        Console.WriteLine("Sum: " & returnedValue)
        ' Parameter args accepts zero or more arguments. The sum 
        ' displayed by the following statements is 0.
        returnedValue = calcSum()
        Console.WriteLine("Sum: " & returnedValue)
    End Sub

    Public Function calcSum(ByVal ParamArray args() As Double) As Double
        calcSum = 0
        If args.Length <= 0 Then Exit Function
        For i As Integer = 0 To UBound(args, 1)
            calcSum += args(i)
        Next i
    End Function

End Module