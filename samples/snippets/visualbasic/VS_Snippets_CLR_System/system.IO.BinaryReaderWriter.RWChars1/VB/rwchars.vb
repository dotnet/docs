' <Snippet1>
Imports System
Imports System.IO

Public Class BinaryRW

    Shared Sub Main()
    
        Dim invalidPathChars() As Char = Path.InvalidPathChars
        Dim memStream As new MemoryStream()
        Dim binWriter As New BinaryWriter(memStream)

        ' Write to memory.
        binWriter.Write("Invalid file path characters are: ")
        binWriter.Write(Path.InvalidPathChars)

        ' Create the reader using the same MemoryStream 
        ' as used with the writer.
        Dim binReader As New BinaryReader(memStream)

        ' Set Position to the beginning of the stream.
        memStream.Position = 0

        ' Read the data from memory and write it to the console.
        Console.Write(binReader.ReadString())
        Console.WriteLine(binReader.ReadChars( _
            CInt(memStream.Length - memStream.Position)))
    
	End Sub
End Class
' </Snippet1>