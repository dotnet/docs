public:
   void MeasureStringWidthFormat( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set maximum width of string.
      int stringWidth = 100;

      // Set string format.
      StringFormat^ newStringFormat = gcnew StringFormat;
      newStringFormat->FormatFlags = StringFormatFlags::DirectionVertical;

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, stringWidth, newStringFormat );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0), newStringFormat );
   }