' <snippet3>
Imports System.IO
Imports System.Text

Class MainWindow
    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim uniencoding As UnicodeEncoding = New UnicodeEncoding()
        Dim filename As String = "c:\Users\exampleuser\Documents\userinputlog.txt"

        Dim result As Byte() = uniencoding.GetBytes(UserInput.Text)

        Using SourceStream As FileStream = File.Open(filename, FileMode.OpenOrCreate)
            SourceStream.Seek(0, SeekOrigin.End)
            Await SourceStream.WriteAsync(result, 0, result.Length)
        End Using
    End Sub
End Class
' </snippet3>
