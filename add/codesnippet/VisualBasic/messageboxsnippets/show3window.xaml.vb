Namespace VisualBasic

    Partial Public Class Show3Window
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetMessageBoxShow3CODE>
        Private Sub showMessageBoxButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Configure message box
            Dim message As String = "Hello, MessageBox!"
            Dim caption As String = "Caption text"
            Dim buttons As MessageBoxButton = MessageBoxButton.OKCancel
            ' Show message box
            Dim result As MessageBoxResult = MessageBox.Show(message, caption, buttons)
        End Sub
        '</SnippetMessageBoxShow3CODE>
    End Class
End Namespace