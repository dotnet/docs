'<SnippetAll>
Imports System
Imports System.Threading

Friend Class Program
    Private Shared lazyLargeObject As Lazy(Of LargeObject) = Nothing

    '<SnippetFactoryFunc>
    Private Shared Function InitLargeObject() As LargeObject
        Return New LargeObject()
    End Function
    '</SnippetFactoryFunc>


    Shared Sub Main()
        ' The lazy initializer is created here. LargeObject is not created until the 
        ' ThreadProc method executes.
        '<SnippetNewLazy>
        lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, False)

        ' The following lines show how to use other constructors to achieve exactly the
        ' same result as the previous line: 
        'lazyLargeObject = New Lazy(Of LargeObject)(AddressOf InitLargeObject, LazyThreadSafetyMode.None)
        '</SnippetNewLazy>


        Console.WriteLine(vbCrLf _
            & "LargeObject is not created until you access the Value property of the lazy" _
            & vbCrLf & "initializer. Press Enter to create LargeObject (three tries).")
        Console.ReadLine()

        '<SnippetValueProp>
        For i As Integer = 0 To 2
            Try
                Dim large As LargeObject = lazyLargeObject.Value
                large.Data(11) = 89
            Catch aex As ApplicationException
                Console.WriteLine("Exception: {0}", aex.Message)
            End Try
        Next i
        '</SnippetValueProp>

        Console.WriteLine(vbCrLf & "Press Enter to end the program")
        Console.ReadLine()
    End Sub
End Class

Friend Class LargeObject
    '<SnippetLargeCtor>
    Private Shared pleaseThrow As Boolean = True
    Public Sub New()
        If pleaseThrow Then
            pleaseThrow = False
            Throw New ApplicationException("Throw only ONCE.")
        End If

        Console.WriteLine("LargeObject was created on thread id {0}.", _
            Thread.CurrentThread.ManagedThreadId)
    End Sub
    '</SnippetLargeCtor>
    Public Data(100000000) As Long
End Class

' This example produces output similar to the following:
'
'LargeObject is not created until you access the Value property of the lazy
'initializer. Press Enter to create LargeObject (three tries).
'
'Exception: Throw only ONCE.
'Exception: Throw only ONCE.
'Exception: Throw only ONCE.
'
'Press Enter to end the program
' 
'</SnippetAll>
