' <Snippet4>
Imports System.IO

Module Example
   Public Sub Main()
        If Environment.OSVersion.Platform = PlatformID.Win32NT Then
            ' Change the directory to %WINDIR%
            Environment.CurrentDirectory = Environment.GetEnvironmentVariable("windir")
            Dim info As New DirectoryInfo(".")
            Console.WriteLine("Directory Info:   " + info.FullName)
         Else
            Console.WriteLine("This example runs on Windows only.")
         End If
   End Sub
End Module
' The example displays output like the following on a .NET implementation running on Windows:
'        Directory Info:   C:\windows
' The example displays the following output on a .NET implementation on Unix-based systems:
'        This example runs on Windows only.
' </Snippet4>
