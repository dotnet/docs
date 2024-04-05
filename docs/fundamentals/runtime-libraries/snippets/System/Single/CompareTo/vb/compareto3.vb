' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example2
    Public Sub Main()
        Dim value1 As Single = 16.5457
        Dim value2 As Object = value1 * CSng(3.8899982) / CSng(3.8899982)
        Console.WriteLine("Comparing {0} and {1}: {2}",
                          value1, value2, value1.CompareTo(value2))
        Console.WriteLine()
        Console.WriteLine("Comparing {0:R} and {1:R}: {2}",
                          value1, value2, value1.CompareTo(value2))
    End Sub
End Module
' The example displays the following output:
'       Comparing 16.5457 and 16.5457: -1
'       
'       Comparing 16.5457 and 16.545702: -1
' </Snippet2>

