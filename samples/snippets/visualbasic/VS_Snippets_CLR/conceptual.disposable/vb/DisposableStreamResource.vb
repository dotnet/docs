Imports Microsoft.Win32.SafeHandles

Public Class DisposableStreamResource : Implements IDisposable
    ' Define constants.
    Protected Const GENERIC_READ As UInteger = &H80000000UI
    Protected Const FILE_SHARE_READ As UInteger = &H0I
    Protected Const OPEN_EXISTING As UInteger = 3
    Protected Const FILE_ATTRIBUTE_NORMAL As UInteger = &H80
    Private Const INVALID_FILE_SIZE As Integer = &HFFFFFFFF

    ' Define Windows APIs.
    Protected Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" (
        lpFileName As String, dwDesiredAccess As UInt32,
        dwShareMode As UInt32, lpSecurityAttributes As IntPtr,
        dwCreationDisposition As UInt32, dwFlagsAndAttributes As UInt32,
        hTemplateFile As IntPtr) As SafeFileHandle

    Private Declare Function GetFileSize Lib "kernel32" (
        hFile As SafeFileHandle, ByRef lpFileSizeHigh As Integer) As Integer

    ' Define locals.
    Private disposed As Boolean = False
    Private ReadOnly safeHandle As SafeFileHandle
    Private ReadOnly upperWord As Integer

    Public Sub New(fileName As String)
        If String.IsNullOrWhiteSpace(fileName) Then
            Throw New ArgumentNullException(
                NameOf(fileName), "The fileName cannot be null or an empty string")
        End If

        safeHandle = CreateFile(
            fileName, GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero,
            OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero)

        ' Get file size.
        Size = GetFileSize(safeHandle, upperWord)
        If Size = INVALID_FILE_SIZE Then
            Size = -1
        ElseIf upperWord > 0 Then
            Size = (CLng(upperWord) << 32) + Size
        End If
    End Sub

    Public ReadOnly Property Size As Long

    Public Sub Dispose() _
              Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(disposing As Boolean)
        If disposed Then Exit Sub

        ' Dispose of managed resources here.
        If disposing Then
            safeHandle.Dispose()
        End If

        ' Dispose of any unmanaged resources not wrapped in safe handles.

        disposed = True
    End Sub
End Class
