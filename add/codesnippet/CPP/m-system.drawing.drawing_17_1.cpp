private:
   void HasCurveExample( PaintEventArgs^ /*e*/ )
   {
      // Create a path and add three lines,
      // a rectangle and an ellipse.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Create a GraphicsPathIterator for myPath.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );

      // Test for a curve.
      bool myHasCurve = myPathIterator->HasCurve();

      // Show the test result.
      MessageBox::Show( myHasCurve.ToString() );
   }