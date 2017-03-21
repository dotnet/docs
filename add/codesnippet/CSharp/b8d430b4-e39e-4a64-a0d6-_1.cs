	//When the mouse hovers over Button2, its ClientRectangle is filled.
	private void Button2_MouseHover(object sender, System.EventArgs e)
	{
		Control senderControl = (Control) sender;
		Rectangle screenRectangle = senderControl.RectangleToScreen(
			senderControl.ClientRectangle);
		ControlPaint.FillReversibleRectangle(screenRectangle, 
			senderControl.BackColor);
	}

	// When the mouse leaves Button2, its ClientRectangle is cleared by
	// calling the FillReversibleRectangle method again.
	private void Button2_MouseLeave(object sender, System.EventArgs e)
	{
		Control senderControl = (Control) sender;
		Rectangle screenRectangle = senderControl.RectangleToScreen(
			senderControl.ClientRectangle);
		ControlPaint.FillReversibleRectangle(screenRectangle, 
			senderControl.BackColor);
	}