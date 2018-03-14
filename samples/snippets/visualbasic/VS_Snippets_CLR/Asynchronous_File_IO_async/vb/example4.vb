' <snippet4>
Imports System.IO
Imports System.Text

Class MainWindow
    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim filename As String = "c:\Temp\userinputlog.txt"

        Dim result As Byte()

        Using SourceStream As FileStream = File.Open(filename, FileMode.Open)
            result = New Byte(SourceStream.Length - 1) {}
            Await SourceStream.ReadAsync(result, 0, CType(SourceStream.Length, Integer))
        End Using

        UserInput.Text = System.Text.Encoding.ASCII.GetString(result)
    End Sub
End Class
' </snippet4>