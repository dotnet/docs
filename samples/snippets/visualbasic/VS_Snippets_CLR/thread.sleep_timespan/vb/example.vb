'<Snippet1>
Imports System.Threading

Class Example

    Shared Sub Main()

        Dim interval As New TimeSpan(0, 0, 2)

        For i As Integer = 0 To 4
            Console.WriteLine("Sleep for 2 seconds.")
            Thread.Sleep(interval)
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
