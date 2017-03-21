public:
   void SetDigitSubExample( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::FromArgb( 255, 0, 0, 255 ) );
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Courier New",12 );
      StringFormat^ myStringFormat = gcnew StringFormat;
      String^ myString = "0 1 2 3 4 5 6 7 8 9";

      // Arabic (0x0C01) digits.
      // Use National substitution method.
      myStringFormat->SetDigitSubstitution( 0x0C01, StringDigitSubstitute::National );
      g->DrawString( String::Format( "Arabic:\nMethod of substitution = National:     {0}", myString ), myFont, blueBrush, PointF(10.0f,20.0f), myStringFormat );

      // Use Traditional substitution method.
      myStringFormat->SetDigitSubstitution( 0x0C01, StringDigitSubstitute::Traditional );
      g->DrawString( String::Format( "Method of substitution = Traditional:  {0}", myString ), myFont, blueBrush, PointF(10.0f,55.0f), myStringFormat );

      // Thai (0x041E) digits.
      // Use National substitution method.
      myStringFormat->SetDigitSubstitution( 0x041E, StringDigitSubstitute::National );
      g->DrawString( String::Format( "Thai:\nMethod of substitution = National:     {0}", myString ), myFont, blueBrush, PointF(10.0f,85.0f), myStringFormat );

      // Use Traditional substitution method.
      myStringFormat->SetDigitSubstitution( 0x041E, StringDigitSubstitute::Traditional );
      g->DrawString( String::Format( "Method of substitution = Traditional:  {0}", myString ), myFont, blueBrush, PointF(10.0f,120.0f), myStringFormat );
   }