'<SnippetAll>
Imports System
Imports System.Threading

Class Program
    Private Shared lazyLargeObject As Lazy(Of LargeObject) = Nothing

    Shared Sub Main()
        ' The lazy initializer is created here. LargeObject is not created until the 
        ' ThreadProc method executes.
        '<SnippetNewLazy>
        lazyLargeObject = New Lazy(Of LargeObject)()

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = New Lazy(Of LargeObject)(True)
        'lazyLargeObject = New Lazy(Of LargeObject)(LazyThreadSafetyMode.ExecutionAndPublication)
        '</SnippetNewLazy>


        Console.WriteLine( _
            vbCrLf & "LargeObject is not created until you access the Value property of the lazy" _
            & vbCrLf & "initializer. Press Enter to create LargeObject.")
        Console.ReadLine()

        ' Create and start 3 threads, passing the same blocking event to all of them.
        Dim startingGate As New ManualResetEvent(False)
        Dim threads() As Thread = { New Thread(AddressOf ThreadProc), 
            New Thread(AddressOf ThreadProc), New Thread(AddressOf ThreadProc) }
        For Each t As Thread In threads
            t.Start(startingGate)
        Next t

        ' Give all 3 threads time to start and wait, then release them all at once.
        Thread.Sleep(100)
        startingGate.Set()

        ' Wait for all 3 threads to finish. (The order doesn't matter.)
        For Each t As Thread In threads
            t.Join()
        Next t

        Console.WriteLine(vbCrLf & "Press Enter to end the program")
        Console.ReadLine()
    End Sub


    Private Shared Sub ThreadProc(ByVal state As Object)
        ' Wait for the signal.
        Dim waitForStart As ManualResetEvent = CType(state, ManualResetEvent)
        waitForStart.WaitOne()

        '<SnippetValueProp>
        Dim large As LargeObject = lazyLargeObject.Value
        '</SnippetValueProp>

        ' The following line introduces an artificial delay, to exaggerate the race 
        ' condition.
        Thread.Sleep(5)

        ' IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the  
        '            object after creation. You must lock the object before accessing it,
        '            unless the type is thread safe. (LargeObject is not thread safe.)
        SyncLock large
            large.Data(0) = Thread.CurrentThread.ManagedThreadId
            Console.WriteLine("Initialized by thread {0}; last used by thread {1}.", _
                large.InitializedBy, large.Data(0))
        End SyncLock
    End Sub
End Class

Class LargeObject
    Private initBy As Integer = 0
    Public ReadOnly Property InitializedBy() As Integer
        Get
            Return initBy
        End Get
    End Property

    Public Sub New()
        initBy = Thread.CurrentThread.ManagedThreadId
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy)
    End Sub
    Public Data(100000000) As Long
End Class

' This example produces output similar to the following:
'
'LargeObject is not created until you access the Value property of the lazy
'initializer. Press Enter to create LargeObject.
'
'LargeObject was created on thread id 3.
'Initialized by thread 3; last used by thread 5.
'Initialized by thread 3; last used by thread 4.
'Initialized by thread 3; last used by thread 3.
'
'Press Enter to end the program
'</SnippetAll>
