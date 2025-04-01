Imports System.Threading

Public Class DisposableDerivedWithFinalizer
    Inherits DisposableBaseWithFinalizer

    ' Detect redundant Dispose() calls in a thread-safe manner.
    ' _isDisposed == 0 means Dispose(bool) has not been called yet.
    ' _isDisposed == 1 means Dispose(bool) has been already called.
    Private _isDisposed As Integer

    Protected Overrides Sub Finalize()
        Dispose(False)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overrides Sub Dispose(disposing As Boolean)
        ' In case _isDisposed is 0, atomically set it to 1.
        ' Enter the branch only if the original value is 0.
        If Interlocked.CompareExchange(_isDisposed, 1, 0) = 0 Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            ' TODO: set large fields to null.
        End If

        ' Call the base class implementation.
        MyBase.Dispose(disposing)
    End Sub
End Class
