private:
   void DrawBezierPointF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      PointF start = PointF(100.0F,100.0F);
      PointF control1 = PointF(200.0F,10.0F);
      PointF control2 = PointF(350.0F,50.0F);
      PointF end = PointF(500.0F,100.0F);

      // Draw arc to screen.
      e->Graphics->DrawBezier( blackPen, start, control1, control2, end );
   }