private:
   void AddPolygonExample( PaintEventArgs^ e )
   {
      // Create an array of points.
      array<Point>^ myArray = {Point(23,20),Point(40,10),Point(57,20),Point(50,40),Point(30,40)};

      // Create a GraphicsPath object and add a polygon.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddPolygon( myArray );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }