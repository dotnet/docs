public:
   void GetCellAscent_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ ascentFontFamily = gcnew FontFamily( "arial" );

      // Get the cell ascent of the font family in design units.
      int cellAscent = ascentFontFamily->GetCellAscent( FontStyle::Regular );

      // Draw the result as a string to the screen.
      e->Graphics->DrawString( String::Format( "ascentFontFamily.GetCellAscent() returns {0}.", cellAscent ),
            gcnew System::Drawing::Font( ascentFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }