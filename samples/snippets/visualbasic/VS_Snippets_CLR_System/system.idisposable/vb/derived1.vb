Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices

Public Class DerivedClassWithSafeHandle
    Inherits BaseClassWithSafeHandle

    ' To detect redundant calls
    Private _disposedValue As Boolean

    ' Instantiate a SafeHandle instance.
    Private _safeHandle As SafeHandle = New SafeFileHandle(IntPtr.Zero, True)

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Not _disposedValue Then

            If disposing AndAlso _safeHandle IsNot Nothing Then
                _safeHandle.Dispose()
                _safeHandle = Nothing
            End If

            _disposedValue = True
        End If

        ' Call base class implementation.
        MyBase.Dispose(disposing)
    End Sub
End Class
