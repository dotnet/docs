' <Snippet1>
Imports System
Imports System.IO

Public Class BinaryRW

    Shared Sub Main()
    
        Dim i As Integer = 0
        Dim invalidPathChars() As Char = Path.InvalidPathChars
        Dim memStream As new MemoryStream()
        Dim binWriter As New BinaryWriter(memStream)

        ' Write to memory.
        binWriter.Write("Invalid file path characters are: ")
        For i = 0 To invalidPathChars.Length - 1
            binWriter.Write(invalidPathChars(i))
        Next i

        ' Create the reader using the same MemoryStream 
        ' as used with the writer.
        Dim binReader As New BinaryReader(memStream)

        ' Set Position to the beginning of the stream.
        memStream.Position = 0

        ' Read the data from memory and write it to the console.
        Console.Write(binReader.ReadString())
        Dim memoryData( _
            CInt(memStream.Length - memStream.Position) - 1) As Char
        For i = 0 To memoryData.Length - 1
            memoryData(i) = binReader.ReadChar()
        Next i
        Console.WriteLine(memoryData)
    
	End Sub
End Class
' </Snippet1>