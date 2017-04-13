Public Class LineHitTestForm

    ' <Snippet1>
    Private Sub LineHitTestForm_PreviewKeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs
      ) Handles Me.PreviewKeyDown

        If e.KeyCode = Keys.Space Then
            Dim px As Integer
            Dim py As Integer
            Dim hit As Boolean
            px = LineHitTestForm.MousePosition.X
            py = LineHitTestForm.MousePosition.Y
            hit = LineShape1.HitTest(px, py)
            MsgBox(CStr(hit))
        End If
    End Sub
    ' </Snippet1>
End Class
