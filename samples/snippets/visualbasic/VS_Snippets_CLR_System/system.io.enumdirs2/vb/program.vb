' <Snippet1>
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

Module Module1

    Sub Main()
        Try
            Dim dirPath As String = "\\archives\2009\reports"

            ' LINQ query.
            Dim dirs = From folder In _
                Directory.EnumerateDirectories(dirPath, "dv_*")
            For Each folder In dirs
                ' Remove path infomration from string.
                Console.WriteLine("{0}", _
                        folder.Substring(folder.LastIndexOf("\") + 1))
            Next
            Console.WriteLine("{0} directories found.", _
                dirs.Count.ToString())

            ' Optionally create a List collection.
            Dim workDirs As List(Of String) = New List(Of String)

        Catch UAEx As UnauthorizedAccessException
            Console.WriteLine(UAEx.Message)
        Catch PathEx As PathTooLongException
            Console.WriteLine(PathEx.Message)
        End Try
    End Sub
End Module
' </Snippet1>