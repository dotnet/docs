Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Public Class BaseClassWithSafeHandle
    Implements IDisposable

    ' To detect redundant calls
    Private _disposedValue As Boolean

    ' Instantiate a SafeHandle instance.
    Private _safeHandle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)

    ' Public implementation of Dispose pattern callable by consumers.
    Public Sub Dispose() _
               Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not _disposedValue Then

            If disposing Then
                _safeHandle?.Dispose()
                _safeHandle = Nothing
            End If

            _disposedValue = True
        End If
    End Sub
End Class
