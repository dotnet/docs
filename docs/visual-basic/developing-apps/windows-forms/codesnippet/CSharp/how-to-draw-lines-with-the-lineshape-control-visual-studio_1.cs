            ShapeContainer canvas = new ShapeContainer();
            LineShape theLine = new LineShape();
            // Set the form as the parent of the ShapeContainer.
            canvas.Parent = this;
            // Set the ShapeContainer as the parent of the LineShape.
            theLine.Parent = canvas;
            // Set the starting and ending coordinates for the line.
            theLine.StartPoint = new System.Drawing.Point(0, 0);
            theLine.EndPoint = new System.Drawing.Point(640, 480);