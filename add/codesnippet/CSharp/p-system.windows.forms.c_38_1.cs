private void DrawCursorsOnForm(Cursor cursor)
{
   // If the form's cursor is not the Hand cursor and the 
   // Current cursor is the Default, Draw the specified 
   // cursor on the form in normal size and twice normal size.
   if(this.Cursor != Cursors.Hand & 
     Cursor.Current == Cursors.Default)
   {
      // Draw the cursor stretched.
      Graphics graphics = this.CreateGraphics();
      Rectangle rectangle = new Rectangle(
        new Point(10,10), new Size(cursor.Size.Width * 2, 
        cursor.Size.Height * 2));
      cursor.DrawStretched(graphics, rectangle);
		
      // Draw the cursor in normal size.
      rectangle.Location = new Point(
      rectangle.Width + rectangle.Location.X, 
        rectangle.Height + rectangle.Location.Y);
      rectangle.Size = cursor.Size;
      cursor.Draw(graphics, rectangle);

      // Dispose of the cursor.
      cursor.Dispose();
   }
}