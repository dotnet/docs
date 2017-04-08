' <Snippet1>
Imports System.IO

Module Module1

    Sub Main()
        Const upperBound As Integer = 1000
        Dim dataArray(upperBound) As Byte
        Dim verifyArray(upperBound) As Byte

        Dim randomGenerator As New Random
        randomGenerator.NextBytes(dataArray)

        Using binWriter As New BinaryWriter(New MemoryStream())
            Console.WriteLine("Writing the data.")
            binWriter.Write(dataArray, 0, dataArray.Length)

            Using binReader As New BinaryReader(binWriter.BaseStream)
                binReader.BaseStream.Position = 0

                If binReader.Read(verifyArray, 0, dataArray.Length) <> dataArray.Length Then
                    Console.WriteLine("Error writing the data.")
                    Return
                End If
            End Using
        End Using

        For i As Integer = 0 To upperBound
            If verifyArray(i) <> dataArray(i) Then
                Console.WriteLine("Error writing the data.")
                Return
            End If
        Next i

        Console.WriteLine("The data was written and verified.")
    End Sub

End Module
' </Snippet1>