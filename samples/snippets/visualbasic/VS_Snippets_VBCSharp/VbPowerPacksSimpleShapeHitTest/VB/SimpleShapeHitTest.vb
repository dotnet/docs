Public Class SimpleShapeHitTest

    ' <Snippet1>
    Private Sub Form1_PreviewKeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs
      ) Handles Me.PreviewKeyDown

        If e.KeyCode = Keys.Space Then
            Dim px As Integer
            Dim py As Integer
            Dim hit As Boolean
            px = MousePosition.X
            py = MousePosition.Y
            hit = OvalShape1.HitTest(px, py)
            MsgBox(CStr(hit))
        End If
    End Sub
    ' </Snippet1>
End Class
