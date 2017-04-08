' <Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Text

Class FStream

    Shared Sub Main()

        Const fileName As String = "Test#@@#.dat"

        ' Create random data to write to the file.
        Dim dataArray(100000) As Byte
        Dim randomGenerator As New Random()
        randomGenerator.NextBytes(dataArray)

        Dim fileStream As FileStream = _
            new FileStream(fileName, FileMode.Create)
        Try

            ' Write the data to the file, byte by byte.
            For i As Integer = 0 To dataArray.Length - 1
                fileStream.WriteByte(dataArray(i))
            Next i

            ' Set the stream position to the beginning of the stream.
            fileStream.Seek(0, SeekOrigin.Begin)

            ' Read and verify the data.
            For i As Integer = 0 To _
                CType(fileStream.Length, Integer) - 1

                If dataArray(i) <> fileStream.ReadByte() Then
                    Console.WriteLine("Error writing data.")
                    Return
                End If
            Next i
            Console.WriteLine("The data was written to {0} " & _
                "and verified.", fileStream.Name)
        Finally
            fileStream.Close()
        End Try
    
    End Sub
End Class
' </Snippet1>