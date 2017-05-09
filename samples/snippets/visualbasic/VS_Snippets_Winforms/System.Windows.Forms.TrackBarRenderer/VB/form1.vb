' This sample can go in TrackBarRenderer class overview.
' - Snippet2 can go in GetTopPointingThumbSize, and possibly other Gets
' - Snippet4 can go in IsSupported, DrawHorizontalTrack, and DrawTopPointingThumb
' - Snippet6 can go in DrawVerticalTick; see below about bug in the meantime, though

'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles


Namespace TrackBarRendererSample

    Class Form1
        Inherits Form

        Public Sub New()
            Dim TrackBar1 As New CustomTrackBar(19, New Size(300, 50))
            Me.Width = 500
            Me.Controls.Add(TrackBar1)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' Note that the call to EnableVisualStyles below does
            ' not affect whether TrackBarRenderer.IsSupported is true; 
            ' as long as visual styles are enabled by the operating system, 
            ' IsSupported is true.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Class CustomTrackBar
        Inherits Control
        Private numberTicks As Integer = 10
        Private trackRectangle As New Rectangle()
        Private ticksRectangle As New Rectangle()
        Private thumbRectangle As New Rectangle()
        Private currentTickPosition As Integer = 0
        Private tickSpace As Single = 0
        Private thumbClicked As Boolean = False
        Private thumbState As TrackBarThumbState = TrackBarThumbState.Normal

        Public Sub New(ByVal ticks As Integer, ByVal trackBarSize As Size)

            With Me
                .Location = New Point(10, 10)
                .Size = trackBarSize
                .numberTicks = ticks
                .BackColor = Color.DarkCyan
                .DoubleBuffered = True
            End With

            ' Calculate the initial sizes of the bar, 
            ' thumb and ticks.
            SetupTrackBar()
        End Sub

        '<Snippet2>
        '<Snippet6>
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
        '</Snippet2>

        Private Function CurrentTickXCoordinate() As Integer
            If tickSpace = 0 Then
                Return 0
            Else
                Return CInt(Math.Round(tickSpace)) * currentTickPosition
            End If
        End Function

        '<Snippet4>
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

        '</Snippet6>
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

        '</Snippet4>
        ' Redraw the track bar thumb if the user has moved it.
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            If Not TrackBarRenderer.IsSupported Then
                Return
            End If
            If thumbClicked = True Then
                If e.Location.X > trackRectangle.X And _
                    e.Location.X < trackRectangle.X + _
                    trackRectangle.Width - thumbRectangle.Width Then

                    thumbClicked = False
                    thumbState = TrackBarThumbState.Hot
                    Me.Invalidate()
                End If
                thumbClicked = False
            End If
        End Sub

        ' Track cursor movements.
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            If Not TrackBarRenderer.IsSupported Then
                Return
            End If
            ' The user is moving the thumb.
            If thumbClicked = True Then

                ' Track movements to the next tick to the right, if the
                ' cursor has moved halfway to the next tick.
                If currentTickPosition < numberTicks - 1 And _
                    e.Location.X > CurrentTickXCoordinate() + _
                    CInt(tickSpace) Then
                    currentTickPosition += 1

                ' Track movements to the next tick to the left, if 
                ' the cursor has moved halfway to the next tick.
                Else
                    If currentTickPosition > 0 And _
                        e.Location.X < CurrentTickXCoordinate() - _
                        CInt(tickSpace / 2) Then
                        currentTickPosition -= 1
                    End If
                End If
                thumbRectangle.X = CurrentTickXCoordinate()

            ' The cursor is passing over the track.
            Else
                If thumbRectangle.Contains(e.Location) Then
                    thumbState = TrackBarThumbState.Hot
                Else
                    thumbState = TrackBarThumbState.Normal
                End If
            End If

            Invalidate()
        End Sub

    End Class
End Namespace
'</Snippet0>