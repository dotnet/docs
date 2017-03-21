public:
   void ToString_Example( PaintEventArgs^ e )
   {
      // Create a FontFamily object.
      FontFamily^ myFontFamily = gcnew FontFamily( "Arial" );

      // Draw a string representation of myFontFamily to the screen.
      e->Graphics->DrawString( myFontFamily->ToString(), gcnew System::Drawing::Font( myFontFamily,16 ),
            Brushes::Black, PointF(0,0) );
   }