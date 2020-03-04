Public Class ShapeContextMenu

    Private Sub ShapeContextMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OvalShape1.ContextMenu = ContextMenu1
    End Sub

    
    ' <Snippet1>
    Private Sub OvalShape1_MouseUp(
        ByVal sender As Object, 
        ByVal e As MouseEventArgs
      ) Handles OvalShape1.MouseUp

        ' If the right mouse button is clicked and released,
        ' display the shortcut menu assigned to the OvalShape. 
        If e.Button = MouseButtons.Right Then
            OvalShape1.ContextMenu.Show(Me, New Point(e.X, e.Y))
        End If
    End Sub
    ' </Snippet1>
End Class
