'<snippetImports>
Imports System.IO
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.Storage
Imports System.Net.Http
Imports Windows.Storage.Pickers

'</snippetImports>


''' <summary>

Partial Public NotInheritable Class MainPage
    Inherits Page
    Public Sub New()
        Me.InitializeComponent()
    End Sub


    '<snippet1>
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
    '</snippet1>

    '<snippet2>
    Private Async Sub button2_Click(sender As Object, e As RoutedEventArgs)


        ' Create an HttpClient and access an image as a stream.
        Dim client = New HttpClient()
        Dim stream As Stream = Await client.GetStreamAsync("https://learn.microsoft.com/en-us/dotnet/images/hub/featured-1.png")
        ' Create a .NET memory stream.
        Dim memStream = New MemoryStream()

        ' Convert the stream to the memory stream, because a memory stream supports seeking.
        Await stream.CopyToAsync(memStream)

        ' Set the start position.
        memStream.Position = 0

        ' Create a new bitmap image.
        Dim bitmap = New BitmapImage()

        ' Set the bitmap source to the stream, which is converted to a IRandomAccessStream.
        bitmap.SetSource(memStream.AsRandomAccessStream())

        ' Set the image control source to the bitmap.
        image1.Source = bitmap
    End Sub
    '</snippet2>
End Class

