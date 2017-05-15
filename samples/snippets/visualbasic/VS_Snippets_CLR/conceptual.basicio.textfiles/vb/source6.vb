' <snippet6>
Imports System.IO

Class MainWindow
    Private Async Sub ReadFileButton_Click(sender As Object, e As RoutedEventArgs)
        Try
            Using sr As StreamReader = New StreamReader("TestFile.txt")
                Dim line = Await sr.ReadToEndAsync()
                ResultBlock.Text = line
            End Using
        Catch
            ResultBlock.Text = "Could not read the file"
        End Try
    End Sub
End Class
' </snippet6>