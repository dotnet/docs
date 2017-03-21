private:
   void DrawEllipseRectangle( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle for ellipse.
      Rectangle rect = Rectangle(0,0,200,100);

      // Draw ellipse to screen.
      e->Graphics->DrawEllipse( blackPen, rect );
   }