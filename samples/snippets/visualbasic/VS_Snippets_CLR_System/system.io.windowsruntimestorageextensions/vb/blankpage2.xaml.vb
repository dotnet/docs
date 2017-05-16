' <snippet4>
Imports System.IO
Imports Windows.Storage

NotInheritable Public Class BlankPage
    Inherits Page

    Protected Overrides Sub OnNavigatedTo(e As Navigation.NavigationEventArgs)
        CreateTestFile()
    End Sub

    Private Async Sub CreateTestFile()
        Dim newFile As StorageFile = Await ApplicationData.Current.LocalFolder.CreateFileAsync("testfile.txt")
        Await FileIO.WriteTextAsync(newFile, "example content in file")
    End Sub

    Private Async Sub Button_Click_1(sender As Object, e As RoutedEventArgs)
        Using reader As StreamReader = New StreamReader(
                Await ApplicationData.Current.LocalFolder.OpenStreamForReadAsync("testfile.txt"))

            Dim contents As String = Await reader.ReadToEndAsync()
            DisplayContentsBlock.Text = contents
        End Using
    End Sub
End Class
' </snippet4>