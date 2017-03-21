private:
   void SetMarkersExample( PaintEventArgs^ e )
   {
      // Create a path and set two markers.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( Point(0,0), Point(50,50) );
      myPath->SetMarkers();
      Rectangle rect = Rectangle(50,50,50,50);
      myPath->AddRectangle( rect );
      myPath->SetMarkers();
      myPath->AddEllipse( 100, 100, 100, 50 );

      // Draw the path to screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Black,2.0f ), myPath );
   }