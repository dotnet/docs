
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Threading
Imports System.Security.Permissions
Imports System.Collections.ObjectModel

Namespace SDKSample

    Public Class MyApp
        Inherits Application

        Private theWindow As Window


        Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()

        End Sub 'OnStartup

        <SecurityPermissionAttribute(SecurityAction.Demand, Flags:=SecurityPermissionFlag.UnmanagedCode)> Private Sub CreateAndShowMainWindow()

            ' Create the application's main window
            theWindow = New Window()
            theWindow.Title = "Imaging Sample"
            Dim mySV As New ScrollViewer()

            '<Snippet1>
            Dim width As Integer = 128
            Dim height As Integer = width
            Dim stride As Integer = CType(width / 8, Integer)
            Dim pixels(height * stride) As Byte

            ' Try creating a new image with a custom palette.
            Dim colors As New List(Of System.Windows.Media.Color)()
            colors.Add(System.Windows.Media.Colors.Red)
            colors.Add(System.Windows.Media.Colors.Blue)
            colors.Add(System.Windows.Media.Colors.Green)
            Dim myPalette As New BitmapPalette(colors)

            ' Creates a new empty image with the pre-defined palette
            '<Snippet2>
            Dim image As BitmapSource = System.Windows.Media.Imaging.BitmapSource.Create(width, height, 96, 96, PixelFormats.Indexed1, myPalette, pixels, stride)
            '</Snippet2>
            '<Snippet3>
            Dim stream As New FileStream("empty.tif", FileMode.Create)
            Dim encoder As New TiffBitmapEncoder()
            Dim myTextBlock As New TextBlock()
            myTextBlock.Text = "Codec Author is: " + encoder.CodecInfo.Author.ToString()
            encoder.Frames.Add(BitmapFrame.Create(image))
            MessageBox.Show(myPalette.Colors.Count.ToString())
            encoder.Save(stream)
            '</Snippet3>
            '</Snippet1>
            ' Draw the Image
            Dim myImage As New Image()
            myImage.Source = image
            myImage.Stretch = Stretch.None
            myImage.Margin = New Thickness(20)

            '<Snippet4>
            ' Open a Stream and decode a TIFF image
            Dim imageStreamSource As New FileStream("tulipfarm.tif", FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim decoder As New TiffBitmapDecoder(imageStreamSource, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default)
            Dim bitmapSource As BitmapSource = decoder.Frames(0)

            ' Draw the Image
            Dim myImage1 As New Image()
            myImage1.Source = bitmapSource
            myImage1.Stretch = Stretch.None
            myImage1.Margin = New Thickness(20)
            '</Snippet4>
            '<Snippet5>
            ' Get the palette from an image
            Dim image2 As New BitmapImage()
            image2.BeginInit()
            image2.UriSource = New Uri("tulipfarm.tif", UriKind.RelativeOrAbsolute)
            image2.EndInit()
            Dim myPalette3 As New BitmapPalette(image2, 256)

            'Draw the third Image
            Dim myImage2 As New Image()
            myImage2.Source = image2
            myImage2.Stretch = Stretch.None
            myImage2.Margin = New Thickness(20)
            '</Snippet5>
            '<Snippet6>
            'Create a new TIFF image based on existing Image
            Dim stream2 As New FileStream("image.tif", FileMode.Create)
            Dim encoder2 As New TiffBitmapEncoder()
            Dim decoder2 As New TiffBitmapDecoder(New Uri("tulipfarm.tif", UriKind.RelativeOrAbsolute), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None)
            encoder2.Frames = decoder2.Frames
            '<Snippet7>
            Dim tiffMetadata As New BitmapMetadata("tiff")
            tiffMetadata.SetQuery("/ifd/{ushort=1000}", 9999)
            tiffMetadata.SetQuery("/ifd/{uint=1001}", 23456)
            tiffMetadata.SetQuery("/ifd/{uint=1002}", 34567)
            tiffMetadata.SetQuery("/ifd/PaddingSchema:padding", CType(4096, UInt32))
            tiffMetadata.SetQuery("/ifd/exif", New BitmapMetadata("exif"))
            tiffMetadata.SetQuery("/ifd/exif/PaddingSchema:padding", CType(4096, UInt32))
            '</Snippet7>
            encoder2.Save(stream2)
            stream2.Close()
            '</Snippet6>
            '<Snippet9>
            Dim stream4 As New FileStream("image3.tif", FileMode.Create)
            Dim myBitmapMetadata2 As New BitmapMetadata("tiff")
            Dim encoder4 As New TiffBitmapEncoder()
            MessageBox.Show(myBitmapMetadata2.IsFixedSize.ToString())
            MessageBox.Show(myBitmapMetadata2.IsReadOnly.ToString())
            MessageBox.Show(myBitmapMetadata2.Format.ToString())
            MessageBox.Show(myBitmapMetadata2.Location.ToString())
            encoder4.Frames = decoder2.Frames
            encoder4.Save(stream4)
            stream4.Close()
            '</Snippet9>

            ' <Snippet8>
            Dim stream3 As New FileStream("image2.tif", FileMode.Create)
            Dim myBitmapMetadata As New BitmapMetadata("tiff")
            Dim encoder3 As New TiffBitmapEncoder()
            myBitmapMetadata.ApplicationName = "Microsoft Digital Image Suite 10"
            myBitmapMetadata.Author = New ReadOnlyCollection(Of String) _
                (New List(Of String)(New String() {"Lori Kane"}))
            myBitmapMetadata.CameraManufacturer = "Tailspin Toys"
            myBitmapMetadata.CameraModel = "TT23"
            myBitmapMetadata.Comment = "Nice Picture"
            myBitmapMetadata.Copyright = "2010"
            myBitmapMetadata.DateTaken = "5/23/2010"
            myBitmapMetadata.Keywords = New ReadOnlyCollection(Of String) _
                (New List(Of String)(New String() {"Lori", "Kane"}))
            myBitmapMetadata.Rating = 5
            myBitmapMetadata.Subject = "Lori"
            myBitmapMetadata.Title = "Lori's photo"

            ' Create a new frame that is identical to the one 
            ' from the original image, except for the new metadata. 
            encoder3.Frames.Add( _
                BitmapFrame.Create(decoder2.Frames(0), _
                decoder2.Frames(0).Thumbnail, _
                myBitmapMetadata, _
                decoder2.Frames(0).ColorContexts))

            encoder3.Save(stream3)
            stream3.Close()
            ' </Snippet8>
            '
            '<Snippet10>
            Dim image5 As BitmapSource = System.Windows.Media.Imaging.BitmapSource.Create(width, height, 96, 96, PixelFormats.Indexed1, BitmapPalettes.WebPalette, pixels, stride)

            Dim stream5 As New FileStream("palette.tif", FileMode.Create)
            Dim encoder5 As New TiffBitmapEncoder()
            encoder5.Frames.Add(BitmapFrame.Create(image5))
            encoder5.Save(stream5)
            '</Snippet10>
            ' Define a StackPanel to host Content
            Dim myStackPanel As New StackPanel()
            myStackPanel.Orientation = Orientation.Vertical
            myStackPanel.VerticalAlignment = VerticalAlignment.Stretch
            myStackPanel.HorizontalAlignment = HorizontalAlignment.Stretch

            ' Add the Image and TextBlock to the parent Grid
            myStackPanel.Children.Add(myImage)
            myStackPanel.Children.Add(myTextBlock)
            myStackPanel.Children.Add(myImage1)
            myStackPanel.Children.Add(myImage2)

            ' Add the StackPanel as the Content of the Parent Window Object
            mySV.Content = myStackPanel
            theWindow.Content = mySV
            theWindow.Show()

        End Sub 'CreateAndShowMainWindow
    End Class 'MyApp

    ' Define a static entry class

    Public NotInheritable Class EntryClass

        <System.STAThread()> _
        Public Shared Sub Main()
            Dim app As New MyApp()
            app.Run()

        End Sub 'Main
    End Class 'EntryClass

End Namespace 'SDKSample
