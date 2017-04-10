Imports System
Imports System.Windows

Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub showDialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim dialogBox As New DialogBox()
            Dim dialogResult? As Boolean = dialogBox.ShowDialog()
            MessageBox.Show(dialogResult.ToString())
        End Sub
    End Class
End Namespace