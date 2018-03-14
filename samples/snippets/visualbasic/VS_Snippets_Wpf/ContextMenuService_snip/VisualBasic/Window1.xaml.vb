Namespace ContextMenus
    Partial Public Class Window1
        Inherits System.Windows.Window

        Public Sub New()
            InitializeComponent()
        End Sub
        '<SnippetContextMenuServiceEventHandlers>
        Private Sub OnOpening(ByVal Sender As Object, ByVal e As ContextMenuEventArgs)
            cmButton.Content = "ContextMenu is opening."
        End Sub
        Private Sub OnClosing(ByVal Sender As Object, ByVal e As ContextMenuEventArgs)
            cmButton.Content = "ContextMenu is closing."
        End Sub
        '</SnippetContextMenuServiceEventHandlers>

    End Class
End Namespace
