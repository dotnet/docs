' Visual Basic .NET Document
Option Strict On

Imports System.IO
Imports System.Reflection

Module modMain
   Public Sub Main()
      LoadUnmanagedDLL()
   End Sub
      
   Private Sub LoadUnmanagedDLL()
      ' <Snippet1>
      ' Windows DLL (non-.NET assembly)
      Dim filePath As String = Environment.ExpandEnvironmentVariables("%windir%")
      If Not filePath.Trim().EndsWith("\") Then filepath += "\"
      filePath += "System32\Kernel32.dll"
      Try
         Dim assem As Assembly = Assembly.LoadFile(filePath)
      Catch e As BadImageFormatException
         Console.WriteLine("Unable to load {0}.", filePath)
         Console.WriteLine(e.Message.Substring(0, _
                           e.Message.IndexOf(".") + 1))   
      End Try
      ' The example displays an error message like the following:
      '       Unable to load C:\WINDOWS\System32\Kernel32.dll.
      '       The module was expected to contain an assembly manifest.
      ' </Snippet1>
   End Sub
End Module

