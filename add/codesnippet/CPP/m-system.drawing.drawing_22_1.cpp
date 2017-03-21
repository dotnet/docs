   void GraphicsPathReverseExample( PaintEventArgs^ e )
   {
      // Create a path and add a line, ellipse, and arc.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( Point(0,0), Point(100,100) );
      myPath->AddEllipse( 100, 100, 200, 250 );
      myPath->AddArc( 300, 250, 100, 100, 0, 90 );

      // Draw the first set of points to the screen.
      DrawPoints2( e, myPath->PathPoints, 20 );

      // Call GraphicsPath.Reverse.
      myPath->Reverse();

      // Draw the reversed set of points to the screen.
      DrawPoints2( e, myPath->PathPoints, 150 );
   }

   //End GraphicsPathReverseExample.
   // A helper function GraphicsPathReverseExample is used to draw the
   // points to the screen.
   void DrawPoints2( PaintEventArgs^ e, array<PointF>^ pathPoints, int xOffset )
   {
      int y = 20;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      for ( int i = 0; i < pathPoints->Length; i++ )
      {
         e->Graphics->DrawString( String::Concat( pathPoints[ i ].X, ", ", pathPoints[ i ].Y ), myFont, Brushes::Black, (float)xOffset, (float)y );
         y += 20;

      }
   }
   // End DrawPoints