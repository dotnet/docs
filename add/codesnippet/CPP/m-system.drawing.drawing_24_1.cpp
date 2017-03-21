private:
   void AddLinesExample( PaintEventArgs^ e )
   {
      // Create a symetrical triangle using an array of points.
      array<Point>^ myArray = {Point(30,30),Point(60,60),Point(0,60),Point(30,30)};

      //Create a path and add lines.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLines( myArray );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }