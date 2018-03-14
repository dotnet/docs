 ' <SnippetFormatConvertedBitmapCodeExample2WholePage>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Collections.Generic

Namespace SDKSample

    Class FormatConvertedBitmapExample2
        Inherits Page

        Public Sub New()

            '/// Create a BitmapImage and set it's DecodePixelWidth to 200. Use  /////
            '/// this BitmapImage as a source for other BitmapSource objects.    /////
            Dim myBitmapImage As New BitmapImage()

            ' BitmapSource objects like BitmapImage can only have their properties
            ' changed within a BeginInit/EndInit block.
            myBitmapImage.BeginInit()
            myBitmapImage.UriSource = New Uri("sampleImages/WaterLilies.jpg", UriKind.Relative)

            ' To save significant application memory, set the DecodePixelWidth or  
            ' DecodePixelHeight of the BitmapImage value of the image source to the desired 
            ' height or width of the rendered image. If you don't do this, the application will 
            ' cache the image as though it were rendered as its normal size rather then just 
            ' the size that is displayed.
            ' Note: In order to preserve aspect ratio, set DecodePixelWidth
            ' or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 200
            myBitmapImage.EndInit()

            '//////// Convert the BitmapSource to a new format ////////////
            ' Use the BitmapImage created above as the source for a new BitmapSource object
            ' which is set to a two color pixel format using the FormatConvertedBitmap BitmapSource.                                               
            ' Note: New BitmapSource does not cache. It is always pulled when required.
            Dim newFormatedBitmapSource As New FormatConvertedBitmap()

            ' BitmapSource objects like FormatConvertedBitmap can only have their properties
            ' changed within a BeginInit/EndInit block.
            newFormatedBitmapSource.BeginInit()

            ' Use the BitmapSource object defined above as the source for this new 
            ' BitmapSource (chain the BitmapSource objects together).
            newFormatedBitmapSource.Source = myBitmapImage

            ' Because the DestinationFormat for the FormatConvertedBitmap will be an
            ' indexed pixel format (Indexed1),a DestinationPalette also needs to be specified.
            ' Below, create a custom two color palette to be used for the DestinationPalette.
            Dim colors As New List(Of Color)
            colors.Add(System.Windows.Media.Colors.Red)
            colors.Add(System.Windows.Media.Colors.Blue)
            Dim myPalette As New BitmapPalette(colors)

            ' Set the DestinationPalette property to the custom palette created above.
            newFormatedBitmapSource.DestinationPalette = myPalette

            ' Set the DestinationFormat to the palletized pixel format of Indexed1.
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Indexed1
            newFormatedBitmapSource.EndInit()

            ' Create Image Element
            Dim myImage As New Image()
            myImage.Width = 200
            'set image source
            myImage.Source = newFormatedBitmapSource

            ' Add Image to the UI
            Dim myStackPanel As New StackPanel()
            myStackPanel.Children.Add(myImage)
            Me.Content = myStackPanel

        End Sub 'New
    End Class 'FormatConvertedBitmapExample2
End Namespace 'ImagingSnippetGallery
' </SnippetFormatConvertedBitmapCodeExample2WholePage>