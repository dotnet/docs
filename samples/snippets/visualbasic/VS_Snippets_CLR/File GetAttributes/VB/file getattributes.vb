' <Snippet1>
Imports System
Imports System.IO
Imports System.Text

Public Class Test
    Public Shared Sub Main()
        Dim path As String = "c:\temp\MyTest.txt"

        ' Create the file if it does not exist.
        If File.Exists(path) = False Then
            File.Create(path)
        End If

        Dim attributes As FileAttributes
        attributes = File.GetAttributes(path)

        If (attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
            ' Show the file.
            attributes = RemoveAttribute(attributes, FileAttributes.Hidden)
            File.SetAttributes(path, attributes)
            Console.WriteLine("The {0} file is no longer hidden.", path)
        Else
            ' Hide the file.
            File.SetAttributes(path, File.GetAttributes(path) Or FileAttributes.Hidden)
            Console.WriteLine("The {0} file is now hidden.", path)
        End If
    End Sub

    Public Shared Function RemoveAttribute(ByVal attributes As FileAttributes, ByVal attributesToRemove As FileAttributes) As FileAttributes
        Return attributes And (Not attributesToRemove)
    End Function
End Class
' </Snippet1>
