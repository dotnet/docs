Public Class Disposable : Implements IDisposable

    ' <SnippetDispose>
    Public Sub Dispose() _
        Implements IDisposable.Dispose
        ' Dispose of unmanaged resources.
        Dispose(True)
        ' Suppress finalization.
        GC.SuppressFinalize(Me)
    End Sub
    ' </SnippetDispose>

    ' <SnippetDisposeBool>
    Protected Overridable Sub Dispose(disposing As Boolean)
    End Sub
    ' </SnippetDisposeBool>

End Class
