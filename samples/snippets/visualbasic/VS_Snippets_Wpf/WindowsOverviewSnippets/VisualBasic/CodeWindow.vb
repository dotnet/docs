Imports System.Windows.Controls
Imports System.Windows

Namespace WindowsOverviewSnippetsVisualBasic
    Public Class CodeWindow
        Inherits Window
    End Class
End Namespace

Namespace WindowsOverviewSnippetsVisualBasic.CodeWindow2
    Public Class CodeWindow
        Inherits Window
        Public Sub New()
            ' Configure window
            Me.Title = "Window"
            Me.Width = 800
            Me.Height = 600

            ' Add content to the client area
            Dim button As New Button()
            button.Content = "Window Content"
            AddHandler button.Click, AddressOf button_Click
            Me.Content = button
        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            MessageBox.Show("Button was clicked.")
        End Sub
    End Class
End Namespace