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

    Class TransformedImageExample
        Inherits Page
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class TransformedImageExample : Page
        '-----------^--- 'class', 'struct', 'interface' or 'delegate' expected
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class TransformedImageExample : Page
        '-------------------^--- Syntax error: ';' expected
        Public Sub New()

        End Sub 'New


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetTransformedCSharp1>
            'Create Image element
            Dim rotated270 As New Image()
            rotated270.Width = 150

            'Create source
            Dim bi As New BitmapImage()
            'BitmapImage properties must be in a BeginInit/EndInit block
            bi.BeginInit()
            bi.UriSource = New Uri("pack://application:,,/sampleImages/watermelon.jpg")
            'Set image rotation
            bi.Rotation = Rotation.Rotate270
            bi.EndInit()
            'set image source
            rotated270.Source = bi
            '</SnippetTransformedCSharp1>
            'Add Image to the UI
            Grid.SetColumn(rotated270, 1)
            Grid.SetRow(rotated270, 1)
            transformedGrid.Children.Add(rotated270)

        End Sub 'PageLoaded 
    End Class 'TransformedImageExample
End Namespace