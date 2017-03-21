    Public Sub DrawVisualStyleElementTaskbarBackgroundRight1(ByVal e As PaintEventArgs)
        If (VisualStyleRenderer.IsElementDefined( _
         VisualStyleElement.Taskbar.BackgroundRight.Normal)) Then
            Dim renderer As New VisualStyleRenderer _
              (VisualStyleElement.Taskbar.BackgroundRight.Normal)
            Dim rectangle1 As New Rectangle(10, 50, 50, 50)
            renderer.DrawBackground(e.Graphics, rectangle1)
            e.Graphics.DrawString("VisualStyleElement.Taskbar.BackgroundRight.Normal", _
              Me.Font, Brushes.Black, New Point(10, 10))
        Else
            e.Graphics.DrawString("This element is not defined in the current visual style.", _
              Me.Font, Brushes.Black, New Point(10, 10))
        End If
    End Sub