'<SnippetAll>
Imports System
Imports System.Threading

Friend Class Program
    Private Shared lazyLargeObject As Lazy(Of LargeObject) = Nothing

    '<SnippetFactoryFunc>
    Private Shared Function InitLargeObject() As LargeObject
        Dim large As New LargeObject(Thread.CurrentThread.ManagedThreadId)
        ' Perform additional initialization here.
        Return large
    End Function
    '</SnippetFactoryFunc>


    Shared Sub Main()
        ' The lazy initializer is created here. LargeObject is not created until the 
        ' ThreadProc method executes.
        '<SnippetNewLazy>
        lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject)

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, true);
        'lazyLargeObject = new Lazy<LargeObject>(InitLargeObject, _
        '                               LazyThreadSafetyMode.ExecutionAndPublication);
        '</SnippetNewLazy>


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
        '<SnippetValueProp>
        Dim large As LargeObject = lazyLargeObject.Value

        ' IMPORTANT: Lazy initialization is thread-safe, but it doesn't protect the  
        '            object after creation. You must lock the object before accessing it,
        '            unless the type is thread safe. (LargeObject is not thread safe.)
        SyncLock large
            large.Data(0) = Thread.CurrentThread.ManagedThreadId
            Console.WriteLine("Initialized by thread {0}; last used by thread {1}.", _
                large.InitializedBy, large.Data(0))
        End SyncLock
        '</SnippetValueProp>
    End Sub
End Class

Friend Class LargeObject
    Public ReadOnly Property InitializedBy() As Integer
        Get
            Return initBy
        End Get
    End Property

    '<SnippetLargeCtor>
    Private initBy As Integer = 0
    Public Sub New(ByVal initializedBy As Integer)
        initBy = initializedBy
        Console.WriteLine("LargeObject was created on thread id {0}.", initBy)
    End Sub
    '</SnippetLargeCtor>

    Public Data(99999999) As Long
End Class

' This example produces output similar to the following:
'
'LargeObject is not created until you access the Value property of the lazy
'initializer. Press Enter to create LargeObject.
'
'LargeObject was created on thread id 3.
'Initialized by thread 3; last used by thread 3.
'Initialized by thread 3; last used by thread 5.
'Initialized by thread 3; last used by thread 4.
'
'Press Enter to end the program
' 
'</SnippetAll>

