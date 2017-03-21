    Private Sub BeginContainerRectangle(ByVal e As PaintEventArgs)

        ' Define transformation for container.
        Dim srcRect As New Rectangle(0, 0, 200, 200)
        Dim destRect As New Rectangle(100, 100, 150, 150)

        ' Begin graphics container.
        Dim containerState As GraphicsContainer = _
        e.Graphics.BeginContainer(destRect, srcRect, GraphicsUnit.Pixel)

        ' Fill red rectangle in container.
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 200, 200)

        ' End graphics container.
        e.Graphics.EndContainer(containerState)

        ' Fill untransformed rectangle with green.
        e.Graphics.FillRectangle(New SolidBrush(Color.Green), 0, 0, _
        200, 200)
    End Sub