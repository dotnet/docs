private:
   void AddBeziersExample( PaintEventArgs^ e )
   {
      // Adds two Bezier curves.
      array<Point>^ myArray = {Point(20,100),Point(40,75),Point(60,125),Point(80,100),Point(100,50),Point(120,150),Point(140,100)};

      // Create the path and add the curves.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddBeziers( myArray );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }