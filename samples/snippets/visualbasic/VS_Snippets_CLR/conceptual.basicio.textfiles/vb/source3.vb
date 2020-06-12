' <Snippet3>
Imports System.IO

Class Test
    Public Shared Sub Main()
        Try
            ' Open the file using a stream reader.
            Using sr As New StreamReader("TestFile.txt")
                ' Read the stream to a string and write the string to the console.
                Dim line = sr.ReadToEnd()
                Console.WriteLine(line)
            End Using
        Catch e As IOException
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(e.Message)
        End Try
    End Sub
End Class
' </Snippet3>
