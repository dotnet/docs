Imports System.IO
Imports System.Threading

Public Class DisposableBase
    Implements IDisposable

    ' Detect redundant Dispose() calls in a thread-safe manner.
    ' _isDisposed = 0 means Dispose(bool) has not been called yet.
    ' _isDisposed = 1 means Dispose(bool) has been already called.
    Private _isDisposed As Integer

    ' Instantiate a disposable object owned by this class.
    Private _managedResource As Stream = New MemoryStream()

    ' Public implementation of Dispose pattern callable by consumers.
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overridable Sub Dispose(disposing As Boolean)
        ' In case _isDisposed is 0, atomically set it to 1.
        ' Enter the branch only if the original value is 0.
        If Interlocked.CompareExchange(_isDisposed, 1, 0) = 0 Then
            If disposing Then
                ' Dispose managed state.
                _managedResource?.Dispose()
                _managedResource = Nothing
            End If
        End If
    End Sub
End Class
