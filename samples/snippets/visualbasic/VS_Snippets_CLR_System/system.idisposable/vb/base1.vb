Imports System.IO

Public Class DisposableBase
    Implements IDisposable

    ' Detect redundant Dispose() calls.
    Private _isDisposed As Boolean

    ' Instantiate a disposable object owned by this class.
    Private _managedResource As Stream = New MemoryStream()

    ' Public implementation of Dispose pattern callable by consumers.
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not _isDisposed Then
            _isDisposed = True

            If disposing Then
                ' Dispose managed state.
                _managedResource?.Dispose()
                _managedResource = Nothing
            End If
        End If
    End Sub
End Class
