' <Snippet1>
Imports System
Imports System.IO

Public Class Test

    Public Shared Sub Main()
        Dim path1 As String = Path.GetTempFileName()
        Dim path2 As String = Path.GetTempFileName()
        Dim fi As FileInfo = New FileInfo(path1)

        'Create a file to write to.
        Dim sw As StreamWriter = fi.CreateText()

        sw.WriteLine("Hello")
        sw.WriteLine("And")
        sw.WriteLine("Welcome")
        sw.Flush()
        sw.Close()

        Try
            'Open the file to read from.
            Dim sr As StreamReader = fi.OpenText()

            Do While sr.Peek() >= 0
                Console.WriteLine(sr.ReadLine())
            Loop
            sr.Close()
            Dim fi2 As FileInfo = New FileInfo(path2)

            'Ensure that the target does not exist.
            fi2.Delete()

            'Copy the file.
            fi.CopyTo(path2)
            Console.WriteLine("{0} was copied to {1}.", path1, path2)

            'Delete the newly created file.
            fi2.Delete()
            Console.WriteLine("{0} was successfully deleted.", path2)

        Catch e As Exception
            Console.WriteLine("The process failed: {0}.", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
