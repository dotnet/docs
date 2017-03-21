public:
   void MeasureCharacterRangesRegions( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "First and Second ranges";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Times New Roman",16.0F );

      // Set character ranges to "First" and "Second".
      array<CharacterRange>^ characterRanges = {CharacterRange(0,5),CharacterRange(10,6)};

      // Create rectangle for layout.
      float x = 50.0F;
      float y = 50.0F;
      float width = 35.0F;
      float height = 200.0F;
      RectangleF layoutRect = RectangleF(x,y,width,height);

      // Set string format.
      StringFormat^ stringFormat = gcnew StringFormat;
      stringFormat->FormatFlags = StringFormatFlags::DirectionVertical;
      stringFormat->SetMeasurableCharacterRanges( characterRanges );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, x, y, stringFormat );

      // Measure two ranges in string.
      array<System::Drawing::Region^>^stringRegions = e->Graphics->MeasureCharacterRanges( measureString, 
	stringFont, layoutRect, stringFormat );

      // Draw rectangle for first measured range.
      RectangleF measureRect1 = stringRegions[ 0 ]->GetBounds( e->Graphics );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), Rectangle::Round( measureRect1 ) );

      // Draw rectangle for second measured range.
      RectangleF measureRect2 = stringRegions[ 1 ]->GetBounds( e->Graphics );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Blue,1.0f ), Rectangle::Round( measureRect2 ) );
   }