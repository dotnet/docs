private void ResizeForm()
{
   // Enable auto-scrolling for the form.
   this.AutoScroll = true;

   // Resize the form.
   Rectangle r = this.ClientRectangle;
   // Subtract 100 pixels from each side of the Rectangle.
   r.Inflate(-100, -100);
   this.Bounds = this.RectangleToScreen(r);

   // Make sure button2 is visible.
   this.ScrollControlIntoView(button2);
}