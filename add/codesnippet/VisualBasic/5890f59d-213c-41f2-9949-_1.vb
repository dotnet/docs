    Private Sub BeginContainerRectangleF(ByVal e As PaintEventArgs)

        ' Define transformation for container.
        Dim srcRect As New RectangleF(0.0F, 0.0F, 200.0F, 200.0F)
        Dim destRect As New RectangleF(100.0F, 100.0F, 150.0F, 150.0F)

        ' Begin graphics container.
        Dim containerState As GraphicsContainer = _
        e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel)

        ' Fill red rectangle in container.
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0.0F, 0.0F, _
        200.0F, 200.0F)

        ' End graphics container.
        e.Graphics.EndContainer(containerState)

        ' Fill untransformed rectangle with green.
        e.Graphics.FillRectangle(New SolidBrush(Color.Green), 0.0F, 0.0F, _
        200.0F, 200.0F)
    End Sub