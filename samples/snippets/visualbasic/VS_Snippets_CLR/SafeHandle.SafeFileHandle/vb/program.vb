' <Snippet1>
Imports System.Runtime.InteropServices
Imports System.IO
Imports Microsoft.Win32.SafeHandles

Public Module Example
   Const STD_INPUT_HANDLE As Integer  = -10
   Const STD_OUTPUT_HANDLE As Integer = -11
   Const STD_ERROR_HANDLE As Integer  = -12

   Public Declare Auto Function GetStdHandle Lib "Kernel32" (type As Integer) As IntPtr

   Public Sub Main()
      Dim fsIn As FileStream = Nothing
      Dim fsOut As FileStream = Nothing

      Try
         Dim sfhIn As New SafeFileHandle(GetStdHandle(STD_INPUT_HANDLE), False)
         fsIn = new FileStream(sfhIn, FileAccess.Read)
         Dim input() As Byte = { 0 }
         fsIn.Read(input, 0, 1)
         Dim sfhOut As New SafeFileHandle(GetStdHandle(STD_OUTPUT_HANDLE), False)
         fsOut = New FileStream(sfhOut, FileAccess.Write)
         fsOut.Write(input, 0, 1)
         Dim sf As SafeFileHandle = fsOut.SafeFileHandle
      Finally
         If fsIn IsNot Nothing Then
            fsIn.Close()
            fsIn = Nothing
         End If
         If fsOut IsNot Nothing Then 
            fsOut.Close()
            fsOut = Nothing
         End If
      End Try
   End Sub
End Module
' </Snippet1>