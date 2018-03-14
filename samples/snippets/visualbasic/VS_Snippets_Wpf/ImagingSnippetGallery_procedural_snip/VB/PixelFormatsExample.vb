
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Collections.Generic

Namespace SDKSample

    Class PixelFormatsExample
        Inherits Page

        Public Sub New()
            '<SnippetPixelFormatConversion>
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
            newFormatedBitmapSource.DestinationFormat = createPixelFormat()
            newFormatedBitmapSource.EndInit()
            '</SnippetPixelFormatConversion>
            ' Create Image Element
            Dim myImage As New Image()
            myImage.Width = 200
            'set image source
            myImage.Source = newFormatedBitmapSource

            ' Add Image to the UI
            Dim myStackPanel As New StackPanel()
            myStackPanel.Children.Add(myImage)

            ' Add TextBox
            ' TextBlock myTextBlock = new TextBlock();
            ' myTextBlock.Text = "Mask Value: " + stringOfValues + " bpp: " + bpp.ToString();
            ' myStackPanel.Children.Add(myTextBlock);
            Me.Content = myStackPanel

        End Sub 'New

        ' <SnippetPixelFormatExample1>
        Public Function createPixelFormat() As PixelFormat
            ' Create a PixelFormat object.
            Dim myPixelFormat As New PixelFormat()

            ' Make this PixelFormat a Gray32Float pixel format.
            myPixelFormat = PixelFormats.Gray32Float

            ' Get the number of bits-per-pixel for this format. Because
            ' the format is "Gray32Float", the float value returned will be 32.
            Dim bpp As Integer = myPixelFormat.BitsPerPixel

            ' Get the collection of masks associated with this format.
            Dim myChannelMaskCollection As IList(Of PixelFormatChannelMask) = (myPixelFormat.Masks)

            ' Capture the mask info in a string.
            Dim stringOfValues As String = " "
            Dim myMask As PixelFormatChannelMask
            For Each myMask In myChannelMaskCollection
                Dim myBytesCollection As IList(Of Byte) = myMask.Mask
                Dim myByte As Byte
                For Each myByte In myBytesCollection
                    stringOfValues = stringOfValues + myByte.ToString()
                Next myByte
            Next myMask

            ' Return the PixelFormat which, for example, could be 
            ' used to set the pixel format of a bitmap by using it to set
            ' the DestinationFormat of a FormatConvertedBitmap.
            Return myPixelFormat

        End Function 'createPixelFormat
    End Class 'PixelFormatsExample 
End Namespace 'ImagingSnippetGallery
' </SnippetPixelFormatExample1>