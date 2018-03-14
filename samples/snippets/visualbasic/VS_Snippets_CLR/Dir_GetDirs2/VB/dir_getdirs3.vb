' <Snippet2>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        Try
            Dim dirs As String() = Directory.GetDirectories("c:\", "p*", SearchOption.TopDirectoryOnly)
            Console.WriteLine("The number of directories starting with p is {0}.", dirs.Length)
            Dim dir As String
            For Each dir In dirs
                Console.WriteLine(dir)
            Next
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet2>