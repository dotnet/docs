' This sample can go in ScrollBarRenderer class overview.
' - Snippet2 can go in IsSupported, DrawRightHorizontalTrack, 
'   DrawHorizontalThumb, DrawHorizontalThumbGrip, DrawArrowButton, 
'   and, if necessary, ScrollBarState and ScrollBarArrowButtonState enums.

' This sample simulates a horizontal scroll bar. 
' For simplicity, this sample does not handle runtime switching of visual styles.


'<Snippet0>
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace ScrollBarRendererSample

    Class Form1
        Inherits Form

        Public Sub New()
            Me.Size = New Size(500, 500)

            Dim Bar1 As New CustomScrollBar()
            Bar1.Location = New Point(50, 100)
            Bar1.Size = New Size(200, 20)

            Controls.Add(Bar1)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            ' The call to EnableVisualStyles below does not affect whether 
            ' ScrollBarRenderer.IsSupported is true; as long as visual styles 
            ' are enabled by the operating system, IsSupported is true.
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class CustomScrollBar
        Inherits Control

        Private clickedBarRectangle As Rectangle
        Private thumbRectangle As Rectangle
        Private leftArrowRectangle As Rectangle
        Private rightArrowRectangle As Rectangle
        Private leftArrowClicked As Boolean = False
        Private rightArrowClicked As Boolean = False
        Private leftBarClicked As Boolean = False
        Private rightBarClicked As Boolean = False
        Private thumbClicked As Boolean = False
        Private thumbState As ScrollBarState = ScrollBarState.Normal
        Private leftButtonState As ScrollBarArrowButtonState = _
            ScrollBarArrowButtonState.LeftNormal
        Private rightButtonState As ScrollBarArrowButtonState = _
            ScrollBarArrowButtonState.RightNormal

        ' This control does not allow these widths to be altered.
        Private thumbWidth As Integer = 15
        Private arrowWidth As Integer = 17

        ' Set the right limit of the thumb's right border.
        Private thumbRightLimitRight As Integer = 0

        ' Set the right limit of the thumb's left border.
        Private thumbRightLimitLeft As Integer = 0

        ' Set the left limit of thumb's left border.
        Private thumbLeftLimit As Integer = 0

        ' Set the distance from the left edge of the thumb to the 
        ' cursor tip.
        Private thumbPosition As Integer = 0

        ' Set the distance from the left edge of the scroll bar track to 
        ' the cursor tip.
        Private trackPosition As Integer = 0

        ' This timer draws the moving thumb while the scroll arrows or 
        ' track are pressed.
        Private WithEvents progressTimer As New Timer()

        Public Sub New()
            With Me
                .Location = New Point(10, 10)
                .Width = 200
                .Height = 20
                .DoubleBuffered = True
            End With
            SetUpScrollBar()
            progressTimer.Interval = 20
        End Sub

        ' Calculate the sizes of the scroll bar elements.
        Private Sub SetUpScrollBar()

            clickedBarRectangle = Me.ClientRectangle
            thumbRectangle = New Rectangle(ClientRectangle.X + _
                Me.ClientRectangle.Width / 2, Me.ClientRectangle.Y, _
                thumbWidth, Me.ClientRectangle.Height)
            leftArrowRectangle = New Rectangle(Me.ClientRectangle.X, _
                Me.ClientRectangle.Y, arrowWidth, Me.ClientRectangle.Height)
            rightArrowRectangle = New Rectangle(Me.ClientRectangle.Right - _
                arrowWidth, Me.ClientRectangle.Y, arrowWidth, _
                Me.ClientRectangle.Height)

            ' Set the default starting thumb position.
            thumbPosition = thumbWidth / 2

            ' Set the right limit of the thumb's right border.
            thumbRightLimitRight = Me.ClientRectangle.Right - arrowWidth

            ' Set the right limit of the thumb's left border.
            thumbRightLimitLeft = thumbRightLimitRight - thumbWidth

            ' Set the left limit of the thumb's left border.
            thumbLeftLimit = Me.ClientRectangle.X + arrowWidth
        End Sub

        '<Snippet2>
        ' Draw the scroll bar in its normal state.
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)

            ' Visual styles are not enabled.
            If Not ScrollBarRenderer.IsSupported Then
                Me.Parent.Text = "CustomScrollBar Disabled"
                Return
            End If

            Me.Parent.Text = "CustomScrollBar Enabled"

            ' Draw the scroll bar track.
            ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics, _
                Me.ClientRectangle, ScrollBarState.Normal)

            ' Draw the thumb and thumb grip in the current state.
            ScrollBarRenderer.DrawHorizontalThumb(e.Graphics, _
                thumbRectangle, thumbState)
            ScrollBarRenderer.DrawHorizontalThumbGrip(e.Graphics, _
                thumbRectangle, thumbState)

            ' Draw the scroll arrows in the current state.
            ScrollBarRenderer.DrawArrowButton(e.Graphics, _
                leftArrowRectangle, leftButtonState)
            ScrollBarRenderer.DrawArrowButton(e.Graphics, _
                rightArrowRectangle, rightButtonState)

            ' Draw a highlighted rectangle in the left side of the scroll 
            ' bar track if the user has clicked between the left arrow 
            ' and thumb.
            If leftBarClicked Then
                clickedBarRectangle.X = thumbLeftLimit
                clickedBarRectangle.Width = thumbRectangle.X - thumbLeftLimit
                ScrollBarRenderer.DrawLeftHorizontalTrack(e.Graphics, _
                    clickedBarRectangle, ScrollBarState.Pressed)

            ' Draw a highlighted rectangle in the right side of the scroll 
            ' bar track if the user has clicked between the right arrow 
            ' and thumb.
            ElseIf rightBarClicked Then
                clickedBarRectangle.X = thumbRectangle.X + _
                    thumbRectangle.Width
                clickedBarRectangle.Width = thumbRightLimitRight - _
                    clickedBarRectangle.X
                ScrollBarRenderer.DrawRightHorizontalTrack(e.Graphics, _
                    clickedBarRectangle, ScrollBarState.Pressed)
            End If
        End Sub
        '</Snippet2>

        ' Handle a mouse click in the scroll bar.
        Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
            MyBase.OnMouseDown(e)

            If Not ScrollBarRenderer.IsSupported Then
                Return
            End If

            ' When the thumb is clicked, update the distance from the left
            ' edge of the thumb to the cursor tip.
            If thumbRectangle.Contains(e.Location) Then
                thumbClicked = True
                thumbPosition = e.Location.X - thumbRectangle.X
                thumbState = ScrollBarState.Pressed

            ' When the left arrow is clicked, start the timer to scroll 
            ' while the arrow is held down.
            ElseIf leftArrowRectangle.Contains(e.Location) Then
                leftArrowClicked = True
                leftButtonState = ScrollBarArrowButtonState.LeftPressed
                progressTimer.Start()

            ' When the right arrow is clicked, start the timer to scroll 
            ' while arrow is held down.
            ElseIf rightArrowRectangle.Contains(e.Location) Then
                rightArrowClicked = True
                rightButtonState = ScrollBarArrowButtonState.RightPressed
                progressTimer.Start()

            ' When the scroll bar is clicked, start the timer to move the
            ' thumb while the mouse is held down.
            Else
                trackPosition = e.Location.X
                If e.Location.X < Me.thumbRectangle.X Then
                    leftBarClicked = True
                Else
                    rightBarClicked = True
                End If
                progressTimer.Start()
            End If

            Invalidate()
        End Sub

        ' Draw the track.
        Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
            MyBase.OnMouseUp(e)

            If Not ScrollBarRenderer.IsSupported Then
                Return
            End If

            ' Update the thumb position, if the new location is within 
            ' the bounds.
            If thumbClicked Then
                thumbClicked = False
                thumbState = ScrollBarState.Normal
                If e.Location.X > thumbLeftLimit + thumbPosition And _
                    e.Location.X < thumbRightLimitLeft + thumbPosition Then
                    thumbRectangle.X = e.Location.X - thumbPosition
                    thumbClicked = False
                End If

            ' If one of the four thumb movement areas was clicked, 
            ' stop the timer.
            ElseIf leftArrowClicked Then
                leftArrowClicked = False
                leftButtonState = ScrollBarArrowButtonState.LeftNormal
                progressTimer.Stop()

            ElseIf rightArrowClicked Then
                rightArrowClicked = False
                rightButtonState = ScrollBarArrowButtonState.RightNormal
                progressTimer.Stop()

            ElseIf leftBarClicked Then
                leftBarClicked = False
                progressTimer.Stop()

            ElseIf rightBarClicked Then
                rightBarClicked = False
                progressTimer.Stop()
            End If

            Invalidate()
        End Sub

        ' Track mouse movements if the user clicks on the scroll bar thumb.
        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            MyBase.OnMouseMove(e)

            If Not ScrollBarRenderer.IsSupported Then
                Return
            End If

            ' Update the thumb position, if the new location is 
            ' within the bounds.
            If thumbClicked Then

                ' The thumb is all the way to the left.
                If e.Location.X <= thumbLeftLimit + thumbPosition Then
                    thumbRectangle.X = thumbLeftLimit

                ' The thumb is all the way to the right.
                ElseIf e.Location.X >= thumbRightLimitLeft + thumbPosition Then
                    thumbRectangle.X = thumbRightLimitLeft

                ' The thumb is between the ends of the track.
                Else
                    thumbRectangle.X = e.Location.X - thumbPosition
                End If

                Invalidate()

            End If
        End Sub

        ' Recalculate the sizes of the scroll bar elements.
        Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
            MyBase.OnSizeChanged(e)
            SetUpScrollBar()
        End Sub

        ' Handle the timer tick by updating the thumb position.
        Private Sub progressTimer_Tick(ByVal sender As Object, _
            ByVal myEventArgs As EventArgs) Handles progressTimer.Tick

            If Not ScrollBarRenderer.IsSupported Then
                Return
            End If

            ' If an arrow is clicked, move the thumb in small increments.
            If rightArrowClicked And thumbRectangle.X < thumbRightLimitLeft Then
                thumbRectangle.X += 1

            ElseIf leftArrowClicked And thumbRectangle.X > thumbLeftLimit Then
                    thumbRectangle.X -= 1

            ' If the track bar to right of the thumb is clicked, move the 
            ' thumb to the right in larger increments until the right edge 
            ' of the thumb hits the cursor.
            ElseIf rightBarClicked And thumbRectangle.X < thumbRightLimitLeft _
                And thumbRectangle.X + thumbRectangle.Width < trackPosition Then
                thumbRectangle.X += 3

            ' If the track bar to left of the thumb is clicked, move the 
            ' thumb to the left in larger increments until the left edge 
            ' of the thumb hits the cursor.
            ElseIf leftBarClicked And thumbRectangle.X > thumbLeftLimit And _
                thumbRectangle.X > trackPosition Then
                thumbRectangle.X -= 3
            End If

            Invalidate()
        End Sub

    End Class
End Namespace
'</Snippet0>