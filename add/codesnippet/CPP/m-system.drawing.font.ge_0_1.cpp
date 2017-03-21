public:
   void GetHashCode_Example( PaintEventArgs^ /*e*/ )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Get the hash code for myFont.
      int hashCode = myFont->GetHashCode();

      // Display the hash code in a message box.
      MessageBox::Show( hashCode.ToString() );
   }