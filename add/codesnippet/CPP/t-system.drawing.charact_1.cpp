   void HighlightACharacterRange( PaintEventArgs^ e )
   {
      // Declare the string to draw.
      String^ message = "This is the string to highlight a word in.";

      // Declare the word to highlight.
      String^ searchWord = "string";

      // Create a CharacterRange array with the searchWord 
      // location and length.
      array<CharacterRange>^ temp = {CharacterRange( message->IndexOf( searchWord ), searchWord->Length )};
      array<CharacterRange>^ranges = temp;

      // Construct a StringFormat object.
      StringFormat^ stringFormat1 = gcnew StringFormat;

      // Set the ranges on the StringFormat object.
      stringFormat1->SetMeasurableCharacterRanges( ranges );

      // Declare the font to write the message in.
      System::Drawing::Font^ largeFont = gcnew System::Drawing::Font( FontFamily::GenericSansSerif,16.0F,GraphicsUnit::Pixel );

      // Construct a new Rectangle.
      Rectangle displayRectangle = Rectangle(20,20,200,100);

      // Convert the Rectangle to a RectangleF.
      RectangleF displayRectangleF = displayRectangle;

      // Get the Region to highlight by calling the 
      // MeasureCharacterRanges method.
      array<System::Drawing::Region^>^charRegion = e->Graphics->MeasureCharacterRanges( message, largeFont, displayRectangleF, stringFormat1 );

      // Draw the message string on the form.
      e->Graphics->DrawString( message, largeFont, Brushes::Blue, displayRectangleF );

      // Fill in the region using a semi-transparent color.
      e->Graphics->FillRegion( gcnew SolidBrush( Color::FromArgb( 50, Color::Fuchsia ) ), charRegion[ 0 ] );
      delete largeFont;
   }