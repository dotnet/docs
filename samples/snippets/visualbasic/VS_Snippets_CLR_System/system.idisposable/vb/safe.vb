Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Microsoft.Win32.SafeHandles

' Wraps the IntPtr allocated by Marshal.AllocHGlobal() into a SafeHandle.
Public Class LocalAllocHandle
    Inherits SafeHandleZeroOrMinusOneIsInvalid

    Private Sub New()
        MyBase.New(True)
    End Sub

    ' No need to implement a finalizer - SafeHandle's finalizer will call ReleaseHandle for you.
    Protected Overrides Function ReleaseHandle() As Boolean
        Marshal.FreeHGlobal(handle)
        Return True
    End Function

    ' Allocate bytes with Marshal.AllocHGlobal() and wrap the result into a SafeHandle.
    Public Shared Function Allocate(numberOfBytes As Integer) As LocalAllocHandle
        Dim nativeHandle As IntPtr = Marshal.AllocHGlobal(numberOfBytes)
        Dim safeHandle As New LocalAllocHandle()
        safeHandle.SetHandle(nativeHandle)
        Return safeHandle
    End Function
End Class

Public Class DisposableBaseWithSafeHandle
    Implements IDisposable

    ' Detect redundant Dispose() calls in a thread-safe manner.
    ' _isDisposed = 0 means Dispose(bool) has not been called yet.
    ' _isDisposed = 1 means Dispose(bool) has been already called.
    Private _isDisposed As Integer

    ' Managed disposable objects owned by this class
    Private _safeHandle As LocalAllocHandle = LocalAllocHandle.Allocate(10)
    Private _otherUnmanagedResource As Stream = New MemoryStream()

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
                _otherUnmanagedResource?.Dispose()
                _safeHandle?.Dispose()
                _otherUnmanagedResource = Nothing
                _safeHandle = Nothing
            End If
        End If
    End Sub
End Class
