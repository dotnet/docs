 '<SNIPPET1>
' This sample shows how to set the current directory and how to determine
' the root directory.
Imports System
Imports System.IO

Public Class DirectoryRoot
   
   Public Shared Sub Main()
      ' Create string for a directory. This value should be an existing directory
      ' or the sample will throw a DirectoryNotFoundException.
      Dim dir As String = "C:\test"
      Try
         'Set the current directory.
         Directory.SetCurrentDirectory(dir)
      Catch e As DirectoryNotFoundException
         Console.WriteLine("The specified directory does not exist. {0}", e)
      End Try
      ' Print to console the results.
      Console.WriteLine("Root directory: {0}", Directory.GetDirectoryRoot(dir))
      Console.WriteLine("Current directory: {0}", Directory.GetCurrentDirectory())
   End Sub 'Main
End Class 'DirectoryRoot
' The output of this sample depends on what value you assign to the variable dir.
' If the directory c:\test exists, the output for this sample is:
' Root directory: C:\
' Current directory: C:\test
'</SNIPPET1>