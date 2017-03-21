public:
   void ToString_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Get a string that represents myFont.
      String^ fontString = myFont->ToString();

      // Display a message box with fontString.
      MessageBox::Show( fontString );
   }