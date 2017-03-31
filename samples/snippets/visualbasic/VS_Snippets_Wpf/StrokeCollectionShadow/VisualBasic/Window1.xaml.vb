
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>
Namespace StrokeCollectionShadow

    Class Window1
        Inherits Window

        Dim myInkSelector As New Ink3d()
        Public Sub New()
            InitializeComponent()


            myInkSelector.Background = Brushes.Green
            root.Children.Add(myInkSelector)

        End Sub 'New


        ' To use Loaded event put Loaded="WindowLoaded" attribute in root element of .xaml file.
        ' private void WindowLoaded(object sender, EventArgs e) {}
        ' Sample event handler:  
        Private Sub Toggle3d_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.Shadowed = Not myInkSelector.Shadowed

        End Sub 'Toggle3d_Click
    End Class 'Window1 
End Namespace