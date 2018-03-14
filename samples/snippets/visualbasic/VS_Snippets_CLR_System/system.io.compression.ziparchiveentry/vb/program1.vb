' <snippet1>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim zipPath As String = "c:\example\result.zip"

        Using archive As ZipArchive = ZipFile.OpenRead(zipPath)
            For Each entry As ZipArchiveEntry In archive.Entries
                Dim compressedRatio As Single = entry.CompressedLength / entry.Length
                Dim reductionPercentage As Single = 100 - (compressedRatio * 100)

                Console.WriteLine(String.Format("File: {0}, Compressed {1:F2}%", entry.Name, reductionPercentage))
            Next
        End Using
    End Sub

End Module
' </snippet1>
