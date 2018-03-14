            ShapeContainer canvas = new ShapeContainer();
            // To draw an oval, substitute 
            // OvalShape for RectangleShape.
            RectangleShape theShape = new RectangleShape();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the Shape.
            theShape.Parent = canvas;
            // Set the size of the shape.
            theShape.Size = new System.Drawing.Size(200, 300);
            // Set the location of the shape.
            theShape.Location = new System.Drawing.Point(100, 100);
            // To draw a rounded rectangle, add the following code:
            theShape.CornerRadius = 12;