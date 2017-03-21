private:
   void AddCurveExample( PaintEventArgs^ e )
   {
      // Create some points.
      Point point1 = Point(20,20);
      Point point2 = Point(40,0);
      Point point3 = Point(60,40);
      Point point4 = Point(80,20);

      // Create an array of the points.
      array<Point>^ curvePoints = {point1,point2,point3,point4};

      // Create a GraphicsPath object and add a curve.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddCurve( curvePoints, 0, 3, 0.8f );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }