        Public Overrides ReadOnly Property Bounds() As Rectangle
            Get
                ' Create a glyph that is 10x10 and sitting
                ' in the middle of the control.  Glyph coordinates
                ' are in adorner window coordinates, so we must map
                ' using the behavior service.
                Dim edge As Point = behaviorSvc.ControlToAdornerWindow(control)
                Dim size As Size = control.Size
                Dim center As New Point(edge.X + size.Width / 2, edge.Y + _
                    size.Height / 2)

                Dim bounds1 As New Rectangle(center.X - 5, center.Y - 5, 10, 10)

                Return bounds1
            End Get
        End Property