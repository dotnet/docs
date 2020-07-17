 'This is a list of commonly used namespaces for a pane.
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

        End Sub


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetCroppedCSharp1>
            ' Create an Image element.
            Dim croppedImage As New Image()
            croppedImage.Width = 200
            croppedImage.Margin = New Thickness(5)

            ' Create a CroppedBitmap based off of a xaml defined resource.
            Dim cb As New CroppedBitmap(CType(Me.Resources("masterImage"), BitmapSource), New Int32Rect(30, 20, 105, 50))
            'select region rect
            croppedImage.Source = cb 'set image source to cropped
            '</SnippetCroppedCSharp1>
            ' Add Image to the UI
            Grid.SetColumn(croppedImage, 1)
            Grid.SetRow(croppedImage, 1)
            croppedGrid.Children.Add(croppedImage)

            '<SnippetCroppedCSharp2>
            ' Create an Image element.
            Dim chainImage As New Image()
            chainImage.Width = 200
            chainImage.Margin = New Thickness(5)

            ' Create the cropped image based on previous CroppedBitmap.
            Dim chained As New CroppedBitmap(cb, New Int32Rect(30, 0, CType(cb.Width, Integer) - 30, CType(cb.Height, Integer)))
            ' Set the image's source.
            chainImage.Source = chained
            '</SnippetCroppedCSharp2>
            ' Add Image to the UI.
            Grid.SetColumn(chainImage, 1)
            Grid.SetRow(chainImage, 3)
            croppedGrid.Children.Add(chainImage)

        End Sub
    End Class
End Namespace 'ImageElementExample