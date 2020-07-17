' <Snippet1>
Imports System.IO
Imports System.Xml.Linq

Module Module1

    Sub Main()
        Try
            Dim docPath As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            Dim files = From chkFile In Directory.EnumerateFiles(docPath, "*.txt", SearchOption.AllDirectories)
                        From line In File.ReadLines(chkFile)
                        Where line.Contains("Microsoft")
                        Select New With {.curFile = chkFile, .curLine = line}

            For Each f In files
                Console.WriteLine($"{f.File}\t{f.Line}")
            Next
            Console.WriteLine($"{files.Count} files found.")
        Catch uAEx As UnauthorizedAccessException
            Console.WriteLine(uAEx.Message)
        Catch pathEx As PathTooLongException
            Console.WriteLine(pathEx.Message)
        End Try
    End Sub
End Module
' </Snippet1>
