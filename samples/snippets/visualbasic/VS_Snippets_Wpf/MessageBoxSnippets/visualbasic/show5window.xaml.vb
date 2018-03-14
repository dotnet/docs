Namespace VisualBasic

    Partial Public Class Show5Window
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetMessageBoxShow5CODE>
        Private Sub showMessageBoxButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Configure message box
            Dim message As String = "Hello, MessageBox!"
            Dim caption As String = "Caption text"
            Dim buttons As MessageBoxButton = MessageBoxButton.OKCancel
            Dim icon As MessageBoxImage = MessageBoxImage.Information
            Dim defaultResult As MessageBoxResult = MessageBoxResult.OK
            ' Show message box
            Dim result As MessageBoxResult = MessageBox.Show(message, caption, buttons, icon, defaultResult)
        End Sub
        '</SnippetMessageBoxShow5CODE>
    End Class
End Namespace