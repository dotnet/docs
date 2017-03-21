
// The DrawItem event handler.
private void menuItem1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
{

	string myCaption = "Owner Draw Item1";

	// Create a Brush and a Font with which to draw the item.
	Brush myBrush = System.Drawing.Brushes.AliceBlue;
	Font myFont = new Font(FontFamily.GenericSerif, 14, FontStyle.Underline, GraphicsUnit.Pixel);
	SizeF mySizeF = e.Graphics.MeasureString(myCaption, myFont);

	// Draw the item, and then draw a Rectangle around it.
	e.Graphics.DrawString(myCaption, myFont, myBrush, e.Bounds.X, e.Bounds.Y);
	e.Graphics.DrawRectangle(Pens.Black, new Rectangle(e.Bounds.X, e.Bounds.Y, Convert.ToInt32(mySizeF.Width), Convert.ToInt32(mySizeF.Height)));

}