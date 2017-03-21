public:
   void GetEmHeight_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ emFontFamily = gcnew FontFamily( "arial" );

      // Get the em height of the font family in design units.
      int emHeight = emFontFamily->GetEmHeight( FontStyle::Regular );

      // Draw the result as a string to the screen.
      e->Graphics->DrawString( String::Format( "emFontFamily.GetEmHeight() returns {0}.", emHeight ),
            gcnew System::Drawing::Font( emFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }