Namespace ButtonProps
    Partial Public Class Page1
        Inherits System.Windows.Controls.StackPanel
        Private Sub OnClickDefault(ByVal Sender As Object, ByVal e As RoutedEventArgs)

            '<Snippet3>
            If (btnDefault.IsDefault = True) Then

                btnDefault.Content = "This is the default button."

                If (btnDefault.IsDefaulted = True) Then

                    btnDefault.Content = "The button is defaulted."
                End If
            End If

            '</Snippet3>
        End Sub

        Public Sub New()
            InitializeComponent()
        End Sub

    End Class
End Namespace
