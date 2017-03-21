public:
   void GetLineSpacing_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Get the line spacing for myFontFamily.
      int lineSpacing = myFontFamily->GetLineSpacing( FontStyle::Regular );

      // Draw the value of lineSpacing to the screen as a string.
      e->Graphics->DrawString( String::Format( "lineSpacing = {0}", lineSpacing ),
            gcnew System::Drawing::Font( myFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }