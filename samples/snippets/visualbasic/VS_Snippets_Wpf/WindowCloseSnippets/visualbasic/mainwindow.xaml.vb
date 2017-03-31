Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub
        '<SnippetWindowCloseCODEBEHIND>
        Private Sub fileExitMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Close this window
            Me.Close()
        End Sub
        '</SnippetWindowCloseCODEBEHIND>
    End Class
End Namespace