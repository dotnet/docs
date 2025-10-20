Imports System.Threading

Public Class Disposable : Implements IDisposable

    ' Detect redundant Dispose() calls in a thread-safe manner.
    ' _disposed = 0 means Dispose(bool) has not been called yet.
    ' _disposed = 1 means Dispose(bool) has been already called.
    Private _disposed As Integer

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
        ' In case _disposed is 0, atomically set it to 1.
        ' Enter the branch only if the original value is 0.
        If Interlocked.CompareExchange(_disposed, 1, 0) = 0 Then
            If disposing Then
                ' Free managed resources.
                ' ...
            End If

            ' Free unmanaged resources.
            ' ...
        End If
   End Sub
    ' </SnippetDisposeBool>

End Class
