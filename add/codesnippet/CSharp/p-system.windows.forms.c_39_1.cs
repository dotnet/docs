private void MoveCursor()
{
   // Set the Current cursor, move the cursor's Position,
   // and set its clipping rectangle to the form. 

   this.Cursor = new Cursor(Cursor.Current.Handle);
   Cursor.Position = new Point(Cursor.Position.X - 50, Cursor.Position.Y - 50);
   Cursor.Clip = new Rectangle(this.Location, this.Size);
}