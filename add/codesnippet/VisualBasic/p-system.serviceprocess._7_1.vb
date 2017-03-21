    ' Start the service.
    Protected Overrides Sub OnStart(ByVal args() As String) 
        ' Start a separate thread that does the actual work.
        If workerThread Is Nothing OrElse(workerThread.ThreadState And System.Threading.ThreadState.Unstarted Or System.Threading.ThreadState.Stopped) <> 0 Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Starting the service worker thread.", "OnStart")
            
            workerThread = New Thread(New ThreadStart(AddressOf ServiceWorkerMethod))
            workerThread.Start()
        End If
        If Not (workerThread Is Nothing) Then
            Trace.WriteLine(DateTime.Now.ToLongTimeString() + " - Worker thread state = " + workerThread.ThreadState.ToString(), "OnStart")
        End If
    
    End Sub 'OnStart
    
    
    