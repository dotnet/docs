Module Module2

    Sub Main()
        ' The following line will print Success, because 4 is even.
        testResult(4, Function(num) num Mod 2 = 0)
        ' The following line will print Failure, because 5 is not > 10.
        testResult(5, Function(num) num > 10)
    End Sub

    ' Sub testResult takes two arguments, an integer value and a 
    ' delegate function that takes an integer as input and returns
    ' a boolean. 
    ' If the function returns True for the integer argument, Success
    ' is displayed.
    ' If the function returns False for the integer argument, Failure
    ' is displayed.
    Sub testResult(ByVal value As Integer, ByVal fun As Func(Of Integer, Boolean))
        If fun(value) Then
            Console.WriteLine("Success")
        Else
            Console.WriteLine("Failure")
        End If
    End Sub

End Module