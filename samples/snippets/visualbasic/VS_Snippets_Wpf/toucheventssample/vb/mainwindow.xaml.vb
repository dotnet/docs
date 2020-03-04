' <snippet100>
Class MainWindow
    ' Variables to track the first two touch points 
    ' and the ID of the first touch point.
    Private pt1, pt2 As Point
    Private firstTouchId As Integer = -1
    ' <snippet110>
    ' Touch Down
    Private Sub canvas_TouchDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.TouchEventArgs)
        Dim _canvas As Canvas = CType(sender, Canvas)
        If (_canvas IsNot Nothing) Then
            _canvas.Children.Clear()
            e.TouchDevice.Capture(_canvas)

            ' Record the ID of the first touch point if it hasn't been recorded.
            If firstTouchId = -1 Then
                firstTouchId = e.TouchDevice.Id
            End If
        End If
    End Sub
    ' </snippet110>
    ' <snippet120>
    ' Touch Move
    Private Sub canvas_TouchMove(ByVal sender As System.Object, ByVal e As System.Windows.Input.TouchEventArgs)
        Dim _canvas As Canvas = CType(sender, Canvas)
        If (_canvas IsNot Nothing) Then
            Dim tp = e.GetTouchPoint(_canvas)
            ' This is the first touch point; just record its position.
            If e.TouchDevice.Id = firstTouchId Then
                pt1.X = tp.Position.X
                pt1.Y = tp.Position.Y

                ' This is not the first touch point; draw a line from the first point to this one.
            ElseIf e.TouchDevice.Id <> firstTouchId Then
                pt2.X = tp.Position.X
                pt2.Y = tp.Position.Y

                Dim _line As New Line()
                _line.Stroke = New RadialGradientBrush(Colors.White, Colors.Black)
                _line.X1 = pt1.X
                _line.X2 = pt2.X
                _line.Y1 = pt1.Y
                _line.Y2 = pt2.Y

                _line.StrokeThickness = 2
                _canvas.Children.Add(_line)
            End If
        End If
    End Sub
    ' </snippet120>
    ' <snippet130>
    ' Touch Up
    Private Sub canvas_TouchUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.TouchEventArgs)
        Dim _canvas As Canvas = CType(sender, Canvas)
        If (_canvas IsNot Nothing AndAlso e.TouchDevice.Captured Is _canvas) Then
            _canvas.ReleaseTouchCapture(e.TouchDevice)

        End If
    End Sub
    ' </snippet130>
End Class
' </snippet100>