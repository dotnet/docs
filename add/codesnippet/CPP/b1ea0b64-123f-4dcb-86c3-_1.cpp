public:
   void CopyDataExample( PaintEventArgs^ e )
   {
      // Create a graphics path.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up a points array.
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};

      // Create a rectangle.
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add the points, rectangle, and an ellipse to the path.
      myPath->AddLines( myPoints );
      myPath->SetMarkers();
      myPath->AddRectangle( myRect );
      myPath->SetMarkers();
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
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator for myPath and rewind it.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );
      myPathIterator->Rewind();

      // Set up the arrays to receive the copied data.
      array<PointF>^points = gcnew array<PointF>(myPathIterator->Count);
      array<Byte>^types = gcnew array<Byte>(myPathIterator->Count);
      int myStartIndex;
      int myEndIndex;
      
      // Increment the starting index to the second marker in the
      // path.
      myPathIterator->NextMarker( myStartIndex, myEndIndex );
      myPathIterator->NextMarker( myStartIndex, myEndIndex );
      
      // Copy all the points and types from the starting index to the
      // ending index to the points array and the types array
      // respectively.
      int numPointsCopied = myPathIterator->CopyData( points, types, myStartIndex, myEndIndex );
      
      // List the copied points to the right side of the screen.
      j = 20;
      int copiedStartIndex = 0;
      for ( i = 0; i < numPointsCopied; i++ )
      {
         copiedStartIndex = myStartIndex + i;
         e->Graphics->DrawString( String::Format( "Point: {0}, Value: {1}, Type: {2}", copiedStartIndex, points[ i ], types[ i ] ), myFont, myBrush, 200, j );
         j += 20;

      }
   }