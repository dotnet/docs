' <snippet2>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim zipPath As String = "c:\example\result.zip"

        Using archive As ZipArchive = ZipFile.Open(zipPath, ZipArchiveMode.Update)
            Dim entry As ZipArchiveEntry = archive.GetEntry("ExistingFile.txt")

            Using writer As StreamWriter = New StreamWriter(entry.Open())
                writer.BaseStream.Seek(0, SeekOrigin.End)
                writer.WriteLine("append line to file")
            End Using
            entry.LastWriteTime = DateTimeOffset.UtcNow.LocalDateTime
        End Using
    End Sub

End Module
' </snippet2>
