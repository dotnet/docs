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

        Private Sub openDialog_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetWindowShowDialogCODE>
            ' Instantiate window
            Dim dialogBox As New DialogBox()

            ' Show window modally
            ' NOTE: Returns only when window is closed
            Dim dialogResult? As Boolean = dialogBox.ShowDialog()
            '</SnippetWindowShowDialogCODE>
        End Sub
    End Class
End Namespace