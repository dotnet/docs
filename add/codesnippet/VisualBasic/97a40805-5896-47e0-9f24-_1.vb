        Public Overrides Sub Paint(ByVal pe As PaintEventArgs)
            ' Draw our glyph.  It is simply a blue ellipse.
            pe.Graphics.FillEllipse(Brushes.Blue, Bounds)

        End Sub