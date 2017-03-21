private:
   void ClearMarkersExample( PaintEventArgs^ e )
   {
      // Set several markers in a path.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( 0, 0, 100, 200 );
      myPath->SetMarkers();
      myPath->AddLine( Point(100,100), Point(200,100) );
      Rectangle rect = Rectangle(200,0,100,200);
      myPath->AddRectangle( rect );
      myPath->SetMarkers();
      myPath->AddLine( Point(250,200), Point(250,300) );
      myPath->SetMarkers();

      // Clear the markers.
      myPath->ClearMarkers();

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }