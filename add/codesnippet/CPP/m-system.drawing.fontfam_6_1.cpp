public:
   void IsStyleAvailable_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Test whether myFontFamily is available in Italic.
      if ( myFontFamily->IsStyleAvailable( FontStyle::Italic ) )
      {
         // Create a Font object using myFontFamily.
         System::Drawing::Font^ familyFont = gcnew System::Drawing::Font( myFontFamily,16,FontStyle::Italic );

         // Use familyFont to draw text to the screen.
         e->Graphics->DrawString( myFontFamily->Name + " is available in Italic",
               familyFont, Brushes::Black, PointF(0,0) );
      }
   }