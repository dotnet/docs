' <snippet2>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Sub Main()
        Dim directoryPath As String = "c:\users\public\reports"
        Dim directorySelected As DirectoryInfo = New DirectoryInfo(directoryPath)

        For Each fileToCompress As FileInfo In directorySelected.EnumerateFiles()
            Compress(fileToCompress)
        Next
    End Sub

    Public Sub Compress(fileToCompress As FileInfo)
        Using originalFileStream As FileStream = fileToCompress.OpenRead()
            If ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) <> FileAttributes.Hidden And fileToCompress.Extension <> ".gz") Then
                Using compressedFileStream As FileStream = File.Create(fileToCompress.FullName + ".gz")
                    Using compressionStream As GZipStream = New GZipStream(compressedFileStream, CompressionLevel.Fastest, True)
                        originalFileStream.CopyTo(compressionStream)
                    End Using
                    Console.WriteLine(String.Format("file compressed to {0} bytes", compressedFileStream.Length))
                End Using
            End If
        End Using
    End Sub

End Module
' </snippet2>
