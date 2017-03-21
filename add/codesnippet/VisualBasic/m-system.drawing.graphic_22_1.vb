    Private Sub SaveRestore2(ByVal e As PaintEventArgs)

        ' Translate transformation matrix.
        e.Graphics.TranslateTransform(100, 0)

        ' Save translated graphics state.
        Dim transState As GraphicsState = e.Graphics.Save()

        ' Reset transformation matrix to identity and fill rectangle.
        e.Graphics.ResetTransform()
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 100, 100)

        ' Restore graphics state to translated state and fill second

        ' rectangle.
        e.Graphics.Restore(transState)
        e.Graphics.FillRectangle(New SolidBrush(Color.Blue), 0, 0, _
        100, 100)
    End Sub