' <snippet1>
Imports System.IO
Public Class GetFilesTest
    Public Shared Sub Main()
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo("c:\")
        ' Get a reference to each file in that directory.
        Dim fiArr As FileInfo() = di.GetFiles()
        ' Display the names of the files.
        Dim fri As FileInfo
        For Each fri In fiArr
            Console.WriteLine(fri.Name)
        Next fri
    End Sub
End Class
' </snippet1>