 '<SnippetBitmapSourceFullPage>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace SDKSample

    Class BitmapSourceExample
        Inherits Page
  
        Public Sub New()
            '<SnippetBitmapSourceCreate>
            ' Define parameters used to create the BitmapSource.
            Dim pf As PixelFormat = PixelFormats.Bgr32
            Dim width As Integer = 200
            Dim height As Integer = 200
            Dim rawStride As Integer = CType((width * pf.BitsPerPixel + 7) / 8, Integer)
            Dim rawImage(rawStride * height) As Byte

            ' Initialize the image with data.
            Dim value As New Random()
            value.NextBytes(rawImage)

            ' Create a BitmapSource.
            Dim bitmap As BitmapSource = BitmapSource.Create(width, height, 96, 96, pf, Nothing, rawImage, rawStride)

            ' Create an image element;
            Dim myImage As New Image()
            myImage.Width = 200
            ' Set image source.
            myImage.Source = bitmap
            '</SnippetBitmapSourceCreate>
            ' Add the Image to the UI.
            Dim myStackPanel As New StackPanel()
            myStackPanel.Children.Add(myImage)
            Me.Content = myStackPanel

        End Sub
    End Class
End Namespace
'</SnippetBitmapSourceFullPage>