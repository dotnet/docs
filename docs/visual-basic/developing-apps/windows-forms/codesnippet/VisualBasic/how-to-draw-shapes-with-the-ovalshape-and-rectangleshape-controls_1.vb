        Dim canvas As New ShapeContainer
        ' To draw an oval, substitute 
        ' OvalShape for RectangleShape.
        Dim theShape As New RectangleShape
        ' Set the form as the parent of the ShapeContainer.
        canvas.Parent = Me
        ' Set the ShapeContainer as the parent of the Shape.
        theShape.Parent = canvas
        ' Set the size of the shape.
        theShape.Size = New System.Drawing.Size(200, 300)
        ' Set the location of the shape.
        theShape.Location = New System.Drawing.Point(100, 100)
        ' To draw a rounded rectangle, add the following code:
        theShape.CornerRadius = 12