public:
   void ToOle_Example( PaintEventArgs^ /*e*/ )
   {
      // Create an instance of a Color structure.
      Color myColor = Color::Red;

      // Translate myColor to an OLE color.
      int oleColor = ColorTranslator::ToOle( myColor );

      // Show a message box with the value of oleColor.
      MessageBox::Show( oleColor.ToString() );
   }