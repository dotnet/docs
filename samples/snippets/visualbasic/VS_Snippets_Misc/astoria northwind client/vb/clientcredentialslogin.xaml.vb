'<snippetClientCredentialsLogin>
Imports System.ComponentModel
Imports System.Windows
Imports System.Security

Partial Public Class LoginWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub OKButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles OKButton.Click
        Me.DialogResult = True
        e.Handled = True
    End Sub

    Private Sub CancelButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs) Handles CancelButton.Click
        Me.DialogResult = False
        e.Handled = True
    End Sub

    Private Sub LoginWindow_Closing(ByVal sender As System.Object, ByVal e As CancelEventArgs)
        If Me.DialogResult = True AndAlso _
                    (Me.userNameBox.Text = String.Empty OrElse Me.passwordBox.SecurePassword.Length = 0) Then
            e.Cancel = True
            MessageBox.Show("Please enter name and password or click Cancel.")
        End If
    End Sub
End Class
'</snippetClientCredentialsLogin>   