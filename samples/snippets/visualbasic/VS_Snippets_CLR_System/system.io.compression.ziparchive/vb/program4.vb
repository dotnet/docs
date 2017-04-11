' <snippet4>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim zipPath As String = "c:\users\exampleuser\end.zip"
        Dim extractPath As String = "c:\users\exampleuser\extract"
        Dim newFile As String = "c:\users\exampleuser\NewFile.txt"

        Using archive As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Update)
            archive.CreateEntryFromFile(newFile, "NewEntry.txt", CompressionLevel.Fastest)
            archive.ExtractToDirectory(extractPath)
        End Using
    End Sub

End Module
' </snippet4>
