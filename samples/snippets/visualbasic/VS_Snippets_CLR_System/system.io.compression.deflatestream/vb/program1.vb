' <snippet1>
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
            If ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) <> FileAttributes.Hidden And fileToCompress.Extension <> ".cmp") Then
                Using compressedFileStream As FileStream = File.Create(fileToCompress.FullName + ".cmp")
                    Using compressionStream As DeflateStream = New DeflateStream(compressedFileStream, CompressionLevel.Fastest)
                        originalFileStream.CopyTo(compressionStream)
                    End Using
                End Using
            End If
        End Using
    End Sub

End Module
' </snippet1>
