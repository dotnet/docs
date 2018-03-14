' <snippet11>
Imports System.IO

Module Module1

    Sub Main()
        Dim archiveDirectory As String = "C:\archive"

        Dim files = From retrievedFile In Directory.EnumerateFiles(archiveDirectory, "*.txt", SearchOption.AllDirectories)
                    From line In File.ReadLines(retrievedFile)
                    Where line.Contains("Example")
                    Select New With {.curFile = retrievedFile, .curLine = line}

        For Each f In files
            Console.WriteLine("{0} contains {1}", f.curFile, f.curLine)
        Next
        Console.WriteLine("{0} lines found.", files.Count.ToString())

    End Sub

End Module
' </snippet11>


