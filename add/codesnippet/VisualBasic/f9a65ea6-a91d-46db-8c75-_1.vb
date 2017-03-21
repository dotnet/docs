        ' Calculate the sizes of the bar, thumb, and ticks rectangle.
        Private Sub SetupTrackBar()
            If Not TrackBarRenderer.IsSupported Then
                Return
            End If
            Using g As Graphics = Me.CreateGraphics()
                ' Calculate the size of the track bar.
                trackRectangle.X = ClientRectangle.X + 2
                trackRectangle.Y = ClientRectangle.Y + 28
                trackRectangle.Width = ClientRectangle.Width - 4
                trackRectangle.Height = 4

                ' Calculate the size of the rectangle in which to 
                ' draw the ticks.
                ticksRectangle.X = trackRectangle.X + 4
                ticksRectangle.Y = trackRectangle.Y - 8
                ticksRectangle.Width = trackRectangle.Width - 8
                ticksRectangle.Height = 4

                tickSpace = (CSng(ticksRectangle.Width) - 1) / _
                    (CSng(numberTicks) - 1)

                ' Calculate the size of the thumb.
                thumbRectangle.Size = _
                    TrackBarRenderer.GetTopPointingThumbSize( _
                    g, TrackBarThumbState.Normal)

                thumbRectangle.X = CurrentTickXCoordinate()
                thumbRectangle.Y = trackRectangle.Y - 8
            End Using
        End Sub