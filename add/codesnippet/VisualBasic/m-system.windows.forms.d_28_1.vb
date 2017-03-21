        Public Overrides Function GetHitTest(ByVal p As Point) As Cursor
            ' GetHitTest is called to see if the point is
            ' within this glyph.  This gives us a chance to decide
            ' what cursor to show.  Returning null from here means
            ' the mouse pointer is not currently inside of the glyph.
            ' Returning a valid cursor here indicates the pointer is
            ' inside the glyph,and also enables our Behavior property
            ' as the active behavior.
            If Bounds.Contains(p) Then
                Return Cursors.Hand
            End If

            Return Nothing

        End Function