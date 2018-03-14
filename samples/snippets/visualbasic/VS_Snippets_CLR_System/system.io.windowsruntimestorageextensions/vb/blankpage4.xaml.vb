' <snippet8>
Imports System.IO
Imports Windows.Storage

NotInheritable Public Class BlankPage
    Inherits Page

    Private Async Sub CreateButton_Click(sender As Object, e As RoutedEventArgs)
        Using writer As StreamWriter =
               New StreamWriter(Await ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(
               "testfile.txt", CreationCollisionOption.OpenIfExists))
            Await writer.WriteLineAsync("new entry")
            Await writer.WriteLineAsync(UserText.Text)
        End Using
    End Sub

    Private Async Sub VerifyButton_Click(sender As Object, e As RoutedEventArgs)
        Dim openedFile As StorageFile = Await ApplicationData.Current.LocalFolder.GetFileAsync("testfile.txt")
        Using reader As StreamReader = New StreamReader(Await openedFile.OpenStreamForReadAsync())
            Results.Text = Await reader.ReadToEndAsync()
        End Using
    End Sub
End Class
' </snippet8>