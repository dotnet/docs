        Dim canvas As New ShapeContainer
        Dim theLine As New LineShape
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the LineShape.
        theLine.Parent = canvas
        ' Set the starting and ending coordinates for the line.
        theLine.StartPoint = New System.Drawing.Point(0, 0)
        theLine.EndPoint = New System.Drawing.Point(640, 480)