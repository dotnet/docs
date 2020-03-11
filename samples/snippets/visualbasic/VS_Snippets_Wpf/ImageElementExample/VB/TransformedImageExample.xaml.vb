 'This is a list of commonly used namespaces for a pane.
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace ImageElementExample

    Partial Class TransformedImageExample
        Inherits Page
        Public Sub New()

        End Sub


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetTransformedCSharp1>
            ' Create Image element.
            Dim rotated90 As New Image()
            rotated90.Width = 150

            ' Create the TransformedBitmap to use as the Image source.
            Dim tb As New TransformedBitmap()

            ' Create the source to use as the tb source.
            Dim bi As New BitmapImage()
            bi.BeginInit()
            bi.UriSource = New Uri("sampleImages/watermelon.jpg", UriKind.RelativeOrAbsolute)
            bi.EndInit()

            ' Properties must be set between BeginInit and EndInit calls.
            tb.BeginInit()
            tb.Source = bi
            ' Set image rotation.
            Dim transform As New RotateTransform(90)
            tb.Transform = transform
            tb.EndInit()
            ' Set the Image source.
            rotated90.Source = tb
            '</SnippetTransformedCSharp1>
            'Add Image to the UI
            Grid.SetColumn(rotated90, 1)
            Grid.SetRow(rotated90, 1)
            transformedGrid.Children.Add(rotated90)

        End Sub
    End Class
End Namespace 'ImageElementExample
