'<SnippetCodeWindow>
Imports System.Windows
Imports System.Windows.Controls

Namespace SDKSample

    Public Class CodeWindow
        Inherits Window

        Public Sub New()

            Me.Title = "WPF Window with Button"

            'Create button
            Dim button As New Button()
            button.Content = "Click Me!"

            'Add button to window
            Me.Content = button

            'Register event handler with button click event
            AddHandler button.Click, New RoutedEventHandler(AddressOf Me.button_Click)

        End Sub

        Private Sub button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)

            'Show message box when button is clicked
            MessageBox.Show("Hello, Windows Presentation Foundation!")

        End Sub

    End Class

End Namespace
'</SnippetCodeWindow>