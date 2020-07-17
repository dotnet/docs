 'This is a list of commonly used namespaces for a pane.
Imports System.Windows
Imports System.Windows.Documents
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging


Namespace ImageElementExample

    Class SimpleImageExample
        Inherits Page
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class SimpleImageExample : Page
        '-----------^--- 'class', 'struct', 'interface' or 'delegate' expected
        '
        'ToDo: Error processing original source shown below
        '{
        '   public partial class SimpleImageExample : Page
        '-------------------^--- Syntax error: ';' expected
        Public Sub New()

        End Sub


        Private Sub PageLoaded(ByVal sender As Object, ByVal args As RoutedEventArgs)
            '<SnippetSimpleCSharp1>
            'Create Image Element
            Dim simpleImage As New Image()
            simpleImage.Width = 200
            simpleImage.Margin = New Thickness(5)

            'Create source
            Dim bi As New BitmapImage()
            'BitmapImage.UriSource must be in a BeginInit/EndInit block
            bi.BeginInit()
            bi.UriSource = New Uri("pack://application:,,/sampleImages/cherries_larger.jpg")
            bi.EndInit()
            'set image source
            simpleImage.Source = bi
            '</SnippetSimpleCSharp1>
            'Add Image to the UI
            Grid.SetColumn(simpleImage, 2)
            Grid.SetRow(simpleImage, 1)
            simpleGrid.Children.Add(simpleImage)

        End Sub
    End Class
End Namespace