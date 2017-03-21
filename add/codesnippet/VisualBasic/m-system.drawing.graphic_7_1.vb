    Private Sub BeginContainerVoid(ByVal e As PaintEventArgs)

        ' Begin graphics container.
        Dim containerState As GraphicsContainer = _
        e.Graphics.BeginContainer()

        ' Translate world transformation.
        e.Graphics.TranslateTransform(100.0F, 100.0F)

        ' Fill translated rectangle in container with red.
        e.Graphics.FillRectangle(New SolidBrush(Color.Red), 0, 0, 200, 200)

        ' End graphics container.
        e.Graphics.EndContainer(containerState)

        ' Fill untransformed rectangle with green.
        e.Graphics.FillRectangle(New SolidBrush(Color.Green), 0, 0, _
        200, 200)
    End Sub