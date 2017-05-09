' <snippet1>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim zipPath As String = "c:\example\start.zip"
        Dim extractPath As String = "c:\example\extract"

        Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
            For Each entry As ZipArchiveEntry In archive.Entries
                If entry.FullName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) Then
                    entry.ExtractToFile(Path.Combine(extractPath, entry.FullName))
                End If
            Next
        End Using
    End Sub

End Module
' </snippet1>
