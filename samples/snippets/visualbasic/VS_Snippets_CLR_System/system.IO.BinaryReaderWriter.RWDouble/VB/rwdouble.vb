' <Snippet1>
Imports System
Imports System.IO

Public Class BinaryRW

    Shared Sub Main()
    
        Dim i As Integer
        Const upperBound As Integer = 1000

        ' Create random data to write to the stream.
        Dim dataArray(upperBound) As Double
        Dim randomGenerator As New Random()
        For i = 0 To upperBound
            dataArray(i) = 100.1 * randomGenerator.NextDouble()
        Next i

        Dim binWriter As New BinaryWriter(New MemoryStream())
        Try

            ' Write data to the stream.
            Console.WriteLine("Writing data to the stream.")
            
            For i = 0 To upperBound
                binWriter.Write(dataArray(i))
            Next i

            ' Create a reader using the stream from the writer.
            Dim binReader As New BinaryReader(binWriter.BaseStream)

            ' Return to the beginning of the stream.
            binReader.BaseStream.Position = 0

            ' Read and verify the data.
            Try
                Console.WriteLine("Verifying the written data.")
                For i = 0 To upperBound
                    If binReader.ReadDouble() <> dataArray(i) Then
                        Console.WriteLine("Error writing data.")
                        Exit For
                    End If
                Next i
                Console.WriteLine("The data was written and verified.")
            Catch ex As EndOfStreamException
                Console.WriteLine("Error writing data: {0}.", _
                    ex.GetType().Name)
            End Try
        Finally
            binWriter.Close()
        End Try

    End Sub
End Class
' </Snippet1>