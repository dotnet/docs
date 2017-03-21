private:
   void DrawBezierFloat( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create coordinates of points for curve.
      float startX = 100.0F;
      float startY = 100.0F;
      float controlX1 = 200.0F;
      float controlY1 = 10.0F;
      float controlX2 = 350.0F;
      float controlY2 = 50.0F;
      float endX = 500.0F;
      float endY = 100.0F;

      // Draw arc to screen.
      e->Graphics->DrawBezier( blackPen, startX, startY, controlX1, controlY1, controlX2, controlY2, endX, endY );
   }