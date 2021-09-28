 'This is a list of commonly used namespaces for a pane.
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging

Namespace ImageElementExample

    Class FormatConvertedExample
        Inherits Page
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class FormatConvertedExample : Page
        '-----------^--- 'class', 'struct', 'interface' or 'delegate' expected
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class FormatConvertedExample : Page
        '-------------------^--- Syntax error: ';' expected
        Public Sub New()

        End Sub


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetConvertedCSharp1>
            ' Create an Image element.
            Dim grayImage As New Image()
            grayImage.Width = 200
            grayImage.Margin = New Thickness(5)

            ' Create the image source using a xaml defined resource.
            Dim fcb As New FormatConvertedBitmap(CType(Me.Resources("masterImage"), BitmapImage), PixelFormats.Gray4, Nothing, 0)
            ' Set the image source.
            grayImage.Source = fcb
            '</SnippetConvertedCSharp1>
            ' Add Image to the UI.
            Grid.SetColumn(grayImage, 2)
            Grid.SetRow(grayImage, 1)
            convertedGrid.Children.Add(grayImage)

        End Sub
    End Class
End Namespace 'ImageElementExample
