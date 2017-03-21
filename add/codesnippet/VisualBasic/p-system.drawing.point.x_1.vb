    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Construct a new Point with integers.
        Dim Point1 As New Point(100, 100)

        ' Create a Graphics object.
        Dim formGraphics As Graphics = Me.CreateGraphics()

        ' Construct another Point, this time using a Size.
        Dim Point2 As New Point(New Size(100, 100))

        ' Call the equality operator to see if the points are equal,  
        ' and if so print out their x and y values.
        If (Point.op_Equality(Point1, Point2)) Then
            formGraphics.DrawString(String.Format("Point1.X: " & _
                "{0},Point2.X: {1}, Point1.Y: {2}, Point2.Y {3}", _
                New Object() {Point1.X, Point2.X, Point1.Y, Point2.Y}), _
                Me.Font, Brushes.Black, New PointF(10, 70))
        End If

    End Sub