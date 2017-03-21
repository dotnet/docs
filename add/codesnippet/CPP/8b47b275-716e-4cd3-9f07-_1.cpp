public:
   void NextMarkerExample2( PaintEventArgs^ e )
   {
      // Create a graphics path.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up primitives to add to myPath.
      array<Point>^ myPoints = {Point(20,20),Point(120,120),Point(20,120),Point(20,20)};
      Rectangle myRect = Rectangle(120,120,100,100);

      // Add 3 lines, a rectangle, an ellipse, and 2 markers.
      myPath->AddLines( myPoints );
      myPath->SetMarkers();
      myPath->AddRectangle( myRect );
      myPath->SetMarkers();
      myPath->AddEllipse( 220, 220, 100, 100 );

      // Get the total number of points for the path,
      // and the arrays of the points and types.
      int myPathPointCount = myPath->PointCount;
      array<PointF>^myPathPoints = myPath->PathPoints;
      array<Byte>^myPathTypes = myPath->PathTypes;

      // Set up variables for listing all the values of the path's
      // points to the screen.
      int i;
      float j = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );

      // List the values for all of path points and types to
      // the left side of the screen.
      for ( i = 0; i < myPathPointCount; i++ )
      {
         e->Graphics->DrawString( myPathPoints[ i ].X + ", " + myPathPoints[ i ].Y + ", " + myPathTypes[ i ], myFont, myBrush, 20, j );
         j += 20;
      }

      // Create a GraphicsPathIterator.
      GraphicsPathIterator^ myPathIterator = gcnew GraphicsPathIterator( myPath );

      // Rewind the iterator.
      myPathIterator->Rewind();

      // Create a GraphicsPath to receive a section of myPath.
      GraphicsPath^ myPathSection = gcnew GraphicsPath;

      // Retrieve and list the number of points contained in
      // the first marker to the right side of the screen.
      int markerPoints;
      markerPoints = myPathIterator->NextMarker( myPathSection );
      e->Graphics->DrawString( String::Format( "Marker: 1  Num Points: {0}", markerPoints ), myFont, myBrush, 200, 20 );
   }