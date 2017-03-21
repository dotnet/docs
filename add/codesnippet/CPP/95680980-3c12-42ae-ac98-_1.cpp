public:
   void NextPathTypeExample( PaintEventArgs^ e )
   {
      // Create the GraphicsPath.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, and an ellipse.
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // List all of the path points to the screen.
      ListPathPoints( e, myPath, nullptr, 20, 1 );

      // Create a GraphicsPathIterator.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );

      // Rewind the Iterator.
      myPathIterator->Rewind();

      // Iterate the subpaths and types, and list the results to
      // the screen.
            int i;
      int j = 20;
      int mySubPaths;
      int subPathStartIndex;
      int subPathEndIndex;
      Boolean IsClosed;
      Byte subPathPointType;
      int pointTypeStartIndex;
      int pointTypeEndIndex;
      int numPointsFound;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );
      j = 20;
      for ( i = 0; i < 3; i++ )
      {
         mySubPaths = myPathIterator->NextSubpath( subPathStartIndex, subPathEndIndex, IsClosed );
         numPointsFound = myPathIterator->NextPathType( subPathPointType, pointTypeStartIndex, pointTypeEndIndex );
         e->Graphics->DrawString( String::Format( "SubPath: {0}  Points Found: {1}  Type of Points: {2}", i,
               numPointsFound, subPathPointType ), myFont, myBrush, 200.0f, (float)j );
         j += 20;
      }

      // List the total number of path points to the screen.
      ListPathPoints( e, myPath, myPathIterator, 200, 2 );
   }

   //-------------------------------------------------------
   //This function is a helper function used by
   // NextPathTypeExample.
   //-------------------------------------------------------
   void ListPathPoints( PaintEventArgs^ e, GraphicsPath^ myPath, GraphicsPathIterator^ myPathIterator, int xOffset, int listType )
   {
      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for drawing the points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );
      if ( listType == 1 )
      {
         // Draw the set of path points and types to the screen.
         for ( i = 0; i < myPathPointCount; i++ )
         {
            e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ],
                  myFont, myBrush, (float)xOffset, (float)j );
            j += 20;
         }
      }
      else
      if ( listType == 2 )
      {
         // Draw the total number of points to the screen.
         int myPathTotalPoints = myPathIterator->Count;
         e->Graphics->DrawString( String::Format( "Total Points = {0}", myPathTotalPoints ), myFont, myBrush, (float)xOffset, 100.0f );
      }
      else
      {
         e->Graphics->DrawString( "Wrong or no list type argument.", myFont, myBrush, (float)xOffset, 200.0f );
      }
   }