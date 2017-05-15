Imports System.IO
Module Module1

    Sub Main()
' <Snippet1>
Dim p1 As String = "d:\archives\"
Dim p2 As String = "media"
Dim p3 As String = "images"
Dim combined As String = Path.Combine(p1, p2, p3)
Console.WriteLine(combined)
' </Snippet1>

' <Snippet2>
Dim path1 As String = "d:\archives\"
Dim path2 As String = "2001"
Dim path3 As String = "media"
Dim path4 As String = "imaged"
Dim combinedPath As String = Path.Combine(path1, path2, path3, path4)
Console.WriteLine(combined)
' </Snippet2>

' <Snippet3>
Dim paths As String() = {"d:\archives", "2001", "media", "images"}
Dim fullPath As String = Path.Combine(paths)
Console.WriteLine(fullPath)
' </Snippet3>
    End Sub

End Module