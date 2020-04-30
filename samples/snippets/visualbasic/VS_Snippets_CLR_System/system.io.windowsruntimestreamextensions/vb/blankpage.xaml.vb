' <snippet2>
Imports System.IO
Imports Windows.Storage

NotInheritable Public Class BlankPage
    Inherits Page

    Private Async Sub CreateButton_Click(sender As Object, e As RoutedEventArgs)
        Dim newFile As StorageFile = Await ApplicationData.Current.LocalFolder.CreateFileAsync("testfile.txt")
        Dim streamNewFile = Await newFile.OpenAsync(FileAccessMode.ReadWrite)

        Using outputNewFile = streamNewFile.GetOutputStreamAt(0)
            Using writer As StreamWriter = New StreamWriter(outputNewFile.AsStreamForWrite())
                Await writer.WriteLineAsync("content for new file")
                Await writer.WriteLineAsync(UserText.Text)
            End Using
        End Using
    End Sub

    Private Async Sub VerifyButton_Click(sender As Object, e As RoutedEventArgs)
        Dim openedFile As StorageFile = Await ApplicationData.Current.LocalFolder.GetFileAsync("testfile.txt")
        Dim streamOpenedFile = Await openedFile.OpenAsync(FileAccessMode.Read)

        Using inputOpenedFile = streamOpenedFile.GetInputStreamAt(0)

            Using reader As StreamReader = New StreamReader(inputOpenedFile.AsStreamForRead())
                Results.Text = Await reader.ReadToEndAsync()
            End Using
        End Using
    End Sub
End Class
' </snippet2>