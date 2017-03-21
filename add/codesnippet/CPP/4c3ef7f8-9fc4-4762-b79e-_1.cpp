private:
   void AddPathExample( PaintEventArgs^ e )
   {
      // Create the first pathright side up triangle.
      array<Point>^ myArray = {Point(30,30),Point(60,60),Point(0,60),Point(30,30)};
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLines( myArray );

      // Create the second pathinverted triangle.
      array<Point>^ myArray2 = {Point(30,30),Point(0,0),Point(60,0),Point(30,30)};
      GraphicsPath^ myPath2 = gcnew GraphicsPath;
      myPath2->AddLines( myArray2 );

      // Add the second path to the first path.
      myPath->AddPath( myPath2, true );

      // Draw the combined path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }