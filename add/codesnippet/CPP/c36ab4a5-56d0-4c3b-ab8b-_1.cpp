private:
   void DrawEllipseRectangleF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle for ellipse.
      RectangleF rect = RectangleF(0.0F,0.0F,200.0F,100.0F);

      // Draw ellipse to screen.
      e->Graphics->DrawEllipse( blackPen, rect );
   }