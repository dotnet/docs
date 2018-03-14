' <Snippet1>
Imports System.IO
Imports System.Xml.Linq
Module Module1

    Sub Main()
        Try
            Dim files = From chkFile In Directory.EnumerateFiles("c:\", "*.txt", SearchOption.AllDirectories)
                        From line In File.ReadLines(chkFile)
                        Where line.Contains("Microsoft")
                        Select New With {.curFile = chkFile, .curLine = line}

            For Each f In files
                Console.WriteLine("{0}\t{1}", f.curFile, f.curLine)
            Next
            Console.WriteLine("{0} files found.", files.Count.ToString())
        Catch UAEx As UnauthorizedAccessException
            Console.WriteLine(UAEx.Message)
        Catch PathEx As PathTooLongException
            Console.WriteLine(PathEx.Message)
        End Try
    End Sub
End Module
' </Snippet1>


