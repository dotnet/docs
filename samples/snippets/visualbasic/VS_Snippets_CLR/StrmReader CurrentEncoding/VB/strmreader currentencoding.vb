' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"
        Try
            If File.Exists(path) Then
                File.Delete(path)
            End If

            'Use an encoding other than the default (UTF8).
            Dim sw As StreamWriter = New StreamWriter(path, False, New UnicodeEncoding())
            sw.WriteLine("This")
            sw.WriteLine("is some text")
            sw.WriteLine("to test")
            sw.WriteLine("Reading")
            sw.Close()

            Dim sr As StreamReader = New StreamReader(path, True)

            Do While sr.Peek() >= 0
                Console.Write(Convert.ToChar(sr.Read()))
            Loop

            'Test for the encoding after reading, or at least
            'after the first read.
            Console.WriteLine("The encoding used was {0}.", sr.CurrentEncoding)
            Console.WriteLine()

            sr.Close()
        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>
