' <Snippet1>
Imports System
Imports System.Threading

Public Class WaitOne

    Shared autoEvent As New AutoResetEvent(False)

    <MTAThread> _
    Shared Sub Main()
        Console.WriteLine("Main starting.")

        ThreadPool.QueueUserWorkItem(AddressOf WorkMethod, autoEvent)

        ' Wait for work method to signal.
        If autoEvent.WaitOne(New TimeSpan(0, 0, 1), False) Then
            Console.WriteLine("Work method signaled.")
        Else
            Console.WriteLine("Timed out waiting for work " & _
                "method to signal.")
        End If

        Console.WriteLine("Main ending.")
    End Sub

    Shared Sub WorkMethod(stateInfo As Object) 
        Console.WriteLine("Work starting.")

        ' Simulate time spent working.
        Thread.Sleep(New Random().Next(100, 2000))

        ' Signal that work is finished.
        Console.WriteLine("Work ending.")
        CType(stateInfo, AutoResetEvent).Set()
    End Sub

End Class
' </Snippet1>

