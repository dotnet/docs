'<snippet3>
Imports System
Imports System.IO

Public Class ProcessFile
    Public Shared Sub Main()
        Try
            Dim sr As StreamReader = File.OpenText("data.txt")
            Console.WriteLine("The first line of this file is {0}", sr.ReadLine())
	    sr.Close()
        Catch e As Exception
            Console.WriteLine("An error occurred: '{0}'", e)
        End Try
    End Sub
End Class
'</snippet3>
