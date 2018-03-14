' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        Try
            ' Only get files that begin with the letter "c."
            Dim dirs As String() = Directory.GetFiles("c:\", "c*")
            Console.WriteLine("The number of files starting with c is {0}.", dirs.Length)
            Dim dir As String
            For Each dir In dirs
                Console.WriteLine(dir)
            Next
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>