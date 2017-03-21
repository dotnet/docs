private:
   void DrawArcRectangleF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle to bound ellipse.
      RectangleF rect = RectangleF(0.0F,0.0F,100.0F,200.0F);

      // Create start and sweep angles on ellipse.
      float startAngle = 45.0F;
      float sweepAngle = 270.0F;

      // Draw arc to screen.
      e->Graphics->DrawArc( blackPen, rect, startAngle, sweepAngle );
   }