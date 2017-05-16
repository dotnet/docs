'<snippet3>
Imports System.IO
Imports System.IO.Compression
Imports System.Text

Module Module1

    Sub Main()
        Dim uniEncode As UnicodeEncoding = New UnicodeEncoding()

        Dim bytesToCompress = uniEncode.GetBytes("example text to compress and decompress")
        Console.WriteLine("starting with: " + uniEncode.GetString(bytesToCompress))

        Using fileToCompress As FileStream = File.Create("examplefile.gz")
            Using compressionStream As GZipStream = New GZipStream(fileToCompress, CompressionMode.Compress)
                compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length)
            End Using
        End Using

        Dim decompressedBytes(bytesToCompress.Length - 1) As Byte
        Using fileToDecompress As FileStream = File.Open("examplefile.gz", FileMode.Open)
            Using decompressionStream As GZipStream = New GZipStream(fileToDecompress, CompressionMode.Decompress)
                decompressionStream.Read(decompressedBytes, 0, bytesToCompress.Length)
            End Using
        End Using

        Console.WriteLine("ending with: " + uniEncode.GetString(decompressedBytes))
    End Sub
End Module
'</snippet3>