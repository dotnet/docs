   //Reference the GDI DeleteObject method.
public:
   [System::Runtime::InteropServices::DllImport("GDI32.dll")]
   static bool DeleteObject( IntPtr objectHandle );
   void ToHfont_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Get a handle to the Font object.
      IntPtr hFont = myFont->ToHfont();

      // Display a message box with the value of hFont.
      MessageBox::Show( hFont.ToString() );

      //Dispose of the hFont.
      DeleteObject( hFont );
   }