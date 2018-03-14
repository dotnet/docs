'<snippet1>
Imports System.IO
Imports System.IO.Compression

Public Class Program
    Shared directoryPath As String = "c:\temp"
    Public Shared Sub Main()

        Dim directorySelected As New DirectoryInfo(directoryPath)
        Compress(directorySelected)


        For Each fileToDecompress As FileInfo In directorySelected.GetFiles("*.cmp")
            Decompress(fileToDecompress)
        Next
    End Sub

    Public Shared Sub Compress(directorySelected As DirectoryInfo)

        For Each file__1 As FileInfo In directorySelected.GetFiles("*.xml")
            Using originalFileStream As FileStream = file__1.OpenRead()
                If (File.GetAttributes(file__1.FullName) And FileAttributes.Hidden) <> FileAttributes.Hidden And file__1.Extension <> ".cmp" Then
                    Using compressedFileStream As FileStream = File.Create(file__1.FullName & ".cmp")
                        Using compressionStream As Compression.DeflateStream = New DeflateStream(compressedFileStream, CompressionMode.Compress)
                            originalFileStream.CopyTo(compressionStream)
                        End Using
                    End Using

                    Dim info As New FileInfo(directoryPath & "\" & file__1.Name & ".cmp")
                    Console.WriteLine("Compressed {0} from {1} to {2} bytes.", file__1.Name, file__1.Length, info.Length)
                End If
            End Using
        Next
    End Sub

    Public Shared Sub Decompress(fileToDecompress As FileInfo)
        Using originalFileStream As FileStream = fileToDecompress.OpenRead()
            Dim currentFileName As String = fileToDecompress.FullName
            Dim newFileName As String = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length)

            Using decompressedFileStream As FileStream = File.Create(newFileName)
                Using decompressionStream As New DeflateStream(originalFileStream, CompressionMode.Decompress)
                    decompressionStream.CopyTo(decompressedFileStream)
                    Console.WriteLine("Decompressed: {0}", fileToDecompress.Name)
                End Using
            End Using
        End Using
    End Sub
End Class
'</snippet1>