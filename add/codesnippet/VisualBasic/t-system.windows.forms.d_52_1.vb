    Class MyGlyph
        Inherits Glyph
        Private control As Control
        Private behaviorSvc As _
            System.Windows.Forms.Design.Behavior.BehaviorService

        Public Sub New(ByVal behaviorSvc As _
            System.Windows.Forms.Design.Behavior.BehaviorService, _
            ByVal control As Control)

            MyBase.New(New MyBehavior())
            Me.behaviorSvc = behaviorSvc
            Me.control = control
        End Sub

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


        Public Overrides Sub Paint(ByVal pe As PaintEventArgs)
            ' Draw our glyph.  It is simply a blue ellipse.
            pe.Graphics.FillEllipse(Brushes.Blue, Bounds)

        End Sub

        ' By providing our own behavior we can do something interesting
        ' when the user clicks or manipulates our glyph.

        Class MyBehavior
            Inherits System.Windows.Forms.Design.Behavior.Behavior

            Public Overrides Function OnMouseUp(ByVal g As Glyph, _
                ByVal button As MouseButtons) As Boolean
                MessageBox.Show("Hey, you clicked the mouse here")
                Return True
                ' indicating we processed this event.
            End Function 'OnMouseUp
        End Class

    End Class