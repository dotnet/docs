'<SnippetAll>
Imports System
Imports System.Threading

Friend Class Program
    Private Shared lazyLargeObject As Lazy(Of LargeObject) = Nothing

    Shared Sub Main()
        ' The lazy initializer is created here. LargeObject is not created until the 
        ' ThreadProc method executes.
        '<SnippetNewLazy>
        lazyLargeObject = New Lazy(Of LargeObject)(False)

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = new Lazy<LargeObject>(LazyThreadSafetyMode.None);
        '</SnippetNewLazy>


        Console.WriteLine( _
            vbCrLf & "LargeObject is not created until you access the Value property of the lazy" _
            & vbCrLf & "initializer. Press Enter to create LargeObject.")
        Console.ReadLine()

        '<SnippetValueProp>
        Dim large As LargeObject = lazyLargeObject.Value
        '</SnippetValueProp>

        large.Data(11) = 89

        Console.WriteLine(vbCrLf & "Press Enter to end the program")
        Console.ReadLine()
    End Sub
End Class

Friend Class LargeObject
    Public Sub New()
        Console.WriteLine("LargeObject was created on thread id {0}.", _
            Thread.CurrentThread.ManagedThreadId)
    End Sub
    Public Data(100000000) As Long
End Class

' This example produces output similar to the following:
'
'LargeObject is not created until you access the Value property of the lazy
'initializer. Press Enter to create LargeObject.
'
'LargeObject was created on thread id 1.
'
'Press Enter to end the program
'</SnippetAll>
