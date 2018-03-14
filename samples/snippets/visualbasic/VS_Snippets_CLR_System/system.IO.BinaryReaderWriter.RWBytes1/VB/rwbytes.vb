' <Snippet1>
Imports System
Imports System.IO

Public Class BinaryRW

    Shared Sub Main()
    
        Const upperBound As Integer = 1000

        ' Create random data to write to the stream.
        Dim dataArray(upperBound) As Byte
        Dim randomGenerator As New Random
        randomGenerator.NextBytes(dataArray)

        Dim binWriter As New BinaryWriter(New MemoryStream())

        ' Write the data to the stream.
        Console.WriteLine("Writing the data.")
        binWriter.Write(dataArray)

        ' Create the reader using the stream from the writer.
        Dim binReader As New BinaryReader(binWriter.BaseStream)

        ' Set the stream position to the beginning of the stream.
        binReader.BaseStream.Position = 0

        ' Read and verify the data.
        Dim verifyArray() As Byte = _
            binReader.ReadBytes(dataArray.Length)
        If verifyArray.Length <> dataArray.Length Then
            Console.WriteLine("Error writing the data.")
            Return
        End If
        For i As Integer = 0 To upperBound
            If verifyArray(i) <> dataArray(i) Then
                Console.WriteLine("Error writing the data.")
                Return
            End If
        Next i
        Console.WriteLine("The data was written and verified.")
    
    End Sub
End Class
' </Snippet1>