private:
   void DrawArcFloat( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create coordinates of rectangle to bound ellipse.
      float x = 0.0F;
      float y = 0.0F;
      float width = 100.0F;
      float height = 200.0F;

      // Create start and sweep angles on ellipse.
      float startAngle = 45.0F;
      float sweepAngle = 270.0F;

      // Draw arc to screen.
      e->Graphics->DrawArc( blackPen, x, y, width, height, startAngle, sweepAngle );
   }