' <Snippet1>
Imports System
Imports System.IO

Public Class Test

    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"

        ' Delete the file if it exists.
        If File.Exists(path) Then
            File.Delete(path)
        End If

        'Create the file.
        Dim fs As FileStream = File.Create(path)

        If fs.CanSeek Then
            Console.WriteLine("The stream connected to {0} is seekable.", path)
        Else
            Console.WriteLine("The stream connected to {0} is not seekable.", path)
        End If

        fs.Close()
    End Sub
End Class
' </Snippet1>
