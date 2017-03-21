Namespace VisualBasic

    Partial Public Class Show1Window
        Inherits Window

        Public Sub New()
            InitializeComponent()
        End Sub

        '<SnippetMessageBoxShow1CODE>
        Private Sub showMessageBoxButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Configure message box
            Dim message As String = "Hello, MessageBox!"
            ' Show message box
            Dim result As MessageBoxResult = MessageBox.Show(message)
        End Sub
        '</SnippetMessageBoxShow1CODE>
    End Class
End Namespace