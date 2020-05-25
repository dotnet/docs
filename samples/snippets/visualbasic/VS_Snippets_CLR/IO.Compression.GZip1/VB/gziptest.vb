' <Snippet1>
Imports System.IO
Imports System.IO.Compression

Module Module1

    Private directoryPath As String = ".\temp"
    Public Sub Main()
        Dim directorySelected As New DirectoryInfo(directoryPath)
        Compress(directorySelected)

        For Each fileToDecompress As FileInfo In directorySelected.GetFiles("*.gz")
            Decompress(fileToDecompress)
        Next
    End Sub

    Public Sub Compress(directorySelected As DirectoryInfo)
        For Each fileToCompress As FileInfo In directorySelected.GetFiles()
            Using originalFileStream As FileStream = fileToCompress.OpenRead()
                If (File.GetAttributes(fileToCompress.FullName) And FileAttributes.Hidden) <> FileAttributes.Hidden And fileToCompress.Extension <> ".gz" Then
                    Using compressedFileStream As FileStream = File.Create(fileToCompress.FullName & ".gz")
                        Using compressionStream As New GZipStream(compressedFileStream, CompressionMode.Compress)

                            originalFileStream.CopyTo(compressionStream)
                        End Using
                    End Using
                    Dim info As New FileInfo(directoryPath & Path.DirectorySeparatorChar & fileToCompress.Name & ".gz")
                    Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.")

                End If
            End Using
        Next
    End Sub


    Private Sub Decompress(ByVal fileToDecompress As FileInfo)
        Using originalFileStream As FileStream = fileToDecompress.OpenRead()
            Dim currentFileName As String = fileToDecompress.FullName
            Dim newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length)

            Using decompressedFileStream As FileStream = File.Create(newFileName)
                Using decompressionStream As GZipStream = New GZipStream(originalFileStream, CompressionMode.Decompress)
                    decompressionStream.CopyTo(decompressedFileStream)
                    Console.WriteLine($"Decompressed: {fileToDecompress.Name}")
                End Using
            End Using
        End Using
    End Sub
End Module
' </Snippet1>
