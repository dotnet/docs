' <Snippet1>
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

Module Module1

    Sub Main()
        Try
            Dim dirPath As String = "\\archives\2009\reports"

            Dim dirs As List(Of String) = New List(Of String)(Directory.EnumerateDirectories(dirPath))

            For Each folder In dirs
                Console.WriteLine("{0}", folder.Substring(folder.LastIndexOf("\") + 1))
            Next
            Console.WriteLine("{0} directories found.", dirs.Count)
        Catch UAEx As UnauthorizedAccessException
            Console.WriteLine(UAEx.Message)
        Catch PathEx As PathTooLongException
            Console.WriteLine(PathEx.Message)
        End Try

    End Sub
End Module
' </Snippet1>