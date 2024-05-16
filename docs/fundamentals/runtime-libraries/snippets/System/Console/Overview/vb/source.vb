' <Snippet1>
Public Class Example4
    Public Shared Sub Main()
        Console.Write("Hello ")
        Console.WriteLine("World!")
        Console.Write("Enter your name: ")
        Dim name As String = Console.ReadLine()
        Console.Write("Good day, ")
        Console.Write(name)
        Console.WriteLine("!")
    End Sub
End Class
' The example displays output similar to the following:
'        Hello World!
'        Enter your name: James
'        Good day, James!
' </Snippet1>
