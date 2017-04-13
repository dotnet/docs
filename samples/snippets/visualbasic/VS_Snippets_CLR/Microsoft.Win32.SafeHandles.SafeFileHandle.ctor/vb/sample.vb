'<Snippet1>
Imports System
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices
Imports System.ComponentModel



Class SafeHandlesExample


    Shared Sub Main()
        Try

            Dim loader As New UnmanagedFileLoader("example.xml")


        Catch e As Exception
            Console.WriteLine(e)
        End Try
        Console.ReadLine()

    End Sub
End Class


Class UnmanagedFileLoader

    Public Const FILE_ATTRIBUTE_NORMAL As Short = &H80
    Public Const INVALID_HANDLE_VALUE As Short = -1
    Public Const GENERIC_READ As Long = &H80000000
    Public Const GENERIC_WRITE As UInteger = &H40000000
    Public Const CREATE_NEW As UInteger = 1
    Public Const CREATE_ALWAYS As UInteger = 2
    Public Const OPEN_EXISTING As UInteger = 3


    ' Use interop to call the CreateFile function.
    ' For more information about CreateFile,
    ' see the unmanaged MSDN reference library.
    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Private Shared Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As System.UInt32, ByVal dwShareMode As System.UInt32, ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As System.UInt32, ByVal dwFlagsAndAttributes As System.UInt32, ByVal hTemplateFile As IntPtr) As IntPtr

    End Function

    Private handleValue As SafeFileHandle = Nothing



    Public Sub New(ByVal Path As String)
        Load(Path)

    End Sub


    Public Sub Load(ByVal Path As String)
        If Path Is Nothing AndAlso Path.Length = 0 Then
            Throw New ArgumentNullException("Path")
        End If

        ' Try to open the file.

        Dim ptr As IntPtr = CreateFile(Path, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)

        handleValue = New SafeFileHandle(ptr, True)
        ' If the handle is invalid,
        ' get the last Win32 error 
        ' and throw a Win32Exception.
        If handleValue.IsInvalid Then
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error())
        End If

    End Sub


    Public ReadOnly Property Handle() As SafeFileHandle
        Get
            ' If the handle is valid,
            ' return it.
            If Not handleValue.IsInvalid Then
                Return handleValue
            Else
                Return Nothing
            End If
        End Get
    End Property
End Class
'</Snippet1>