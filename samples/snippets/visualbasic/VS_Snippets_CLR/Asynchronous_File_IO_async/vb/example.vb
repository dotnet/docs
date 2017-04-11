'<snippet1>
Imports System.IO

Class MainWindow

    Private Async Sub Button_Click(sender As Object, e As RoutedEventArgs)
        Dim StartDirectory As String = "c:\Users\exampleuser\start"
        Dim EndDirectory As String = "c:\Users\exampleuser\end"

        For Each filename As String In Directory.EnumerateFiles(StartDirectory)
            Using SourceStream As FileStream = File.Open(filename, FileMode.Open)
                Using DestinationStream As FileStream = File.Create(EndDirectory + filename.Substring(filename.LastIndexOf("\"c)))
                    Await SourceStream.CopyToAsync(DestinationStream)
                End Using

            End Using
        Next
    End Sub

End Class
'</snippet1>