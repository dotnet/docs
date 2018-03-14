' Thread Synchronization
' 413e1f28a2c54eec8338aa43e7982ff4

' <Snippet16>
Imports System.Threading

Module Module1
    Dim autoEvent As AutoResetEvent

    Sub DoWork()
        Console.WriteLine("   worker thread started, now waiting on event...")
        autoEvent.WaitOne()
        Console.WriteLine("   worker thread reactivated, now exiting...")
    End Sub

    Sub Main()
        autoEvent = New AutoResetEvent(False)

        Console.WriteLine("main thread starting worker thread...")
        Dim t As New Thread(AddressOf DoWork)
        t.Start()

        Console.WriteLine("main thread sleeping for 1 second...")
        Thread.Sleep(1000)

        Console.WriteLine("main thread signaling worker thread...")
        autoEvent.Set()
    End Sub
End Module
' </Snippet16>
