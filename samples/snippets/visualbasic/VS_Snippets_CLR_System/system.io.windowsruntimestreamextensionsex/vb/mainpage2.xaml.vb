Imports System.IO
Imports System.Runtime.InteropServices.WindowsRuntime
Imports Windows.UI.Xaml
Imports Windows.UI.Xaml.Controls
Imports Windows.UI.Xaml.Media.Imaging
Imports Windows.Storage
Imports System.Net.Http
Imports Windows.Storage.Pickers

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
