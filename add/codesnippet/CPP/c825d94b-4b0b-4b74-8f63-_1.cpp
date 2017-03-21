public:
   void MeasureStringSizeFFormat( PaintEventArgs^ e )
   {
      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set maximum layout size.
      SizeF layoutSize = SizeF(100.0F,200.0F);

      // Set string format.
      StringFormat^ newStringFormat = gcnew StringFormat;
      newStringFormat->FormatFlags = StringFormatFlags::DirectionVertical;

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, layoutSize, newStringFormat );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), 0.0F, 0.0F, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, PointF(0,0), newStringFormat );
   }