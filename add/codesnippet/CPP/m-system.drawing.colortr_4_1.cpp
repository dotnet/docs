public:
   void ToWin32_Example( PaintEventArgs^ /*e*/ )
   {
      // Create an instance of a Color structure.
      Color myColor = Color::Red;

      // Translate myColor to an OLE color.
      int winColor = ColorTranslator::ToWin32( myColor );

      // Show a message box with the value of winColor.
      MessageBox::Show( winColor.ToString() );
   }