Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub newWindowMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetWindowShowCODE>
            ' Initialize window
            Dim window As New Window()

            ' Show window modelessly
            ' NOTE: Returns without waiting for window to close
            window.Show()
            '</SnippetWindowShowCODE>
        End Sub
    End Class
End Namespace