    ' Use the enumeration flags to indicate that this method exposes  
    ' synchronization and external threading.
    <HostProtectionAttribute(Synchronization := True, _
        ExternalThreading := True)> _
    Private Shared Sub StartThread()
        Dim t As New Thread(New ThreadStart(AddressOf WatchFileEvents))

        ' Start the new thread. On a uniprocessor, the thread is not given 
        ' any processor time until the main thread yields the processor.  
        t.Start()

        ' Give the new thread a chance to execute.
        Thread.Sleep(1000)
    End Sub 'StartThread