Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data
Imports System.Windows.Media


Namespace MenusVB

    '@ <summary>
    '@ Interaction logic for Pane1_xaml.xaml
    '@ </summary>
    Partial Class Pane1
        '<Snippet5>
        Private Sub OnClick(ByVal sender As Object, ByVal args As RoutedEventArgs)
            Dim mn As New Menu()
            mn.Background = Brushes.LightBlue

            Dim mi As New MenuItem()
            mi.Header = ("_File")

            Dim mi1 As New MenuItem()
            mi1.Header = ("_Cut")
            mi1.InputGestureText = "Ctrl+X"

            Dim mi2 As New MenuItem()
            mi2.Command = System.Windows.Input.ApplicationCommands.Copy
            mi2.Header = "_Copy"

            Dim mi3 As New MenuItem()
            mi3.Command = System.Windows.Input.ApplicationCommands.Paste
            mi3.Header = "_Paste"

            mn.Items.Add(mi)
            mi.Items.Add(mi1)
            mi.Items.Add(mi2)
            mi.Items.Add(mi3)

            cv2.Children.Add(mn)

        End Sub
        '</Snippet5>
    End Class

End Namespace