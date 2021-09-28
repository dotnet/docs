Imports System.IO
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.Storage
Imports System.Net.Http
Imports Windows.Storage.Pickers

Private Async Sub button1_Click(sender As Object, e As RoutedEventArgs)
    ' Create a file picker.
    Dim picker As New FileOpenPicker()

    ' Set properties on the file picker such as start location and the type of files to display.
    picker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary
    picker.ViewMode = PickerViewMode.List
    picker.FileTypeFilter.Add(".txt")

    ' Show picker that enable user to pick one file.
    Dim result As StorageFile = Await picker.PickSingleFileAsync()

    If result IsNot Nothing Then
        Try
            ' Retrieve the stream. This method returns a IRandomAccessStreamWithContentType.
            Dim stream = Await result.OpenReadAsync()

            ' Convert the stream to a .NET stream using AsStreamForRead, pass to a 
            ' StreamReader and read the stream.
            Using sr As New StreamReader(stream.AsStream())
                TextBlock1.Text = sr.ReadToEnd()
            End Using
        Catch ex As Exception
            TextBlock1.Text = "Error occurred reading the file. " + ex.Message
        End Try
    Else
        TextBlock1.Text = "User did not pick a file"
    End If
End Sub
