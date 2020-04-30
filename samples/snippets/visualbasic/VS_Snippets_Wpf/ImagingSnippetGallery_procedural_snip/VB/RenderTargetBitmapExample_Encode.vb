 ' <SnippetRenderTargetBitmapEncodeCodeExampleWholePage>
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Globalization

Namespace SDKSample

    Class RenderTargetBitmapExample_Encode
        Inherits Page
 
        Public Sub New()

            '<SnippetRTBEncodeInline1>
            ' Base Image
            Dim bi As New BitmapImage()
            bi.BeginInit()
            bi.UriSource = New Uri("sampleImages/waterlilies.jpg", UriKind.Relative)
            bi.DecodePixelWidth = 200
            bi.EndInit()

            ' Text to render on the image.
            Dim [text] As New FormattedText("Waterlilies", New CultureInfo("en-us"), System.Windows.FlowDirection.LeftToRight, New Typeface(Me.FontFamily, FontStyles.Normal, FontWeights.Normal, New FontStretch()), Me.FontSize, Brushes.White)

            ' The Visual to use as the source of the RenderTargetBitmap.
            Dim drawingVisual As New DrawingVisual()
            Dim drawingContext As DrawingContext = drawingVisual.RenderOpen()
            drawingContext.DrawImage(bi, New Rect(0, 0, bi.Width, bi.Height))
            drawingContext.DrawText([text], New System.Windows.Point(bi.Height / 2, 0))
            drawingContext.Close()

            ' The BitmapSource that is rendered with a Visual.
            Dim rtb As New RenderTargetBitmap(bi.PixelWidth, bi.PixelHeight, 96, 96, PixelFormats.Pbgra32)
            rtb.Render(drawingVisual)

            ' Encoding the RenderBitmapTarget as a PNG file.
            Dim png As New PngBitmapEncoder()
            png.Frames.Add(BitmapFrame.Create(rtb))
            Dim stm As Stream = File.Create("new.png")
            Try
                png.Save(stm)
            Finally
                stm.Dispose()
            End Try
            '</SnippetRTBEncodeInline1>
            ' Image to display.
            Dim myImage As New Image()
            myImage.Width = 400
            myImage.Source = rtb

            ' Add Image to the UI
            Dim myStackPanel As New StackPanel()
            myStackPanel.Children.Add(myImage)
            Me.Content = myStackPanel

        End Sub
    End Class
End Namespace 'ImagingSnippetGallery

' </SnippetRenderTargetBitmapEncodeCodeExampleWholePage>