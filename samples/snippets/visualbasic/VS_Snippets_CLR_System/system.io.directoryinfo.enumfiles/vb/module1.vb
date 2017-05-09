Imports System.IO
Module Module1

    Sub Main()
' <Snippet1>
' Create a DirectoryInfo of the directory of the files to enumerate.
Dim DirInfo As New DirectoryInfo("\\archives1\library\")

Dim StartOf2009 As New DateTime(2009, 1, 1)

' LINQ query for all files created before 2009.
Dim files = From f In DirInfo.EnumerateFiles()
			Where f.CreationTimeUtc < StartOf2009

' Show results.
For Each f As FileInfo In files
	Console.WriteLine("{0}", f.Name)
Next
' </Snippet1>

    End Sub

End Module


