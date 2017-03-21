private:
   void DrawEllipseFloat( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create location and size of ellipse.
      float x = 0.0F;
      float y = 0.0F;
      float width = 200.0F;
      float height = 100.0F;

      // Draw ellipse to screen.
      e->Graphics->DrawEllipse( blackPen, x, y, width, height );
   }