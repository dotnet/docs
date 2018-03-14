' Visual Basic .NET Document
Option Strict On
' <Snippet1>
Imports System.IO

Public Structure FileTime
   Public dwLowDateTime As UInteger
   Public dwHighDateTime As UInteger

   Public Shared Widening Operator CType(fileTime As FileTime) As Long
      Dim returnedLong As Long
      ' Convert 4 high-order bytes to a byte array
      Dim highBytes() As Byte = BitConverter.GetBytes(fileTime.dwHighDateTime)
      ' Resize the array to 8 bytes (for a Long)
      ReDim Preserve highBytes(7)

      ' Assign high-order bytes to first 4 bytes of Long
      returnedLong = BitConverter.ToInt64(highBytes, 0) 
      ' Shift high-order bytes into position
      returnedLong = returnedLong << 32
      ' Or with low-order bytes
      returnedLong = returnedLong Or fileTime.dwLowDateTime
      ' Return Long 
      return returnedLong
   End Operator
End Structure

Module modMain
   Private Const OPEN_EXISTING As Integer = 3
   
   Private Const INVALID_HANDLE_VALUE As Integer = -1
      
   Private Declare Function CreateFile Lib "kernel32" Alias "CreateFileA" ( _
                            ByVal lpFileName As String, _
                            ByVal dwDesiredAccess As Integer, _
                            ByVal dwShareMode As Integer, _
                            ByVal lpSecurityAttributes As Integer, _
                            ByVal dwCreationDisposition As Integer, _
                            ByVal dwFlagsAndAttributes As Integer, _
                            ByVal hTemplateFile As Integer) _
           As Integer

   Private Declare Function GetFileTime Lib "Kernel32"( _
                            hFile As Integer, _
                            ByRef lpCreationTime As FileTime, _
                            ByRef lpLastAccessTime As FileTime, _
                            ByRef lpLastWriteTime As FileTime) _
            As Boolean 

   Private Declare Function CloseHandle Lib "Kernel32" ( _
                            hFile As Integer) _
           As Boolean
                        
   Public Sub Main()
      ' Open file %windir%\write.exe
      Dim winDir As String = Environment.SystemDirectory 
      If Not winDir.EndsWith(Path.DirectorySeparatorChar) Then _
         winDir += Path.DirectorySeparatorChar 
      windir += "write.exe"

      ' Get file time using Windows API
      '
      ' Open file
      Dim hFile As Integer = CreateFile(winDir, 0, 0, 0, _
                                       OPEN_EXISTING, 0, 0)
      If hFile = INVALID_HANDLE_VALUE Then
         Console.WriteLine("Unable to access {0}.", winDir)
      Else
         Dim creationTime, accessTime, writeTime As FileTime
         If GetFileTime(hFile, creationTime, accessTime, writeTime) Then
            CloseHandle(hFile)
            Dim fileCreationTime As Long = CType(creationTime, Long)
            Dim fileAccessTime As Long = CType(accessTime, Long)
            Dim fileWriteTime As Long = CType(writeTime, Long)

            Console.WriteLine("File {0} Retrieved Using the Windows API:", winDir)
            Console.WriteLine("   Created:     {0:d}", DateTimeOffset.FromFileTime(fileCreationTime).ToString())
            Console.WriteLine("   Last Access: {0:d}", DateTimeOffset.FromFileTime(fileAccessTime).ToString())
            Console.WriteLine("   Last Write:  {0:d}", DateTimeOffset.FromFileTime(fileWriteTime).ToString())
            Console.WriteLine() 
         End If   
      End If
      
      ' Get date and time, convert to file time, then convert back
      Dim fileInfo As New FileInfo(winDir)
      Dim infoCreationTime, infoAccessTime, infoWriteTime As DateTimeOffset
      Dim ftCreationTime, ftAccessTime, ftWriteTime As Long
      
      ' Get dates and times of file creation, last access, and last write
      infoCreationTime = fileInfo.CreationTime
      infoAccessTime = fileInfo.LastAccessTime
      infoWriteTime = fileInfo.LastWriteTime
      ' Convert values to file times
      ftCreationTime = infoCreationTime.ToFileTime()
      ftAccessTime = infoAccessTime.ToFileTime()
      ftWriteTime = infoWriteTime.ToFileTime()
      
      ' Convert file times back to DateTimeOffset values
      Console.WriteLine("File {0} Retrieved Using a FileInfo Object:", winDir)
      Console.WriteLine("   Created:     {0:d}", DateTimeOffset.FromFileTime(ftCreationTime).ToString())
      Console.WriteLine("   Last Access: {0:d}", DateTimeOffset.FromFileTime(ftAccessTime).ToString())
      Console.WriteLine("   Last Write:  {0:d}", DateTimeOffset.FromFileTime(ftWriteTime).ToString()) 
   End Sub
End Module
' The example produces the following output:
'    File C:\WINDOWS\system32\write.exe Retrieved Using the Windows API:
'       Created:     10/13/2005 5:26:59 PM -07:00
'       Last Access: 3/20/2007 2:07:00 AM -07:00
'       Last Write:  8/4/2004 5:00:00 AM -07:00
'    
'    File C:\WINDOWS\system32\write.exe Retrieved Using a FileInfo Object:
'       Created:     10/13/2005 5:26:59 PM -07:00
'       Last Access: 3/20/2007 2:07:00 AM -07:00
'       Last Write:  8/4/2004 5:00:00 AM -07:00
' </Snippet1>
