 'This is a list of commonly used namespaces for a pane.
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace ImageElementExample

    Partial Class SimpleImageExample
        Inherits Page
        Public Sub New()

        End Sub


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetSimpleCSharp1>
            ' Create the image element.
            Dim simpleImage As New Image()
            simpleImage.Width = 200
            simpleImage.Margin = New Thickness(5)

            ' Create source.
            Dim bi As New BitmapImage()
            ' BitmapImage.UriSource must be in a BeginInit/EndInit block.
            bi.BeginInit()
            bi.UriSource = New Uri("/sampleImages/cherries_larger.jpg", UriKind.RelativeOrAbsolute)
            bi.EndInit()
            ' Set the image source.
            simpleImage.Source = bi
            '</SnippetSimpleCSharp1>
            'Add Image to the UI
            Grid.SetColumn(simpleImage, 2)
            Grid.SetRow(simpleImage, 1)
            simpleGrid.Children.Add(simpleImage)

        End Sub
    End Class
End Namespace 'ImageElementExample
