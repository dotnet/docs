' <Snippet3>
Public Class Example
    Public Shared Sub Main()
        ' Define some integers for a division operation.
        Dim values() As Integer = { 10, 7 }

        For Each value In values
            Try 
               Console.WriteLine("{0} divided by 2 is {1}", value, DivideByTwo(value))
            Catch e As ArgumentException
               Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message)
            End Try
            Console.WriteLine()
        Next
    End Sub
    
    Private Shared Function DivideByTwo(ByVal num As Integer) As Integer
        ' If num is an odd number, throw an ArgumentException.
        If (num And 1) = 1 Then
            Throw New ArgumentException(String.Format("{0} is not an even number", num), 
                                      "num")
        End If
        Return num \ 2
    End Function
End Class
' The example displays the following output:
'     10 divided by 2 is 5
'     
'     ArgumentException: 7 is not an even number
'     Parameter name: num
' </Snippet3>
