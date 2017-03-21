public:
   void GetCellDescent_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ descentFontFamily = gcnew FontFamily( "arial" );

      // Get the cell descent of the font family in design units.
      int cellDescent = descentFontFamily->GetCellDescent( FontStyle::Regular );

      // Draw the result as a string to the screen.
      e->Graphics->DrawString( String::Format( "descentFontFamily.GetCellDescent() returns {0}.", cellDescent ),
            gcnew System::Drawing::Font( descentFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }