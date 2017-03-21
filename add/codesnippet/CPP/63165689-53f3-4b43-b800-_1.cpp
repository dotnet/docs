private:
   void NextSubpathExample( PaintEventArgs^ e )
   {
      // Create the GraphicsPath.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, an ellipse, and 2 markers.
      myPath->AddLines( myPoints );
      myPath->AddRectangle( myRect );
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for drawing the array of
      // points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // Draw the set of path points and types to the screen.
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );
      int myStartIndex;
      int myEndIndex;
      bool myIsClosed;

      // get the number of Subpaths.
      int numSubpaths = myPathIterator->NextSubpath( myPath, myIsClosed );
      numSubpaths -= 1;

      // Rewind the Iterator.
      myPathIterator->Rewind();

      // List the Subpaths to the screen.
      j = 20;
      for ( i = 0; i < numSubpaths; i++ )
      {
         myPathIterator->NextSubpath( myStartIndex, myEndIndex, myIsClosed );
         String^ s = String::Format( "Subpath {0}:  Start: {1}", i, myStartIndex );
         s = s + String::Format( "  End: {0}  IsClosed: {1}", myEndIndex, myIsClosed );
         e->Graphics->DrawString( s, myFont, myBrush, 200, j );
         j += 20;
      }

      // Draw the total number of Subpaths to the screen.
      j += 20;
      e->Graphics->DrawString( String::Format( "Number Subpaths = {0}", numSubpaths ), myFont, myBrush, 200, j );
   }