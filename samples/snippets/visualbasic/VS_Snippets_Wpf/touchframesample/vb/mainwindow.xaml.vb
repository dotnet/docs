' <snippet100>
' <snippet110>
Class MainWindow
    ' Variables for tracking the position of two points.
    Private pt1, pt2 As Point

    Public Sub New()
        InitializeComponent()
        AddHandler Touch.FrameReported, AddressOf Touch_FrameReported
    End Sub

    Private Sub Touch_FrameReported(ByVal sender As System.Object, ByVal e As System.Windows.Input.TouchFrameEventArgs)
        If (canvas1 IsNot Nothing) Then
            ' <snippet120>
            For Each _touchPoint In e.GetTouchPoints(Me.canvas1)

                If _touchPoint.Action = TouchAction.Down Then
                    ' Clear the canvas and capture the touch to it.
                    canvas1.Children.Clear()
                    _touchPoint.TouchDevice.Capture(canvas1)

                ElseIf _touchPoint.Action = TouchAction.Move Then
                    ' This is the first (primary) touch point. Just record its position.
                    If _touchPoint.TouchDevice.Id = e.GetPrimaryTouchPoint(Me.canvas1).TouchDevice.Id Then
                        pt1.X = _touchPoint.Position.X
                        pt1.Y = _touchPoint.Position.Y

                        ' This is not the first touch point; draw a line from the first point to this one.
                    ElseIf _touchPoint.TouchDevice.Id <> e.GetPrimaryTouchPoint(Me.canvas1).TouchDevice.Id Then
                        pt2.X = _touchPoint.Position.X
                        pt2.Y = _touchPoint.Position.Y

                        Dim _line As New Line()
                        _line.Stroke = New RadialGradientBrush(Colors.White, Colors.Black)
                        _line.X1 = pt1.X
                        _line.X2 = pt2.X
                        _line.Y1 = pt1.Y
                        _line.Y2 = pt2.Y

                        _line.StrokeThickness = 2
                        Me.canvas1.Children.Add(_line)
                    End If

                ElseIf _touchPoint.Action = TouchAction.Up Then
                    ' If this touch is captured to the canvas, release it.
                    If (_touchPoint.TouchDevice.Captured Is canvas1) Then
                        canvas1.ReleaseTouchCapture(_touchPoint.TouchDevice)
                    End If
                End If
            Next
            ' </snippet120>
        End If
    End Sub
End Class
' </snippet110>
' </snippet100>
