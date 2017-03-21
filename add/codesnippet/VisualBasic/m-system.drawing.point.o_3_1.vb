    Private Sub ShowPointConverter(ByVal e As PaintEventArgs)

        ' Create the PointConverter.
        Dim converter As System.ComponentModel.TypeConverter = _
            System.ComponentModel.TypeDescriptor.GetConverter(GetType(Point))

        Dim point1 As Point = _
            CType(converter.ConvertFromString("200, 200"), Point)

        ' Use the subtraction operator to get a second point.
        Dim point2 As Point = Point.op_Subtraction(point1, _
            New Size(190, 190))

        ' Draw a line between the two points.
        e.Graphics.DrawLine(Pens.Black, point1, point2)
    End Sub