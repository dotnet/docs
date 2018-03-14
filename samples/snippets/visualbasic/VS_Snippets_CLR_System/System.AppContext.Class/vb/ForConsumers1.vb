' Visual Basic .NET Document
Option Strict On

' <Snippet10>
Imports System.IO
Imports System.Runtime.Versioning

<assembly:TargetFramework(".NETFramework,Version=v4.6.2")>

Module Example
   Public Sub Main()
      Console.WriteLine(Path.GetDirectoryName("file://c/temp/dirlist.txt")) 
   End Sub
End Module
' The example displays the following output:
'    Unhandled Exception: System.ArgumentException: The path is not of a legal form.
'       at System.IO.Path.NewNormalizePathLimitedChecks(String path, Int32 maxPathLength, Boolean expandShortPaths)
'       at System.IO.Path.NormalizePath(String path, Boolean fullCheck, Int32 maxPathLength, Boolean expandShortPaths)
'       at System.IO.Path.InternalGetDirectoryName(String path)
'       at Example.Main()
' </Snippet10>
