private:
   void DrawBezierPoint( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      Point start = Point(100,100);
      Point control1 = Point(200,10);
      Point control2 = Point(350,50);
      Point end = Point(500,100);

      // Draw arc to screen.
      e->Graphics->DrawBezier( blackPen, start, control1, control2, end );
   }