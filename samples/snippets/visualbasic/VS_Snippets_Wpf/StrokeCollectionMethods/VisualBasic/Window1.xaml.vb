
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes



'/ <summary>
'/ Interaction logic for Window1.xaml
'/ </summary>
Namespace CustomInkControlSample

    Partial Public Class Window1
        Inherits Window

        Dim myInkSelector As New StrokeCollectionDemo()

        Public Sub New()
            InitializeComponent()
            myInkSelector.Background = Brushes.Green
            root.Children.Add(myInkSelector)

        End Sub

        ' To use Loaded event put Loaded="OnLoad" attribute in root element of .xaml file.
        ' private void OnLoad(object sender, EventArgs e) {}
        ' Sample event handler:  
        Private Sub erasePath_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.ErasePathHelper()

        End Sub

        Private Sub Window1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) _
            Handles Me.KeyDown

            If (e.Key = System.Windows.Input.Key.H) Then

                myInkSelector.InkDrawingAttributes.IsHighlighter = _
                            Not myInkSelector.InkDrawingAttributes.IsHighlighter
            End If

        End Sub

        Private Sub clipStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.ClipStrokesHelper()

        End Sub


        Private Sub eraseStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.EraseStrokesHelper()

        End Sub


        Private Sub RemoveStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.RemoveStrokesHelper()

        End Sub


        Private Sub CopyStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.CopyStrokes()

        End Sub


        Private Sub ToggleSelection(ByVal sender As Object, ByVal e As RoutedEventArgs)

            If myInkSelector.CurrentMode = InkMode.InkMode Then
                myInkSelector.CurrentMode = InkMode.SelectMode
                btnToggleMode.Content = "Ink Mode"

            Else
                myInkSelector.CurrentMode = InkMode.InkMode
                btnToggleMode.Content = "Edit Mode"
            End If

        End Sub


        Private Sub ClearCanvas_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.ClearStrokes()

        End Sub


        Private Sub SaveStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.SaveStrokes()

        End Sub


        Private Sub LoadStrokes_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            myInkSelector.LoadStrokes()

        End Sub


        Private Sub GetBounds_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

        End Sub
    End Class
End Namespace