    Private Sub Button1_PreviewKeyDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs
      ) Handles Button1.PreviewKeyDown

        ' Check for the Control and Tab keys.
        If e.KeyCode = Keys.Tab And e.Modifiers = Keys.Control Then
            ' Select the first shape.
            RectangleShape1.Select()
        End If
    End Sub