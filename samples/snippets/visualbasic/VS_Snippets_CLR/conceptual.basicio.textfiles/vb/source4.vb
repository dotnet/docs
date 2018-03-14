' <Snippet4>
Imports System
Imports System.IO

Public Class TextFromFile
    Private Const FILE_NAME As String = "MyFile.txt"

    Public Shared Sub Main()
        If Not File.Exists(FILE_NAME) Then
            Console.WriteLine("{0} does not exist.", FILE_NAME)
            Return
        End If
        Using sr As StreamReader = File.OpenText(FILE_NAME)
            Dim input As String
            Do
                input = sr.ReadLine()
                If Not (input Is Nothing) Then
                    Console.WriteLine(input)
                End If
            Loop Until input Is Nothing
            Console.WriteLine ("The end of the stream has been reached.")
        End Using
    End Sub
End Class
' </Snippet4>
