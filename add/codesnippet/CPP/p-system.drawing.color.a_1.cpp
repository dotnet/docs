   void ShowPropertiesOfSlateBlue( PaintEventArgs^ e )
   {
      Color slateBlue = Color::FromName( "SlateBlue" );
      Byte g = slateBlue.G;
      Byte b = slateBlue.B;
      Byte r = slateBlue.R;
      Byte a = slateBlue.A;
      array<Object^>^temp0 = {a,r,g,b};
      String^ text = String::Format( "Slate Blue has these ARGB values: Alpha:{0}, "
      "red:{1}, green: {2}, blue {3}", temp0 );
      e->Graphics->DrawString( text, gcnew System::Drawing::Font( this->Font,FontStyle::Italic ), gcnew SolidBrush( slateBlue ), RectangleF(PointF(0.0F,0.0F),this->Size) );
   }