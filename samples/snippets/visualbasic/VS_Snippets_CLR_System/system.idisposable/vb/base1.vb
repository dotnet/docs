Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Class BaseClassWithSafeHandle : Implements IDisposable
    ' Flag: Has Dispose already been called?
    Dim disposed As Boolean = False
    ' Instantiate a SafeHandle instance.
    Dim handle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)

    ' Public implementation of Dispose pattern callable by consumers.
    Public Sub Dispose() _
               Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' Protected implementation of Dispose pattern.
    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposed Then Return

        If disposing Then
            handle.Dispose()
        End If

        disposed = True
    End Sub
End Class
