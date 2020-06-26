
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Threading
Imports System.Security

<Assembly: SecurityTransparent()> 

Namespace SDKSample

    Public Class app
        Inherits Application
        Private myWindow As Window


        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()

        End Sub

        Private Sub CreateAndShowMainWindow()

            ' Create the application's main window
            myWindow = New Window()
            myWindow.Title = "PNG Imaging Sample"
            Dim mySV As New ScrollViewer()

            '<Snippet4>
            Dim width As Integer = 128
            Dim height As Integer = 128
            Dim stride As Integer = width
            Dim pixels(height * stride) As Byte

            ' Define the image palette
            Dim myPalette As BitmapPalette = BitmapPalettes.Halftone256

            ' Creates a new empty image with the pre-defined palette
            '<SnippetPngEncoder>
            '<Snippet2>
            Dim image As BitmapSource = System.Windows.Media.Imaging.BitmapSource.Create( _
                width, height, 96, 96, PixelFormats.Indexed8, myPalette, pixels, stride)
            '</Snippet2>
            '<Snippet3>
            Dim stream As New FileStream("new.png", FileMode.Create)
            Dim encoder As New PngBitmapEncoder()
            Dim myTextBlock As New TextBlock()
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString()
            encoder.Interlace = PngInterlaceOption.On
            encoder.Frames.Add(BitmapFrame.Create(image))
            encoder.Save(stream)
            '</Snippet3>
            '</SnippetPngEncoder>
            '</Snippet4>
            '<Snippet1>
            ' Open a Stream and decode a PNG image
            Dim imageStreamSource As New FileStream("smiley.png", FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim decoder As New PngBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            Dim bitmapSource As BitmapSource = decoder.Frames(0)

            ' Draw the Image
            Dim myImage As New Image()
            myImage.Source = bitmapSource
            myImage.Stretch = Stretch.None
            myImage.Margin = New Thickness(20)
            '</Snippet1>
            '<Snippet5>
            ' Open a Uri and decode a PNG image
            Dim myUri As New Uri("smiley.png", UriKind.RelativeOrAbsolute)
            Dim decoder2 As New PngBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            Dim bitmapSource2 As BitmapSource = decoder2.Frames(0)

            ' Draw the Image
            Dim myImage2 As New Image()
            myImage2.Source = bitmapSource2
            myImage2.Stretch = Stretch.None
            myImage2.Margin = New Thickness(20)
            '</Snippet5>
            ' Define a StackPanel to host the decoded PNG images
            Dim myStackPanel As New StackPanel()
            myStackPanel.Orientation = Orientation.Vertical
            myStackPanel.VerticalAlignment = VerticalAlignment.Stretch
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch

            ' Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage)
            myStackPanel.Children.Add(myImage2)
            myStackPanel.Children.Add(myTextBlock)

            ' Add the StackPanel as the Content of the Parent Window Object
            mySV.Content = myStackPanel
            myWindow.Content = mySV
            myWindow.Show()

        End Sub
    End Class

    ' Define a static entry class

    Friend NotInheritable Class EntryClass

        <System.STAThread()> _
        Public Shared Sub Main()
            Dim app As New app()
            app.Run()

        End Sub
    End Class
End Namespace 'SDKSample
