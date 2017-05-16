' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports Microsoft.Win32.SafeHandles
Imports System
Imports System.Runtime.InteropServices

Module Example
   Private Const GENERIC_READ As UInteger = 2147483648
   Private Const OPEN_EXISTING As UInteger = 3 
   Private Const FILE_ATTRIBUTE_NORMAL As UInteger = 128
   Private Const FILE_FLAG_OVERLAPPED As UInteger = &h40000000

   Private Declare Auto Function CreateFile Lib "Kernel32" Alias "CreateFileW" (
            lpFileName As String, dwDesiredAccess As UInt32, 
            dwShareMode As UInt32, pSecurityAttributes As IntPtr, 
            dwCreationDisposition As UInt32, dwFlagsAndAttributes As UInt32, 
            hTemplateFile As IntPtr) As SafeFileHandle

   Public Sub Main()
      Dim hnd As SafeFileHandle = CreateFile("CallOfTheWild.txt", GENERIC_READ, 0, 
                                             IntPtr.Zero, OPEN_EXISTING,
                                             FILE_ATTRIBUTE_NORMAL Or FILE_FLAG_OVERLAPPED, 
                                             IntPtr.Zero)
      If hnd.IsInvalid Then
         Dim ex As Exception = Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error())
         Console.WriteLine("Attempt to open file failed:")
         Console.WriteLine("  {0}", ex.Message)
         Return           
      Else 
         Console.WriteLine("File successfully opened.")
         hnd.Close()     
      End If
   End Sub
End Module
' If the file cannot be found, the example displays the following output:
'    Attempt to open file failed:
'      The system cannot find the file specified. (Exception from HRESULT: 0x80070002)
' </Snippet2>
