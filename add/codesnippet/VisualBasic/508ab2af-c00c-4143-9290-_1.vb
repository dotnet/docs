        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ' Ensure that visual styles are supported.
            If Not Application.RenderWithVisualStyles Then
                Me.Text = "Visual styles are not enabled."
                TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, _
                    Me.Location, Me.ForeColor)
                Return
            End If

            ' Set the clip region to define the curved corners of 
            ' the caption.
            SetClipRegion()

            ' Draw each part of the window.
            Dim entry As KeyValuePair(Of String, VisualStyleElement)
            For Each entry In windowElements
                If SetRenderer(entry.Value) Then
                    renderer.DrawBackground(e.Graphics, _
                        elementRectangles(entry.Key))
                End If
            Next entry

            ' Draw the caption text.
            TextRenderer.DrawText(e.Graphics, Me.Text, Me.Font, _
                elementRectangles("windowCaption"), Color.White, _
                TextFormatFlags.VerticalCenter Or _
                TextFormatFlags.HorizontalCenter)
        End Sub