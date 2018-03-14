' This sample might go in a VisualStyleRenderer conceptual topic, or the VisualStyleRenderer
' class itself. The sample defines a custom control that imitates a window using VisualStyleElements
' for the window parts. It handles resizing and moving the window. 

' This sample uses the following VisualStyleRenderer members:
'   Snippet10: VisualStyleRenderer.GetPartSize (with ThemeSizeType.True)
'   Snippet10: VisualStyleRenderer.GetPoint (with PointProperty.Offset)
'   Snippet20: VisualStyleRenderer.DrawBackground
'   Snippet30: VisualStyleRenderer.GetBackgroundRegion
'   Snippet40: VisualStyleRenderer.IsElementDefined
'   Snippet40: VisualStyleRenderer(VisualStyleElement) constructor
'   Snippet40: VisualStyleRenderer.SetParameters

' Work Items: - Try to make HitTestBackground method work in MouseDown event handler.
'             - Why does the offset value obtained for the close button make it draw a bit 
'               too far to the right?
'             - Right now I'm hard-coding the height of the status bar rect to 22, which
'               visual matches the standard Windows version. Doing GetPartSize on this
'               part only returns a height of 15, which is way to short; is this a bug?

' <Snippet0>
Imports System
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

Namespace VisualStyleRendererSample

    Class Form1
        Inherits Form

        Public Sub New()
            With Me
                .Size = New Size(800, 600)
                .Location = New Point(20, 20)
                .BackColor = Color.DarkGray
            End With
            Dim Window1 As New ImitationWindow()
            Controls.Add(Window1)
        End Sub

        <STAThread()> _
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.Run(New Form1())
        End Sub
    End Class

    Public Class ImitationWindow
        Inherits Control

        Private windowElements As _
            New Dictionary(Of String, VisualStyleElement)
        Private elementRectangles As _
            New Dictionary(Of String, Rectangle)
        Private renderer As VisualStyleRenderer = Nothing
        Private closeButtonOffset As Point
        Private gripperSize As Size
        Private closeButtonSize As Size
        Private isResizing As Boolean = False
        Private isMoving As Boolean = False
        Private isClosing As Boolean = False
        Private captionHeight As Integer
        Private frameThickness As Integer
        Private statusHeight As Integer = 22
        Private originalClick As New Point()
        Private resizeOffset As New Point()

        Public Sub New()
            With Me
                .Location = New Point(50, 50)
                .Size = New Size(350, 300)
                .BackColor = Color.Azure
                .DoubleBuffered = True
                .MinimumSize = New Size(300, 200)
                .Font = SystemFonts.CaptionFont
                .Text = "Imitation Window"
            End With

            ' Create a collection of VisualStyleElement objects.
            With windowElements
                .Add("windowCaption", _
                    VisualStyleElement.Window.Caption.Active)
                .Add("windowBottom", _
                    VisualStyleElement.Window.FrameBottom.Active)
                .Add("windowLeft", _
                    VisualStyleElement.Window.FrameLeft.Active)
                .Add("windowRight", _
                    VisualStyleElement.Window.FrameRight.Active)
                .Add("windowClose", _
                    VisualStyleElement.Window.CloseButton.Normal)
                .Add("statusBar", _
                    VisualStyleElement.Status.Bar.Normal)
                .Add("statusGripper", _
                    VisualStyleElement.Status.Gripper.Normal)
            End With

            ' Get the sizes and location offsets for the window parts  
            ' as specified by the visual style, and then use this   
            ' information to calcualate the rectangles for each part.
            GetPartDetails()
            CalculateRectangles()
        End Sub

        ' <Snippet10>
        ' Get the sizes and offsets for the window parts as specified 
        ' by the visual style.
        Private Sub GetPartDetails()
            ' Do nothing further if visual styles are not enabled.
            If Not Application.RenderWithVisualStyles Then
                Return
            End If

            Using g As Graphics = Me.CreateGraphics()
                ' Get the size and offset of the close button.
                If SetRenderer(windowElements("windowClose")) Then
                    closeButtonSize = _
                        renderer.GetPartSize(g, ThemeSizeType.True)
                    closeButtonOffset = _
                        renderer.GetPoint(PointProperty.Offset)
                End If

                ' Get the height of the window caption.
                If SetRenderer(windowElements("windowCaption")) Then
                    captionHeight = renderer.GetPartSize(g, _
                        ThemeSizeType.True).Height
                End If

                ' Get the thickness of the left, bottom, and right 
                ' window frame.
                If SetRenderer(windowElements("windowLeft")) Then
                    frameThickness = renderer.GetPartSize(g, _
                        ThemeSizeType.True).Width
                End If

                ' Get the size of the resizing gripper.
                If SetRenderer(windowElements("statusGripper")) Then
                    gripperSize = renderer.GetPartSize(g, _
                        ThemeSizeType.True)
                End If
            End Using
        End Sub
        ' </Snippet10>

        ' Use the part metrics to determine the current size of the 
        ' rectangles for all of the window parts.
        Private Sub CalculateRectangles()

            Dim heightMinusFrame As Integer = _
                ClientRectangle.Height - frameThickness

            ' Calculate the window frame rectangles and add them
            ' to the Dictionary of rectangles.
            elementRectangles("windowCaption") = _
                New Rectangle(0, 0, ClientRectangle.Width, _
                captionHeight)
            elementRectangles("windowBottom") = _
                New Rectangle(0, heightMinusFrame, _
                ClientRectangle.Width, frameThickness)
            elementRectangles("windowLeft") = _
                New Rectangle(0, captionHeight, frameThickness, _
                heightMinusFrame - captionHeight)
            elementRectangles("windowRight") = _
                New Rectangle(ClientRectangle.Width - frameThickness, _
                captionHeight, frameThickness, _
                heightMinusFrame - captionHeight)

            ' Calculate the window button rectangle and add it
            ' to the Dictionary of rectangles.
            elementRectangles("windowClose") = _
                New Rectangle(ClientRectangle.Right + _
                closeButtonOffset.X, closeButtonOffset.Y, _
                closeButtonSize.Width, closeButtonSize.Height)

            ' Calculate the status bar rectangles and add them
            ' to the Dictionary of rectangles.
            elementRectangles("statusBar") = _
                New Rectangle(frameThickness, _
                heightMinusFrame - statusHeight, _
                ClientRectangle.Width - 2 * frameThickness, _
                statusHeight)
            elementRectangles("statusGripper") = _
                New Rectangle(ClientRectangle.Right - _
                gripperSize.Width - frameThickness, _
                heightMinusFrame - gripperSize.Height, _
                gripperSize.Width, gripperSize.Height)
        End Sub

        ' <Snippet20>
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
        ' </Snippet20>

        ' Initiate dragging, resizing, or closing the imitation window.
        Private Sub ImitationWindow_MouseDown(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles Me.MouseDown

            ' The user clicked the close button.
            If elementRectangles("windowClose"). _
                Contains(e.Location) Then

                windowElements("windowClose") = _
                    VisualStyleElement.Window.CloseButton.Pressed
                isClosing = True

            ' The user clicked the status grip.
            ElseIf elementRectangles("statusGripper"). _
                Contains(e.Location) Then

                isResizing = True
                Me.Cursor = Cursors.SizeNWSE
                resizeOffset.X = Me.Right - Me.Left - e.X
                resizeOffset.Y = Me.Bottom - Me.Top - e.Y

            ' The user clicked the window caption.
            ElseIf elementRectangles("windowCaption"). _
                Contains(e.Location) Then

                isMoving = True
                originalClick.X = e.X
                originalClick.Y = e.Y
            End If
            Invalidate()
        End Sub

        ' Stop any current resizing or moving actions.
        Private Sub ImitationWindow_MouseUp(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles Me.MouseUp

            ' Stop moving the location of the window rectangles.
            If isMoving Then
                isMoving = False

            ' Change the cursor back to the default if the 
            ' user stops resizing.
            ElseIf isResizing Then
                isResizing = False

            ' Close the application if the user clicks the 
            ' close button.
            ElseIf elementRectangles("windowClose"). _
                Contains(e.Location) And isClosing Then
                Application.Exit()
            End If
        End Sub

        ' Handle resizing or moving actions.
        Private Sub ImitationWindow_MouseMove(ByVal sender As Object, _
            ByVal e As MouseEventArgs) Handles Me.MouseMove

            ' The left mouse button is down.
            If (MouseButtons.Left And e.Button) = _
                MouseButtons.Left Then

                ' Calculate the new control size if the user is  
                ' dragging the resizing grip.
                If isResizing Then
                    Me.Width = e.X + resizeOffset.X
                    Me.Height = e.Y + resizeOffset.Y
                    CalculateRectangles()

                ' Calculate the new location of the control if   
                ' the user is dragging the window caption.
                ElseIf isMoving Then
                    Dim XChange As Integer = Me.Location.X + _
                        (e.X - originalClick.X)
                    Dim YChange As Integer = Me.Location.Y + _
                        (e.Y - originalClick.Y)
                    Me.Location = New Point(XChange, YChange)

                ' Cancel the closing action if the user clicked and  
                ' held down on the close button, and has dragged the   
                ' pointer outside the button.
                ElseIf Not elementRectangles("windowClose"). _
                    Contains(e.Location) And isClosing Then

                    isClosing = False
                    windowElements("windowClose") = _
                        VisualStyleElement.Window.CloseButton.Normal
                End If

            ' The left mouse button is not down.
            Else
                ' Paint the close button hot if the cursor is on it.
                If elementRectangles("windowClose"). _
                    Contains(e.Location) Then
                    windowElements("windowClose") = _
                        VisualStyleElement.Window.CloseButton.Hot
                Else
                    windowElements("windowClose") = _
                        VisualStyleElement.Window.CloseButton.Normal
                End If

                ' Use a resizing cursor if the cursor is on the 
                ' status grip.
                If elementRectangles("statusGripper"). _
                    Contains(e.Location) Then
                    Me.Cursor = Cursors.SizeNWSE
                Else
                    Me.Cursor = Cursors.Default
                End If
            End If
            Invalidate()
        End Sub

        ' <Snippet30>
        ' Calculate and set the clipping region for the control  
        ' so that the corners of the title bar are rounded.
        Private Sub SetClipRegion()
            If Not Application.RenderWithVisualStyles Then
                Return
            End If

            Using g As Graphics = Me.CreateGraphics()
                ' Get the current region for the window caption.
                If SetRenderer(windowElements("windowCaption")) Then
                    Dim clipRegion As Region = _
                        renderer.GetBackgroundRegion(g, _
                        elementRectangles("windowCaption"))

                    ' Get the client rectangle, but exclude the   
                    ' region of the window caption.
                    Dim height As Integer = _
                        CInt(clipRegion.GetBounds(g).Height)
                    Dim nonCaptionRect As _
                        New Rectangle(ClientRectangle.X, _
                        ClientRectangle.Y + height, _
                        ClientRectangle.Width, _
                        ClientRectangle.Height - height)

                    ' Add the rectangle to the caption region, and  
                    ' make this region the form's clipping region.
                    clipRegion.Union(nonCaptionRect)
                    Me.Region = clipRegion
                End If
            End Using
        End Sub
        ' </Snippet30>

        ' <Snippet40>
        ' Set the VisualStyleRenderer to a new element.
        Private Function SetRenderer(ByVal element As _
            VisualStyleElement) As Boolean

            If Not VisualStyleRenderer.IsElementDefined(element) Then
                Return False
            End If

            If renderer Is Nothing Then
                renderer = New VisualStyleRenderer(element)
            Else
                renderer.SetParameters(element)
            End If

            Return True
        End Function
        ' </Snippet40>

    End Class
End Namespace
' </Snippet0>