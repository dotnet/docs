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

    Partial Class CroppedImageExample
        Inherits Page

        Public Sub New()

        End Sub 'New


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetCroppedCSharp1>
            ' The new image element
            Dim croppedImage As New Image()
            croppedImage.Width = 200
            croppedImage.Margin = New Thickness(5)

            ' Create croppedbitmap based off of xaml defined resource.
            Dim cb As New CroppedBitmap(CType(Me.Resources("masterImage"), BitmapSource), New Int32Rect(30, 20, 105, 50))
            ' Select region rect and set image source to cropped
            croppedImage.Source = cb
            '</SnippetCroppedCSharp1>
            ' Add Image to the UI.
            Grid.SetColumn(croppedImage, 1)
            Grid.SetRow(croppedImage, 1)
            croppedGrid.Children.Add(croppedImage)

            '<SnippetCroppedCSharp2>
            ' The chained image element.
            Dim chainImage As New Image()
            chainImage.Width = 200
            chainImage.Margin = New Thickness(5)

            ' Create the cropped image based on previous croppedbitmap.
            Dim chained As New CroppedBitmap(cb, New Int32Rect(30, 0, CType(cb.Width - 30, Integer), CType(cb.Height, Integer)))
            ' select region
            ' Set the elements source
            chainImage.Source = chained
            '</SnippetCroppedCSharp2>
            ' Add Image to the UI.
            Grid.SetColumn(chainImage, 1)
            Grid.SetRow(chainImage, 3)
            croppedGrid.Children.Add(chainImage)

            '<SnippetCroppedCSharpUsingClip1>
            ' Create the image for clipping
            Dim clipImage As New Image()
            clipImage.Width = 200
            clipImage.Margin = New Thickness(5)

            'Create & Set source
            Dim bi As New BitmapImage()
            ' BitmapImage properties must be in a BeginInit/EndInit block
            bi.BeginInit()
            bi.UriSource = New Uri("pack://application:,,/sampleImages/gecko.jpg")
            bi.EndInit()
            clipImage.Source = bi

            ' Clip the using an EllipseGeometry
            Dim clipGeometry As New EllipseGeometry(New System.Windows.Point(75, 50), 50, 25)
            clipImage.Clip = clipGeometry
            '</SnippetCroppedCSharpUsingClip1>
            ' Add Image to the UI
            Grid.SetColumn(clipImage, 1)
            Grid.SetRow(clipImage, 5)
            croppedGrid.Children.Add(clipImage)

        End Sub 'PageLoaded 
    End Class 'CroppedImageExample 

End Namespace