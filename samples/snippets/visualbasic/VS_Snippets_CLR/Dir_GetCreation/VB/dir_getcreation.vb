' <Snippet1>
Imports System
Imports System.IO

Public Class Test
    Public Shared Sub Main()
        Try
            ' Get the creation time of a well-known directory.
            Dim dt As DateTime = Directory.GetCreationTime(Environment.CurrentDirectory)

            ' Give feedback to the user.
            If DateTime.Now.Subtract(dt).TotalDays > 364 Then
                Console.WriteLine("This directory is over a year old.")
            ElseIf DateTime.Now.Subtract(dt).TotalDays > 30 Then
                Console.WriteLine("This directory is over a month old.")
            ElseIf DateTime.Now.Subtract(dt).TotalDays <= 1 Then
                Console.WriteLine("This directory is less than a day old.")
            Else
                Console.WriteLine("This directory was created on {0}", dt)
            End If

        Catch e As Exception
            Console.WriteLine("The process failed: {0}", e.ToString())
        End Try
    End Sub
End Class
' </Snippet1>