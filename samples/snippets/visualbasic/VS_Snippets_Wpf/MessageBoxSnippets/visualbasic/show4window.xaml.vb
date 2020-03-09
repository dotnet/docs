Namespace VisualBasic

    Partial Public Class Show4Window
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetMessageBoxShow4CODE>
        Private Sub showMessageBoxButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Configure message box
            Dim message As String = "Hello, MessageBox!"
            Dim caption As String = "Caption text"
            Dim buttons As MessageBoxButton = MessageBoxButton.OKCancel
            Dim icon As MessageBoxImage = MessageBoxImage.Information
            ' Show message box
            Dim result As MessageBoxResult = MessageBox.Show(message, caption, buttons, icon)
        End Sub
        '</SnippetMessageBoxShow4CODE>
    End Class
End Namespace