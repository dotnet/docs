public:
   void GraphicsPathResetExample( PaintEventArgs^ e )
   {
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      
      // Create a path and add a line, an ellipse, and an arc.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddLine( Point(0,0), Point(100,100) );
      myPath->AddEllipse( 100, 100, 200, 250 );
      myPath->AddArc( 300, 250, 100, 100, 0, 90 );
      
      // Draw the pre-reset points array to the screen.
      DrawPoints1( e, myPath->PathPoints, 20 );
      
      // Reset the path.
      myPath->Reset();
      
      // See if any points remain.
      if ( myPath->PointCount > 0 )
      {
         
         // Draw the post-reset points array to the screen.
         DrawPoints1( e, myPath->PathPoints, 150 );
      }
      else
            e->Graphics->DrawString( "No Points", myFont, Brushes::Black, 150, 20 );
      // If there are no points, say so.
   }


   //End GraphicsPathResetExample
   // A helper function GraphicsPathResetExample uses to draw the points.
   // to the screen.
   void DrawPoints1( PaintEventArgs^ e, array<PointF>^ pathPoints, int xOffset )
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