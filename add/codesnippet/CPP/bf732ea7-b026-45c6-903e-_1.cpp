public:
   void MeasureStringPointFFormat( PaintEventArgs^ e )
   {

      // Set up string.
      String^ measureString = "Measure String";
      System::Drawing::Font^ stringFont = gcnew System::Drawing::Font( "Arial",16 );

      // Set point for upper-left corner of string.
      float x = 50.0F;
      float y = 50.0F;
      PointF ulCorner = PointF(x,y);

      // Set string format.
      StringFormat^ newStringFormat = gcnew StringFormat;
      newStringFormat->FormatFlags = StringFormatFlags::DirectionVertical;

      // Measure string.
      SizeF stringSize = e->Graphics->MeasureString( measureString, stringFont, ulCorner, newStringFormat );

      // Draw rectangle representing size of string.
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red,1.0f ), x, y, stringSize.Width, stringSize.Height );

      // Draw string to screen.
      e->Graphics->DrawString( measureString, stringFont, Brushes::Black, ulCorner, newStringFormat );
   }