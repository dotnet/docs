public:
   void GetHeight_Example( PaintEventArgs^ e )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      //Draw text to the screen with myFont.
      e->Graphics->DrawString( "This is the first line", myFont, Brushes::Black, PointF(0,0) );

      //Get the height of myFont.
      float height = myFont->GetHeight( e->Graphics );

      //Draw text immediately below the first line of text.
      e->Graphics->DrawString( "This is the second line", myFont, Brushes::Black, PointF(0,height) );
   }