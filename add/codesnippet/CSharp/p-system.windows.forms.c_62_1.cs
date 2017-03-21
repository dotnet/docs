public class FunButton:
	Button

{
	protected override void OnMouseHover(System.EventArgs e)
	{

		// Get the font size in Points, add one to the
		// size, and reset the button's font to the larger
		// size.
		float fontSize = Font.SizeInPoints;
		fontSize += 1;
		System.Drawing.Size buttonSize = Size;
		this.Font = new System.Drawing.Font(
			Font.FontFamily, fontSize, Font.Style);

		// Increase the size width and height of the button 
		// by 5 points each.
		Size = new System.Drawing.Size(Size.Width+5, Size.Height+5);

		// Call myBase.OnMouseHover to activate the delegate.
		base.OnMouseHover(e);
	}

	protected override void OnMouseMove(MouseEventArgs e)
	{

		// Make the cursor the Hand cursor when the mouse moves 
		// over the button.
		Cursor = Cursors.Hand;

		// Call MyBase.OnMouseMove to activate the delegate.
		base.OnMouseMove(e);
	}