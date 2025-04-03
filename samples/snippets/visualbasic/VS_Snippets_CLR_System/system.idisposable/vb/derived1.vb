Imports System.IO

Public Class DisposableDerived
    Inherits DisposableBase

    ' To detect redundant calls
    Private _isDisposed As Boolean

    ' Instantiate a disposable object owned by this class.
    Private _managedResource As Stream = New MemoryStream()

    ' Protected implementation of Dispose pattern.
    Protected Overrides Sub Dispose(disposing As Boolean)
        If Not _isDisposed Then
            _isDisposed = True

            If disposing Then
                _managedResource?.Dispose()
                _managedResource = Nothing
            End If
        End If

        ' Call base class implementation.
        MyBase.Dispose(disposing)
    End Sub
End Class
