Namespace VisualBasic

    Partial Public Class Show2Window
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetMessageBoxShow2CODE>
        Private Sub showMessageBoxButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Configure message box
            Dim message As String = "Message text"
            Dim caption As String = "Caption text"
            ' Show message box
            Dim result As MessageBoxResult = MessageBox.Show(message, caption)
        End Sub
        '</SnippetMessageBoxShow2CODE>
    End Class
End Namespace