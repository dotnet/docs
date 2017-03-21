public:
   void EnumerateExample( PaintEventArgs^ e )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path, and arrays of
      // the  points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for listing the array of points on the left
      // side of the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // List the set of points and types and types to the left side
      // of the screen.
      e->Graphics->DrawString( "Original Data", myFont, myBrush, 20, j );
      j += 20;
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator for myPath.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );
      myPathIterator->Rewind();
      array<PointF>^points = gcnew array<PointF>(myPathIterator->Count);
      array<Byte>^types = gcnew array<Byte>(myPathIterator->Count);

      // int numPoints = myPathIterator->Enumerate(&points, &types);
      // Draw the set of copied points and types to the screen.
      j = 20;
      e->Graphics->DrawString( "Copied Data", myFont, myBrush, 200, j );
      j += 20;
      for ( i = 0; i < points->Length; i++ )
      {
         e->Graphics->DrawString( String::Format( "Point: {0}, Value: {1}, Type: {2}", i, points[ i ], types[ i ] ), myFont, myBrush, 200, j );
         j += 20;
      }
   }