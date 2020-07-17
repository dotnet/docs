 ' <SnippetChainedBitmapSourcesCodeExampleWholePage>
'This is a list of commonly used namespaces for a pane.
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace SDKSample

    Class ChainedBitmapSourcesExample
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

            '///////////////// Create a BitmapSource that Rotates the image //////////////////////
            ' Use the BitmapImage created above as the source for a new BitmapSource object
            ' that will be scaled to a different size. Create a new BitmapSource by   
            ' scaling the original one.                                               
            ' Note: New BitmapSource does not cache. It is always pulled when required.
            ' Create the new BitmapSource that will be used to scale the size of the source.
            Dim myRotatedBitmapSource As New TransformedBitmap()

            ' BitmapSource objects like TransformedBitmap can only have their properties
            ' changed within a BeginInit/EndInit block.
            myRotatedBitmapSource.BeginInit()

            ' Use the BitmapSource object defined above as the source for this BitmapSource.
            ' This creates a "chain" of BitmapSource objects which essentially inherit from each other.
            myRotatedBitmapSource.Source = myBitmapImage
            ' Multiply the size of the X and Y axis of the source by 3.
            myRotatedBitmapSource.Transform = New RotateTransform(90)
            myRotatedBitmapSource.EndInit()

            ' Create a new BitmapSource using a different format than the original one.
            Dim newFormatedBitmapSource As New FormatConvertedBitmap()

            ' BitmapSource objects like FormatConvertedBitmap can only have their properties
            ' changed within a BeginInit/EndInit block.
            newFormatedBitmapSource.BeginInit()
            newFormatedBitmapSource.Source = myRotatedBitmapSource
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


        Public Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)

        End Sub
    End Class
End Namespace
' </SnippetChainedBitmapSourcesCodeExampleWholePage>