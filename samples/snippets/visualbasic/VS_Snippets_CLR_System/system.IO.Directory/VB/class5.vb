' <snippet13>
Imports System.IO

Module Module1

    Sub Main()
        Dim sourceDirectory As String = "C:\current"
        Dim archiveDirectory As String = "C:\archive"

        Try
            Dim txtFiles = Directory.EnumerateFiles(sourceDirectory, "*.txt", SearchOption.AllDirectories)

            For Each currentFile As String In txtFiles
                Dim fileName = currentFile.Substring(sourceDirectory.Length + 1)
                Directory.Move(currentFile, Path.Combine(archiveDirectory, fileName))
            Next
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try

    End Sub

End Module
' </snippet13>
