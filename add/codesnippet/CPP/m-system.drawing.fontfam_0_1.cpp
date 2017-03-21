public:
   void Equals_Example( PaintEventArgs^ /*e*/ )
   {
      // Create two FontFamily objects.
      FontFamily^ firstFontFamily = gcnew FontFamily( "Arial" );
      FontFamily^ secondFontFamily = gcnew FontFamily( "Times New Roman" );

      // Check to see if the two font families are equivalent.
      bool equalFonts = firstFontFamily->Equals( secondFontFamily );

      // Display the result of the test in a message box.
      MessageBox::Show( equalFonts.ToString() );
   }