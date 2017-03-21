public:
   void GetName_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Get the name of myFontFamily.
      String^ familyName = myFontFamily->GetName( 0 );

      // Draw the name of the myFontFamily to the screen as a string.
      e->Graphics->DrawString( String::Format( "The family name is {0}", familyName ),
            gcnew System::Drawing::Font( myFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }