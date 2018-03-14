'<Snippet1>
Imports System
Imports Microsoft.Win32.SafeHandles
Imports System.Runtime.InteropServices
Imports System.ComponentModel



Module SafeHandlesExample

    Sub Main()
        Try

            Dim loader As New UnmanagedFileLoader("example.xml")


        Catch e As Exception
            Console.WriteLine(e)
        End Try
        Console.ReadLine()

    End Sub
End Module



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
    Private Shared Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As System.UInt32, ByVal dwShareMode As System.UInt32, ByVal lpSecurityAttributes As IntPtr, ByVal dwCreationDisposition As System.UInt32, ByVal dwFlagsAndAttributes As System.UInt32, ByVal hTemplateFile As IntPtr) As Microsoft.Win32.SafeHandles.SafeFileHandle

    End Function


    Private handleValue As Microsoft.Win32.SafeHandles.SafeFileHandle = Nothing



    Public Sub New(ByVal Path As String)
        Load(Path)

    End Sub


    Public Sub Load(ByVal Path As String)
        If Path Is Nothing OrElse Path.Length = 0 Then
            Throw New ArgumentNullException("Path")
        End If

        ' Try to open the file.
        handleValue = CreateFile(Path, GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero)

        ' If the handle is invalid,
        ' get the last Win32 error 
        ' and throw a Win32Exception.
        If handleValue.IsInvalid Then
            Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error())
        End If

    End Sub


    Public ReadOnly Property Handle() As Microsoft.Win32.SafeHandles.SafeFileHandle
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