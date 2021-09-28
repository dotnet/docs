 '<SnippetBitmapDecoderFullPage>
Imports System.Windows
Imports System.IO
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace SDKSample

    Class BitmapDecoderExample
        Inherits Page
 
        Public Sub New()
            '<SnippetBitmapDecoderCreate>
            Dim uriBitmap As BitmapDecoder = BitmapDecoder.Create(New Uri("sampleImages/waterlilies.jpg", UriKind.Relative), BitmapCreateOptions.None, BitmapCacheOption.Default)

            ' Create an image element;
            Dim uriImage As New Image()
            uriImage.Width = 200
            ' Set image source.
            uriImage.Source = uriBitmap.Frames(0)
            '</SnippetBitmapDecoderCreate>
            '<SnippetBitmapDecoderCreateStream>
            Dim imageStream As FileStream = New FileStream("sampleImages/waterlilies.jpg", FileMode.Open, FileAccess.Read, FileShare.Read)

            Dim streamBitmap As BitmapDecoder = BitmapDecoder.Create(imageStream, BitmapCreateOptions.None, BitmapCacheOption.Default)

            ' Create an image element;
            Dim streamImage As New Image()
            streamImage.Width = 200
            ' Set image source using the first frame.
            streamImage.Source = streamBitmap.Frames(0)
            '</SnippetBitmapDecoderCreateStream>
            ' Add the Image to the UI.
            Dim myStackPanel As New StackPanel()
            myStackPanel.Children.Add(uriImage)
            myStackPanel.Children.Add(streamImage)
            Me.Content = myStackPanel

        End Sub
    End Class
End Namespace
'</SnippetBitmapDecoderFullPage>