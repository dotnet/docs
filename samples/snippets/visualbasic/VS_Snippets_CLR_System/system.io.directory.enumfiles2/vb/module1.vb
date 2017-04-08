' <Snippet1>
Imports System.IO
Imports System.Linq
Module Module1

    Sub Main()
        Try
            ' LINQ query for all .txt files containing the word 'Europe'.
            Dim files = From file In Directory.EnumerateFiles("\\archives1\library\", "*.txt")
                Where file.ToLower().Contains("europe")

            For Each file In files
                Console.WriteLine("{0}", file)
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
