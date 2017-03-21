        ' Draw the track bar.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            If Not TrackBarRenderer.IsSupported Then
                Me.Parent.Text = "CustomTrackBar Disabled"
                Return
            End If

            Me.Parent.Text = "CustomTrackBar Enabled"
            TrackBarRenderer.DrawHorizontalTrack(e.Graphics, _
                trackRectangle)
            TrackBarRenderer.DrawTopPointingThumb(e.Graphics, _
                thumbRectangle, thumbState)
            TrackBarRenderer.DrawHorizontalTicks(e.Graphics, _
                ticksRectangle, numberTicks, EdgeStyle.Raised)
        End Sub

        ' Determine whether the user has clicked the track bar thumb.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            If Not TrackBarRenderer.IsSupported Then
                Return
            End If
            If Me.thumbRectangle.Contains(e.Location) Then
                thumbClicked = True
                thumbState = TrackBarThumbState.Pressed
            End If

            Me.Invalidate()
        End Sub
