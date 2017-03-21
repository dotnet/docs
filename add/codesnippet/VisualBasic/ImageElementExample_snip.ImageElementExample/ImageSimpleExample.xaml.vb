 'This is a list of commonly used namespaces for a pane.
Imports System
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace ImageElementExample

    Class ImageSimpleExample
        Inherits Page
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class ImageSimpleExample : Page
        '-----------^--- 'class', 'struct', 'interface' or 'delegate' expected
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class ImageSimpleExample : Page
        '-------------------^--- Syntax error: ';' expected
        Public Sub New()

        End Sub 'New


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetImageSimpleExampleInlineCode1>
            ' Create Image Element
            Dim myImage As New Image()
            myImage.Width = 200

            ' Create source
            Dim myBitmapImage As New BitmapImage()

            ' BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit()
            myBitmapImage.UriSource = New Uri("C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Water Lilies.jpg")

            ' To save significant application memory, set the DecodePixelWidth or  
            ' DecodePixelHeight of the BitmapImage value of the image source to the desired 
            ' height or width of the rendered image. If you don't do this, the application will 
            ' cache the image as though it were rendered as its normal size rather then just 
            ' the size that is displayed.
            ' Note: In order to preserve aspect ratio, set DecodePixelWidth
            ' or DecodePixelHeight but not both.
            myBitmapImage.DecodePixelWidth = 200
            myBitmapImage.EndInit()
            'set image source
            myImage.Source = myBitmapImage
            '</SnippetImageSimpleExampleInlineCode1>
            ' Add Image to the UI
            myStackPanel.Children.Add(myImage)

            '/////////////////////// Next Snippet //////////////////////
            '<SnippetImageSimpleExampleInlineCode2>
            Dim myImage1 As New Image()

            ' Set the stretch property.
            myImage1.Stretch = Stretch.Fill

            ' Set the StretchDirection property.
            myImage1.StretchDirection = StretchDirection.Both

            ' Create source
            Dim myBitmapImage1 As New BitmapImage()

            ' BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage1.BeginInit()
            myBitmapImage1.UriSource = New Uri("C:\Documents and Settings\All Users\Documents\My Pictures\Sample Pictures\Winter.jpg")
            myBitmapImage1.EndInit()

            'set image source
            myImage1.Source = myBitmapImage1
            '</SnippetImageSimpleExampleInlineCode2>
            ' Add Image to the UI
            myStackPanel.Children.Add(myImage1)

        End Sub 'PageLoaded
    End Class 'ImageSimpleExample 
End Namespace