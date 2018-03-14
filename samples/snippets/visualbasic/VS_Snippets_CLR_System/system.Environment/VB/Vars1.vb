' Visual Basic .NET Document
Option Strict On

' <Snippet4>
Imports System.IO

Module Example
   Public Sub Main()
        ' Change the directory to %WINDIR%
        Environment.CurrentDirectory = Environment.GetEnvironmentVariable("windir")
        Dim info As New DirectoryInfo(".")
        Console.WriteLine("Directory Info:   " + info.FullName)
   End Sub
End Module
' The example displays output like the following:
'        Directory Info:   C:\windows
' </Snippet4>
