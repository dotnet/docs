	// Handle the Button1 object's Paint Event to create a CaptionButton.
	private void Button1_Paint(object sender, PaintEventArgs e)
	{

		// Draw a CaptionButton control using the ClientRectangle 
		// property of Button1. Make the button a Help button 
		// with a normal state.
		ControlPaint.DrawCaptionButton(e.Graphics, Button1.ClientRectangle,
			CaptionButton.Help, ButtonState.Normal);
	}