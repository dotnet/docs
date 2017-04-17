' <Snippet1>
Imports System
Imports System.IO

Class GetAName
    Public Shared Sub Main()
        Dim dir As New DirectoryInfo(".")
        Dim dirName As String = dir.Name
        Console.WriteLine("DirectoryInfo name is {0}.", dirName)
    End Sub

End Class
' </Snippet1>