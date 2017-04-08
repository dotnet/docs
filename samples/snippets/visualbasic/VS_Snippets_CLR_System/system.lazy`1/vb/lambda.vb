Imports System
Imports System.Threading

Friend Class Program
    Private Shared lazyLargeObject As Lazy(Of LargeObject) = Nothing

    Shared Sub Main()
        ' The lazy initializer is created here. LargeObject is not created until the 
        ' ThreadProc method executes.
        '<SnippetInitWithLambda>
        lazyLargeObject = New Lazy(Of LargeObject)(Function () 
            Dim large As New LargeObject(Thread.CurrentThread.ManagedThreadId) 
            ' Perform additional initialization here.
            Return large
        End Function)
        '</SnippetInitWithLambda>


        Console.WriteLine(vbCrLf & _
            "LargeObject is not created until you access the Value property of the lazy" _
            & vbCrLf & "initializer. Press Enter to create LargeObject.")
        Console.ReadLine()

        ' Create and start 3 threads, each of which uses LargeObject.
        Dim threads(2) As Thread
        For i As Integer = 0 To 2
            threads(i) = New Thread(AddressOf ThreadProc)
            threads(i).Start()
        Next i

        ' Wait for all 3 threads to finish. 
        For Each t As Thread In threads
            t.Join()
        Next t

        Console.WriteLine(vbCrLf & "Press Enter to end the program")
        Console.ReadLine()
    End Sub


    Private Shared Sub ThreadProc(ByVal state As Object)
        Dim large As LargeObject = lazyLargeObject.Value

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

Friend Class LargeObject
    Public ReadOnly Property InitializedBy() As Integer
        Get
            Return initBy
        End Get
    End Property

    Private initBy As Integer = 0
    Public Sub New(ByVal initializedBy As Integer)
        initBy = initializedBy
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy)
    End Sub

    Public Data(99999999) As Long
End Class

