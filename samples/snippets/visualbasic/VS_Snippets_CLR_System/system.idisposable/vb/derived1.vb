Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Class DerivedClassWithSafeHandle : Inherits BaseClassWithSafeHandle
    ' Flag: Has Dispose already been called?
    Dim disposed As Boolean = False
    ' Instantiate a SafeHandle instance.
    Dim handle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)

    ' Protected implementation of Dispose pattern.
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposed Then Return

        If disposing Then
            handle.Dispose()
            ' Free any other managed objects here.
            '
        End If

        ' Free any unmanaged objects here.
        '
        disposed = True

        ' Call base class implementation.
        MyBase.Dispose(disposing)
    End Sub
End Class
