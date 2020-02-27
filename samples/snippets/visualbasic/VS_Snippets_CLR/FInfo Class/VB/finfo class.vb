' <Snippet1>
Imports System.IO

Public Class Test

    Public Shared Sub Main()
        Dim path1 As String = Path.GetTempFileName()
        Dim path2 As String = Path.GetTempFileName()
        Dim fi As New FileInfo(path1)

        ' Create a file to write to.
        Using sw As StreamWriter = fi.CreateText()
            sw.WriteLine("Hello")
            sw.WriteLine("And")
            sw.WriteLine("Welcome")
        End Using

        Try
            ' Open the file to read from.
            Using sr As StreamReader = fi.OpenText()
                Do While sr.Peek() >= 0
                    Console.WriteLine(sr.ReadLine())
                Loop
            End Using

            Dim fi2 As New FileInfo(path2)

            ' Ensure that the target does not exist.
            fi2.Delete()

            ' Copy the file.
            fi.CopyTo(path2)
            Console.WriteLine($"{path1} was copied to {path2}.")

            ' Delete the newly created file.
            fi2.Delete()
            Console.WriteLine($"{path2} was successfully deleted.")

        Catch e As Exception
            Console.WriteLine($"The process failed: {e.ToString()}.")
        End Try
    End Sub
End Class
' </Snippet1>
