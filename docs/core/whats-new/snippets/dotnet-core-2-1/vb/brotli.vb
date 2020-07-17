Imports System.IO
Imports System.IO.Compression

Public Module BrotliExample
    ' <Snippet1>
    Public Function DecompressWithBrotli(toDecompress As Stream) As Stream
        Dim decompressedStream As New MemoryStream()
        Using decompressionStream As New BrotliStream(toDecompress, CompressionMode.Decompress)
            decompressionStream.CopyTo(decompressedStream)
        End Using
        decompressedStream.Position = 0
        Return decompressedStream
    End Function
    ' </Snippet1>
End Module
