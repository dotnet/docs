 ' <SnippetRenderTargetBitmapCodeExampleWholePage>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Globalization

Namespace SDKSample

    Class RenderTargetBitmapExample
        Inherits Page

        Public Sub New()

            '<SnippetCreateRTBImage>
            Dim myImage As New Image()
            Dim [text] As New FormattedText("ABC", New CultureInfo("en-us"), System.Windows.FlowDirection.LeftToRight, New Typeface(Me.FontFamily, FontStyles.Normal, FontWeights.Normal, New FontStretch()), Me.FontSize, Me.Foreground)

            Dim drawingVisual As New DrawingVisual()
            Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()
            drawingContext.DrawText([text], New System.Windows.Point(2, 2))
            drawingContext.Close()

            Dim bmp As New RenderTargetBitmap(180, 180, 120, 96, PixelFormats.Pbgra32)
            bmp.Render(drawingVisual)
            myImage.Source = bmp
            '</SnippetCreateRTBImage>
            ' Add Image to the UI
            Dim myStackPanel As New StackPanel()
            myStackPanel.Children.Add(myImage)
            Me.Content = myStackPanel

        End Sub
    End Class
End Namespace 'ImagingSnippetGallery

' </SnippetRenderTargetBitmapCodeExampleWholePage>