   void CreatePointsAndSizes( PaintEventArgs^ e )
   {
      // Create the starting point.
      Point startPoint = Point(subtractButton->Size);
      
      // Use the addition operator to get the end point.
      Point endPoint = startPoint + System::Drawing::Size( 140, 150 );
      
      // Draw a line between the points.
      e->Graphics->DrawLine( SystemPens::Highlight, startPoint, endPoint );
      
      // Convert the starting point to a size and compare it to the
      // subtractButton size.  
      System::Drawing::Size buttonSize = (System::Drawing::Size)startPoint;
      if ( buttonSize == subtractButton->Size )
      {
         e->Graphics->DrawString( "The sizes are equal.", gcnew System::Drawing::Font( this->Font,FontStyle::Italic ), Brushes::Indigo, 10.0F, 65.0F );
      }
   }