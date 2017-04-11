' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        ' Specify the directories you want to manipulate.
        Dim di As DirectoryInfo = New DirectoryInfo("c:\")

        Try
            'Get only subdirectories that contain the letter "p."
            Dim dirs As DirectoryInfo() = di.GetDirectories("*p*")
            Console.WriteLine("The number of directories containing the letter p is {0}.", dirs.Length)
            Dim diNext As DirectoryInfo
            For Each diNext In dirs
                Console.WriteLine("The number of files in {0} is {1}", diNext, _
                 diNext.GetFiles().Length)
            Next

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
