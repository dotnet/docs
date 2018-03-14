Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Data

Namespace ButtonAlign_vb

    '@ <summary>
    '@ Interaction logic for Pane1_xaml.xaml
    '@ </summary>
    Partial Class Pane1
        '<Snippet2>
        Private Sub OnClick1(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn1.Background = Brushes.LightBlue
        End Sub

        Private Sub OnClick2(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn2.Background = Brushes.Pink
        End Sub

        Private Sub OnClick3(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn1.Background = System.Windows.Media.Brushes.Pink
            btn2.Background = System.Windows.Media.Brushes.LightBlue
        End Sub
        '</Snippet2>

        Private Sub OnClick4(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Static NewColor As Integer = 0

            Select Case NewColor

                Case 0
                    btn4.Background = Brushes.Red
                    btn4.Foreground = Brushes.Beige
                    btn4.Content = "Font Size 10"
                    btn4.FontSize = 10

                Case 1
                    btn4.Background = Brushes.CadetBlue
                    btn4.Foreground = System.Windows.Media.Brushes.LemonChiffon
                    btn4.Content = "Font Size 12"
                    btn4.FontSize = 12

                Case 2
                    btn4.Background = Brushes.Purple
                    btn4.Foreground = Brushes.PeachPuff
                    btn4.Content = "Font Size 14"
                    btn4.FontSize = 14

                Case 3
                    btn4.Background = Brushes.BlanchedAlmond
                    btn4.Foreground = Brushes.DarkRed
                    btn4.Content = "Font Size 16"
                    btn4.FontSize = 16

                Case 4
                    btn4.Background = Brushes.Green
                    btn4.Foreground = Brushes.White
                    btn4.Content = "Font Size 18"
                    btn4.FontSize = 18

            End Select

            NewColor = NewColor + 1
            If NewColor > 4 Then
                NewColor = 0
            End If
        End Sub

        '<Snippet6>
        Private Sub OnClick5(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn6.FontSize = 16
            btn6.Content = "This is my favorite photo."
            btn6.Background = Brushes.Red
        End Sub
        '</Snippet6>

        Private Sub OnClick6(ByVal sender As Object, ByVal e As RoutedEventArgs)
            btn7.FontSize = 16
            txt.Text = "You clicked the button."
            btn7.Background = Brushes.Yellow
        End Sub
        Private Sub OnClick7(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<Snippet3>
            Dim btnvb As Button
            btnvb = New Button()
            btnvb.Content = "Created with Visual Basic code."
            btnvb.Background = SystemColors.ControlDarkDarkBrush
            btnvb.FontSize = SystemFonts.CaptionFontSize
            btnvb.FontWeight = SystemFonts.MessageFontWeight
            btnvb.FontFamily = SystemFonts.CaptionFontFamily
            cv2.Children.Add(btnvb)
            '</Snippet3>
        End Sub
                
    End Class

End Namespace