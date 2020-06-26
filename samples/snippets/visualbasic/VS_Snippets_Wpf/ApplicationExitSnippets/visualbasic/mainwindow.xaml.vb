Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Button_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim exitCode As Integer = (If(Me.successRadioButton.IsChecked = True, 0, 1))
            Application.Current.Shutdown(exitCode)

            '<SnippetAppExitCODE>
            ' Shutdown and return a non-default exit code
            Application.Current.Shutdown(-1)
            '</SnippetAppExitCODE>
        End Sub
    End Class
End Namespace