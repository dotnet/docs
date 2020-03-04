' <snippet1>
Imports System.IO

Public Class GetDirectoriesTest

    Public Shared Sub Main()
        ' Make a reference to a directory.
        Dim di As New DirectoryInfo("c:\")
        ' Get a reference to each directory in that directory.
        Dim diArr As DirectoryInfo() = di.GetDirectories()
        ' Display the names of the directories.
        Dim dri As DirectoryInfo
        For Each dri In diArr
            Console.WriteLine(dri.Name)
        Next dri
    End Sub
End Class
' </snippet1>