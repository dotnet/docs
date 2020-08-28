Imports System.IO

Module Program
    Public Sub Main()
        Try
            ' Open the file using a stream reader.
            Using sr As New StreamReader("TestFile.txt")
                ' Read the stream as a string and write the string to the console.
                Console.WriteLine(sr.ReadToEnd())
            End Using
        Catch e As IOException
            Console.WriteLine("The file could not be read:")
            Console.WriteLine(e.Message)
        End Try
    End Sub
End Module
