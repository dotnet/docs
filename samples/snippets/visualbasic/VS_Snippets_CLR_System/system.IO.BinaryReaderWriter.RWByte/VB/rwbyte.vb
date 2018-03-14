' <Snippet1>
Imports System
Imports System.IO

Public Class BinaryRW

    Shared Sub Main()
    
        Dim i As Integer = 0

        ' Create random data to write to the stream.
        Dim writeArray(1000) As Byte
        Dim randomGenerator As New Random()
        randomGenerator.NextBytes(writeArray)

        Dim binWriter As New BinaryWriter(New MemoryStream())
        Dim binReader As New BinaryReader(binWriter.BaseStream)

        Try
        
            ' Write the data to the stream.
            Console.WriteLine("Writing the data.")
            For i = 0 To writeArray.Length - 1
                binWriter.Write(writeArray(i))
            Next i

            ' Set the stream position to the beginning of the stream.
            binReader.BaseStream.Position = 0

            ' Read and verify the data from the stream.
            For i = 0 To writeArray.Length - 1
                If binReader.ReadByte() <> writeArray(i) Then
                    Console.WriteLine("Error writing the data.")
                    Return
                End If
            Next i
            Console.WriteLine("The data was written and verified.")

        ' Catch the EndOfStreamException and write an error message.
        Catch ex As EndOfStreamException
            Console.WriteLine("Error writing the data: {0}", _
                ex.GetType().Name)
        End Try
    
    End Sub
End Class
' </Snippet1>