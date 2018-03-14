'<Snippet1>
Imports System.Threading

Class Example

    Shared Sub Main()

        For i As Integer = 0 To 4
            Console.WriteLine("Sleep for 2 seconds.")
            Thread.Sleep(2000)
        Next

        Console.WriteLine("Main thread exits.")
    End Sub
End Class

' This example produces the following output:
'
'Sleep for 2 seconds.
'Sleep for 2 seconds.
'Sleep for 2 seconds.
'Sleep for 2 seconds.
'Sleep for 2 seconds.
'Main thread exits.
'</Snippet1>
