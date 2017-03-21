   void ToStringExample( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::FromArgb( 255, 0, 0, 255 ) );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Times New Roman",14 );
      StringFormat^ myStringFormat = gcnew StringFormat;

      // String variable to hold the values of the StringFormat object.
      String^ strFmtString;

      // Convert the string format object to a string (only certain information
      // in the object is converted) and display the string.
      strFmtString = myStringFormat->ToString();
      g->DrawString( String::Format( "Before changing properties:   {0}", myStringFormat ), myFont, blueBrush, 20, 40 );

      // Change some properties of the string format
      myStringFormat->Trimming = StringTrimming::None;
      myStringFormat->FormatFlags = (StringFormatFlags)(StringFormatFlags::NoWrap | StringFormatFlags::NoClip);

      // Convert the string format object to a string and display the string.
      // The string will be different because the properties of the string
      // format have changed.
      strFmtString = myStringFormat->ToString();
      g->DrawString( String::Format( "After changing properties:   {0}", myStringFormat ), myFont, blueBrush, 20, 70 );
   }