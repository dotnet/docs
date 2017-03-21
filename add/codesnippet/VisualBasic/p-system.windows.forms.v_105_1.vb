    Public Sub DrawVisualStyleElementTreeViewGlyph2(ByVal e As PaintEventArgs)
        If (VisualStyleRenderer.IsElementDefined( _
         VisualStyleElement.TreeView.Glyph.Opened)) Then
            Dim renderer As New VisualStyleRenderer _
              (VisualStyleElement.TreeView.Glyph.Opened)
            Dim rectangle1 As New Rectangle(10, 50, 50, 50)
            renderer.DrawBackground(e.Graphics, rectangle1)
            e.Graphics.DrawString("VisualStyleElement.TreeView.Glyph.Opened", _
              Me.Font, Brushes.Black, New Point(10, 10))
        Else
            e.Graphics.DrawString("This element is not defined in the current visual style.", _
              Me.Font, Brushes.Black, New Point(10, 10))
        End If
    End Sub