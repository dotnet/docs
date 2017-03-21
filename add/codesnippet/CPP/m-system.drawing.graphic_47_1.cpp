private:
   void DrawCurvePoint( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      Point point1 = Point(50,50);
      Point point2 = Point(100,25);
      Point point3 = Point(200,5);
      Point point4 = Point(250,50);
      Point point5 = Point(300,100);
      Point point6 = Point(350,200);
      Point point7 = Point(250,250);
      array<Point>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints );
   }