public:
   void Equals_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ firstFont = gcnew System::Drawing::Font( "Arial",16 );

      // Create a second Font object.
      System::Drawing::Font^ secondFont = gcnew System::Drawing::Font( gcnew FontFamily( "Arial" ),16 );

      // Test to see if firstFont is identical to secondFont.
      bool fontTest = firstFont->Equals( secondFont );

      // Display a message box with the result of the test.
      MessageBox::Show( fontTest.ToString() );
   }