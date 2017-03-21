private void AutoSizeControl(Control control, int textPadding)
{
   // Create a Graphics object for the Control.
   Graphics g = control.CreateGraphics();

   // Get the Size needed to accommodate the formatted Text.
   Size preferredSize = g.MeasureString(
      control.Text, control.Font).ToSize();

   // Pad the text and resize the control.
   control.ClientSize = new Size(
      preferredSize.Width + (textPadding * 2), 
      preferredSize.Height+(textPadding * 2) );

   // Clean up the Graphics object.
   g.Dispose();
}