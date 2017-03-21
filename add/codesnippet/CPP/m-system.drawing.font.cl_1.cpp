public:
   void Clone_Example( PaintEventArgs^ e )
   {
      // Create a Font object.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",16 );

      // Create a copy of myFont.
      System::Drawing::Font^ cloneFont = dynamic_cast<System::Drawing::Font^>(myFont->Clone());

      // Use cloneFont to draw text to the screen.
      e->Graphics->DrawString( "This is a cloned font", cloneFont, Brushes::Black, 0, 0 );
   }