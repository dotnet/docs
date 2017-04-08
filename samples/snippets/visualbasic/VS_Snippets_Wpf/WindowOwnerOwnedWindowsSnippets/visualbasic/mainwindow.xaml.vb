Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub createOwnedWindowButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetSetWindowOwnerCODE>
            ' Create a window and make this window its owner
            Dim ownedWindow As New Window()
            ownedWindow.Owner = Me
            ownedWindow.Show()
            '</SnippetSetWindowOwnerCODE>
        End Sub

        Private Sub enumerateOwnedWindowsButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            ' Enumerate the windows owned by this window
            '<SnippetGetWindowOwnedWindowsCODE>
            For Each ownedWindow As Window In Me.OwnedWindows
                Console.WriteLine(ownedWindow.Title)
            Next ownedWindow
            '</SnippetGetWindowOwnedWindowsCODE>
        End Sub
    End Class
End Namespace