 ' <SnippetCroppedBitmapCodeExampleWholePage>
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace SDKSample

    Class CroppedBitmapExample
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

            '//////// Crop the BitmapSource ////////////
            ' Use the BitmapImage created above as the source for a new BitmapSource object
            ' which is cropped.                                               
            ' Note: New BitmapSource does not cache. It is always pulled when required.
            Dim myCroppedBitmap As New CroppedBitmap()

            ' BitmapSource objects like CroppedBitmap can only have their properties
            ' changed within a BeginInit/EndInit block.
            myCroppedBitmap.BeginInit()

            ' Use the BitmapSource object defined above as the source for this new 
            ' BitmapSource (chain the BitmapSource objects together).
            myCroppedBitmap.Source = myBitmapImage

            ' Crop the image to the rectangular area defined below. 
            ' The image is cropped to 80 pixels less in width and 60 less 
            ' in height then the original source.
            myCroppedBitmap.SourceRect = New Int32Rect(0, 0, _
                CType(myBitmapImage.Width - 80, Integer), _
                CType(myBitmapImage.Height - 60, Integer))
            myCroppedBitmap.EndInit()

            ' Create Image Element
            Dim myImage As New Image()
            myImage.Width = 200
            'set image source
            myImage.Source = myCroppedBitmap

            ' Add Image to the UI
            Dim myStackPanel As New StackPanel()
            myStackPanel.Children.Add(myImage)
            Me.Content = myStackPanel

        End Sub 'New
    End Class 'CroppedBitmapExample
End Namespace 'ImagingSnippetGallery

' </SnippetCroppedBitmapCodeExampleWholePage>