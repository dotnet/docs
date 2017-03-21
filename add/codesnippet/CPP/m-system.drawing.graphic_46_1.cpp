private:
   void DrawBeziersPoint( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      Point start = Point(100,100);
      Point control1 = Point(200,10);
      Point control2 = Point(350,50);
      Point end1 = Point(500,100);
      Point control3 = Point(600,150);
      Point control4 = Point(650,250);
      Point end2 = Point(500,300);
      array<Point>^ bezierPoints = {start,control1,control2,end1,control3,control4,end2};

      // Draw arc to screen.
      e->Graphics->DrawBeziers( blackPen, bezierPoints );
   }