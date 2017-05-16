'<SnippetMainWindowSetWindowsCODEBEHIND1>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls

Namespace VisualBasic
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()
        End Sub
        '</SnippetMainWindowSetWindowsCODEBEHIND1>
        Private Sub newWindowMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim newWindow As New MainWindow()
            newWindow.Show()
        End Sub

        Private Sub exitMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Me.Close()
        End Sub
        '<SnippetMainWindowSetWindowsCODEBEHIND2>
        Private Sub MainWindow_Activated(ByVal sender As Object, ByVal e As EventArgs)
            Me.windowMenuItem.Items.Clear()
            Dim windowCount As Integer = 0
            For Each window As Window In Application.Current.Windows
                windowCount += 1
                Dim menuItem As New WindowMenuItem()
                menuItem.Window = window
                menuItem.Header = "_" & windowCount.ToString() & " Window " & windowCount.ToString()
                AddHandler menuItem.Click, AddressOf menuItem_Click
                Me.windowMenuItem.Items.Add(menuItem)
            Next window
        End Sub

        Private Sub menuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim menuItem As WindowMenuItem = CType(sender, WindowMenuItem)
            menuItem.Window.Activate()
        End Sub
    End Class
End Namespace
'</SnippetMainWindowSetWindowsCODEBEHIND2>