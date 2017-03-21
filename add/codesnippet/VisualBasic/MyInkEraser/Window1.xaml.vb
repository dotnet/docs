
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports MyInkEraser



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>
Namespace MyInkEraser
    Class Window1
        Inherits Window

        Dim inkEraser1 As New InkEraser

        Public Sub New()
            InitializeComponent()
            root.Children.Add(inkEraser1)
            inkEraser1.Background = Brushes.DarkSlateBlue

        End Sub 'New

        ' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        ' private void WindowLoaded(object sender, EventArgs e) {}
        ' Sample event handler:  
        Private Sub ToggleErase(ByVal sender As Object, ByVal e As RoutedEventArgs)

        End Sub 'ToggleErase

        'if (myInkEraser.Mode == InkMode.Ink)
        '{
        '    myInkEraser.Mode = InkMode.Erase;
        '    btnToggleMode.Content = "Ink Mode";
        '}
        'else
        '{
        '    myInkEraser.Mode = InkMode.Ink;
        '    btnToggleMode.Content = "Erase Mode";
        '}

        Private Sub ResetInk(ByVal sender As Object, ByVal e As RoutedEventArgs)
            inkEraser1.ResetInk()
        End Sub 'ResetInk

        'inkEraser1.ResetInk();

        Private Sub SaveStrokes(ByVal sender As Object, ByVal e As RoutedEventArgs)

        End Sub 'SaveStrokes
    End Class 'Window1 'string strokes = inkEraser1.SaveStrokes();

End Namespace