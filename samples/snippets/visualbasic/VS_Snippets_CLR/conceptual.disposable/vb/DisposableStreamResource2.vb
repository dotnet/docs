Imports Microsoft.Win32.SafeHandles

Public Class DisposableStreamResource2 : Inherits DisposableStreamResource
    ' Define additional constants.
    Protected Const GENERIC_WRITE As Integer = &H40000000
    Protected Const OPEN_ALWAYS As Integer = 4

    ' Define additional APIs.
    Protected Declare Function WriteFile Lib "kernel32.dll" (
        safeHandle As SafeFileHandle, lpBuffer As String,
        nNumberOfBytesToWrite As Integer, ByRef lpNumberOfBytesWritten As Integer,
        lpOverlapped As Object) As Boolean

    ' Define locals.
    Private disposed As Boolean = False
    Private created As Boolean = False
    Private safeHandle As SafeFileHandle
    Private ReadOnly filename As String

    Public Sub New(filename As String)
        MyBase.New(filename)
        Me.filename = filename
    End Sub

    Public Sub WriteFileInfo()
        If Not created Then
            safeHandle = CreateFile(
                ".\FileInfo.txt", GENERIC_WRITE, 0, IntPtr.Zero,
                OPEN_ALWAYS, FILE_ATTRIBUTE_NORMAL, IntPtr.Zero)
            created = True
        End If

        Dim output As String = $"{filename }: {Size:N0} bytes {vbCrLf }"
        Dim result = WriteFile(safeHandle, output, output.Length, 0&, Nothing)
    End Sub

    Protected Overridable Overloads Sub Dispose(disposing As Boolean)
        If disposed Then Exit Sub

        ' Release any managed resources here.
        If disposing Then
            safeHandle?.Dispose()
        End If

        disposed = True
        ' Release any unmanaged resources not wrapped by safe handles here.

        ' Call the base class implementation.
        MyBase.Dispose(disposing)
    End Sub
End Class
