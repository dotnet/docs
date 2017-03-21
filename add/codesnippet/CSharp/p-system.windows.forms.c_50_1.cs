    // The following three methods will draw a rectangle and allow 
    // the user to use the mouse to resize the rectangle.  If the 
    // rectangle intersects a control's client rectangle, the 
    // control's color will change.

    bool isDrag = false;
    Rectangle theRectangle = new Rectangle
		(new Point(0, 0), new Size(0, 0));
    Point startPoint;

    private void Form1_MouseDown(object sender, 
		System.Windows.Forms.MouseEventArgs e)
    {

        // Set the isDrag variable to true and get the starting point 
        // by using the PointToScreen method to convert form 
		// coordinates to screen coordinates.
        if (e.Button==MouseButtons.Left)
        {
            isDrag = true;
        }

        Control control = (Control) sender;

        // Calculate the startPoint by using the PointToScreen 
        // method.
        startPoint = control.PointToScreen(new Point(e.X, e.Y));
    }

    private void Form1_MouseMove(object sender, 
		System.Windows.Forms.MouseEventArgs e)
    {

        // If the mouse is being dragged, 
		// undraw and redraw the rectangle as the mouse moves.
        if (isDrag)

            // Hide the previous rectangle by calling the 
			// DrawReversibleFrame method with the same parameters.
        {
            ControlPaint.DrawReversibleFrame(theRectangle, 
				this.BackColor, FrameStyle.Dashed);

            // Calculate the endpoint and dimensions for the new 
	        // rectangle, again using the PointToScreen method.
            Point endPoint = ((Control) sender).PointToScreen(new Point(e.X, e.Y));

            int width = endPoint.X-startPoint.X;
            int height = endPoint.Y-startPoint.Y;
            theRectangle = new Rectangle(startPoint.X, 
				startPoint.Y, width, height);

            // Draw the new rectangle by calling DrawReversibleFrame
			// again.  
            ControlPaint.DrawReversibleFrame(theRectangle, 
				this.BackColor, FrameStyle.Dashed);
        }
    }

    private void Form1_MouseUp(object sender, 
		System.Windows.Forms.MouseEventArgs e)
    {

        // If the MouseUp event occurs, the user is not dragging.
        isDrag = false;

        // Draw the rectangle to be evaluated. Set a dashed frame style 
        // using the FrameStyle enumeration.
        ControlPaint.DrawReversibleFrame(theRectangle, 
			this.BackColor, FrameStyle.Dashed);

        // Find out which controls intersect the rectangle and 
        // change their color. The method uses the RectangleToScreen  
        // method to convert the Control's client coordinates 
		// to screen coordinates.
	    Rectangle controlRectangle;
        for(int i = 0; i < Controls.Count; i++)
        {
            controlRectangle = Controls[i].RectangleToScreen
				(Controls[i].ClientRectangle);
            if (controlRectangle.IntersectsWith(theRectangle))
            {
                Controls[i].BackColor = Color.BurlyWood;
            }
        }

        // Reset the rectangle.
        theRectangle = new Rectangle(0, 0, 0, 0);
    }