
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
            myWindow.Title = "WDP Imaging Sample"
            Dim mySV As New ScrollViewer()

            '<Snippet4>
            Dim width As Integer = 128
            Dim height As Integer = width
            Dim stride As Integer = CType(width / 8, Integer)
            Dim pixels(height * stride) As Byte

            ' Define the image palette
            Dim myPalette As BitmapPalette = BitmapPalettes.WebPalette

            ' Creates a new empty image with the pre-defined palette
            '<Snippet2>
            Dim image As BitmapSource = System.Windows.Media.Imaging.BitmapSource.Create( _
                width, height, 96, 96, PixelFormats.Indexed1, myPalette, pixels, stride)
            '</Snippet2>
            '<Snippet3>
            Dim stream As New FileStream("new.wdp", FileMode.Create)
            Dim encoder As New WmpBitmapEncoder()
            Dim myTextBlock As New TextBlock()
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString()
            encoder.Frames.Add(BitmapFrame.Create(image))
            encoder.Save(stream)
            '</Snippet3>
            '</Snippet4>
            '<Snippet1>
            ' Open a Stream and decode a WDP image
            Dim imageStreamSource As New FileStream("tulipfarm.wdp", FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim decoder As New WmpBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            Dim bitmapSource As BitmapSource = decoder.Frames(0)

            ' Draw the Image
            Dim myImage As New Image()
            myImage.Source = bitmapSource
            myImage.Stretch = Stretch.None
            myImage.Margin = New Thickness(20)
            '</Snippet1>
            '<Snippet5>
            ' Open a Uri and decode a WDP image
            Dim myUri As New Uri("tulipfarm.wdp", UriKind.RelativeOrAbsolute)
            Dim decoder3 As New WmpBitmapDecoder(myUri, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            Dim bitmapSource3 As BitmapSource = decoder3.Frames(0)

            ' Draw the Image
            Dim myImage2 As New Image()
            myImage2.Source = bitmapSource3
            myImage2.Stretch = Stretch.None
            myImage2.Margin = New Thickness(20)
            '</Snippet5>
            '<Snippet6>
            Dim stream2 As New FileStream("tulipfarm.jpg", FileMode.Open)
            Dim decoder2 As New JpegBitmapDecoder(stream2, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            Dim bitmapSource2 As BitmapSource = decoder2.Frames(0)
            Dim stream3 As New FileStream("new2.wdp", FileMode.Create)
            Dim encoder2 As New WmpBitmapEncoder()
            encoder2.Frames.Add(BitmapFrame.Create(bitmapSource2))
            encoder2.Save(stream3)
            '</Snippet6>
            ' Define a StackPanel to host the decoded WDP images
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
            mainWindow.Content = mySV
            mainWindow.Show()

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
