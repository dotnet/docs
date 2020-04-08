 ' <SnippetFormatConvertedBitmapCodeExampleWholePage>
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace SDKSample

    Class FormatConvertedBitmapExample
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
            ' which is set to a gray scale format using the FormatConvertedBitmap BitmapSource.                                               
            ' Note: New BitmapSource does not cache. It is always pulled when required.
            Dim newFormatedBitmapSource As New FormatConvertedBitmap()

            ' BitmapSource objects like FormatConvertedBitmap can only have their properties
            ' changed within a BeginInit/EndInit block.
            newFormatedBitmapSource.BeginInit()

            ' Use the BitmapSource object defined above as the source for this new 
            ' BitmapSource (chain the BitmapSource objects together).
            newFormatedBitmapSource.Source = myBitmapImage

            ' Set the new format to Gray32Float (grayscale).
            newFormatedBitmapSource.DestinationFormat = PixelFormats.Gray32Float
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

        End Sub
    End Class
End Namespace 'ImagingSnippetGallery

' </SnippetFormatConvertedBitmapCodeExampleWholePage>