' <Snippet1>
Public Class App
    Public Shared Sub Main()
        ' ArgumentException is not thrown because 10 is an even number.
        Console.WriteLine("10 divided by 2 is {0}", DivideByTwo(10))
        Try 
            ' ArgumentException is thrown because 7 is not an even number.
            Console.WriteLine("7 divided by 2 is {0}", DivideByTwo(7))
        Catch Ex As ArgumentException
            ' Show the user that 7 cannot be divided by 2.
            Console.WriteLine("7 is not divided by 2 integrally.")
        End Try
    End Sub
    
    Private Shared Function DivideByTwo(ByVal num As Integer) As Integer
        ' If num is an odd number, throw an ArgumentException.
        If ((num And 1)  _
                    = 1) Then
            Throw New ArgumentException("Number must be even", "num")
        End If
        Return (num / 2)
    End Function
End Class
' This code produces the following output.
' 
' 10 divided by 2 is 5
' 7 is not divided by 2 integrally.
' </Snippet1>
