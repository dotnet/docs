'<SnippetAll>
Imports System
Imports System.Threading

Friend Class Program
    Private Shared lazyLargeObject As Lazy(Of LargeObject) = Nothing

    ' Factory function for lazy initialization.
    '<SnippetFactoryFunc>
    Private Shared instanceCount As Integer = 0
    Private Shared Function InitLargeObject() As LargeObject
        If 1 = Interlocked.Increment(instanceCount) Then
            Throw New ApplicationException( _
                "Lazy initialization function failed on thread " & _
                Thread.CurrentThread.ManagedThreadId & ".")
        End If
        Return New LargeObject(Thread.CurrentThread.ManagedThreadId)
    End Function
    '</SnippetFactoryFunc>

    Shared Sub Main()
        ' The lazy initializer is created here. LargeObject is not created until the 
        ' ThreadProc method executes.
        '<SnippetNewLazy>
        lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, _
             LazyThreadSafetyMode.PublicationOnly)
        '</SnippetNewLazy>


        ' Create and start 3 threads, passing the same blocking event to all of them.
        Dim startingGate As New ManualResetEvent(False)
        Dim threads() As Thread = { _
            New Thread(AddressOf ThreadProc), _
            New Thread(AddressOf ThreadProc), _
            New Thread(AddressOf ThreadProc) _
        }
        For Each t As Thread In threads
            t.Start(startingGate)
        Next t

        ' Give all 3 threads time to start and wait, then release them all at once.
        Thread.Sleep(50)
        startingGate.Set()

        ' Wait for all 3 threads to finish. (The order doesn't matter.)
        For Each t As Thread In threads
            t.Join()
        Next t

        Console.WriteLine(vbCrLf & _
            "Threads are complete. Running GC.Collect() to reclaim extra instances.")

        GC.Collect()

        ' Allow time for garbage collection, which happens asynchronously.
        Thread.Sleep(100)

        Console.WriteLine(vbCrLf & "Note that only one instance of LargeObject was used.")
        Console.WriteLine("Press Enter to end the program")
        Console.ReadLine()
    End Sub


    Private Shared Sub ThreadProc(ByVal state As Object)
        ' Wait for the signal.
        Dim waitForStart As ManualResetEvent = CType(state, ManualResetEvent)
        waitForStart.WaitOne()

        '<SnippetValueProp>
        Dim large As LargeObject = Nothing
        Try
            large = lazyLargeObject.Value

            ' The following line introduces an artificial delay, to exaggerate the race 
            ' condition.
            Thread.Sleep(5)

            ' IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the  
            '            object after creation. You must lock the object before accessing it,
            '            unless the type is thread safe. (LargeObject is not thread safe.)
            SyncLock large
                large.Data(0) = Thread.CurrentThread.ManagedThreadId
                Console.WriteLine( _
                    "LargeObject was initialized by thread {0}; last used by thread {1}.", _
                    large.InitializedBy, large.Data(0))
            End SyncLock
        Catch ex As ApplicationException
            Console.WriteLine("ApplicationException: {0}", ex.Message)
        End Try
        '</SnippetValueProp>
    End Sub
End Class

Friend Class LargeObject
    Private initBy As Integer = -1
    Public ReadOnly Property InitializedBy() As Integer
        Get
            Return initBy
        End Get
    End Property

    '<SnippetCtorFinalizer>
    Public Sub New(ByVal initializedBy As Integer)
        initBy = initializedBy
        Console.WriteLine("Constructor: Instance initializing on thread {0}", initBy)
    End Sub

    Protected Overrides Sub Finalize()
        Console.WriteLine("Finalizer: Instance was initialized on {0}", initBy)
    End Sub
    '</SnippetCtorFinalizer>

    Public Data(99999999) As Long
End Class

' This example produces output similar to the following:
'
'Constructor: Instance initializing on thread 4
'ApplicationException: Lazy initialization function failed on thread 3.
'Constructor: Instance initializing on thread 5
'LargeObject was initialized by thread 4; last used by thread 4.
'LargeObject was initialized by thread 4; last used by thread 5.
'
'Threads are complete. Running GC.Collect() to reclaim extra instances.
'Finalizer: Instance was initialized on 5
'
'Note that only one instance of LargeObject was used.
'Press Enter to end the program
'
'Finalizer: Instance was initialized on 4
' 
'</SnippetAll>
