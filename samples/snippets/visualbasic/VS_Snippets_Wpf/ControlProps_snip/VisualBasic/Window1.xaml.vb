Namespace ControlProps
    Partial Public Class Pane1
        Inherits System.Windows.Controls.StackPanel

        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetControlEvents1>
        Private Sub ChangeBackground(ByVal Sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)

            If (btn.Background Is Brushes.Red) Then

                btn.Background = New LinearGradientBrush(Colors.LightBlue, Colors.SlateBlue, 90)
                btn.Content = "Control background changes from red to a blue gradient."

            Else
                btn.Background = Brushes.Red
                btn.Content = "Background"
            End If

        End Sub
        '</SnippetControlEvents1>

        '<SnippetControlEvents2>
        Private Sub ChangeForeground(ByVal Sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)

            If (btn1.Foreground Is Brushes.Green) Then
                btn1.Foreground = Brushes.Black
                btn1.Content = "Foreground"
            Else
                btn1.Foreground = Brushes.Green
                btn1.Content = "Control foreground(text) changes from black to green."
            End If

        End Sub
        '</SnippetControlEvents2>

        '<SnippetAdditionalControlProps1>
        Private Sub ChangeBorderThickness(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            If (btn9.BorderThickness.Left = 5.0) Then
                btn9.BorderThickness = New Thickness(2.0)
                btn9.Content = "Control BorderThickness changes from 5 to 2."

            Else
                btn9.BorderThickness = New Thickness(5.0)
                btn9.Content = "BorderThickness"
            End If

        End Sub
        '</SnippetAdditionalControlProps1>

        '<SnippetAdditionalControlProps2>
        Private Sub ChangeFontStretch(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            If (btn10.FontStretch = FontStretches.Condensed) Then

                btn10.FontStretch = FontStretches.Normal
                btn10.Content = "Control FontStretch changes from Condensed to Normal."
            Else
                btn10.Content = "FontStretch"
                btn10.FontStretch = FontStretches.Condensed
            End If

        End Sub
        '</SnippetAdditionalControlProps2>

        '<SnippetAdditionalControlProps3>
        Private Sub ChangePadding(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            If (btn11.Padding.Left = 5.0) Then
                btn11.Padding = New Thickness(2.0)
                btn11.Content = "Control Padding changes from 5 to 2."
            Else
                btn11.Padding = New Thickness(5.0)
                btn11.Content = "Padding"
            End If

        End Sub
        '</SnippetAdditionalControlProps3>

        '<SnippetAdditionalControlProps4>
        Private Sub IsTabStop(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            If (btn13.IsTabStop = True) Then
                btn13.Content = "Control is a tab stop."
            End If

        End Sub
        '</SnippetAdditionalControlProps4>

    End Class
End Namespace
