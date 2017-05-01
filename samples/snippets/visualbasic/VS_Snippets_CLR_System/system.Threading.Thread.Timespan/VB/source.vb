' <Snippet1>
Imports System.Threading

Public Module Test
    Dim waitTime As New TimeSpan(0, 0, 1)

    Public Sub Main() 
        Dim newThread As New Thread(AddressOf Work)
        newThread.Start()

        If newThread.Join(waitTime + waitTime) Then
            Console.WriteLine("New thread terminated.")
        Else
            Console.WriteLine("Join timed out.")
        End If
    End Sub

    Private Sub Work()
        Thread.Sleep(waitTime)
    End Sub
End Module
' The example displays the following output:
'       New thread terminated.
' </Snippet1>