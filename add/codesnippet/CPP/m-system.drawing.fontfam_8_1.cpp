public:
   void GetHashCode_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Get the hash code for myFontFamily.
      int hashCode = myFontFamily->GetHashCode();

      // Draw the value of hashCode to the screen as a string.
      e->Graphics->DrawString( String::Format( "hashCode = {0}", hashCode ),
            gcnew System::Drawing::Font( myFontFamily,16 ), Brushes::Black, PointF(0,0) );
   }