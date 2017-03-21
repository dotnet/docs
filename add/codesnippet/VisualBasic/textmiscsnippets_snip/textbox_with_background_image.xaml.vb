' <SnippetTextBoxBackgroundCodeExampleWholePage>

Namespace SDKSample
    Partial Public Class TextBoxBackgroundExample
        Inherits Page

        Private Sub OnTextBoxTextChanged(ByVal sender As Object, ByVal e As TextChangedEventArgs)

            If myTextBox.Text = "" Then

                ' Create an ImageBrush.
                Dim textImageBrush As New ImageBrush()

                textImageBrush.ImageSource =
                    New BitmapImage(New Uri("TextBoxBackground.gif", UriKind.Relative))
                textImageBrush.AlignmentX = AlignmentX.Left
                textImageBrush.Stretch = Stretch.None

                ' Use the brush to paint the button's background.
                myTextBox.Background = textImageBrush

            Else

                myTextBox.Background = Nothing
            End If

        End Sub

    End Class

End Namespace
' </SnippetTextBoxBackgroundCodeExampleWholePage>