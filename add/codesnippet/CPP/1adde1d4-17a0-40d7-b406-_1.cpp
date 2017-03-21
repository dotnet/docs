private:
   void AddClosedCurveExample( PaintEventArgs^ e )
   {
      // Creates a symetrical, closed curve.
      array<Point>^ myArray = {Point(20,100),Point(40,150),Point(60,125),Point(40,100),Point(60,75),Point(40,50)};

      // Create a new path and add curve.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddClosedCurve( myArray, .5f );
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );

      // Draw the path to screen.
      e->Graphics->DrawPath( myPen, myPath );
   }