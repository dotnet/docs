public:
   void DrawStringFloat( PaintEventArgs^ e )
   {
      // Create string to draw.
      String^ drawString = "Sample Text";

      // Create font and brush.
      System::Drawing::Font^ drawFont = gcnew System::Drawing::Font( "Arial",16 );
      SolidBrush^ drawBrush = gcnew SolidBrush( Color::Black );

      // Create point for upper-left corner of drawing.
      float x = 150.0F;
      float y = 150.0F;

      // Draw string to screen.
      e->Graphics->DrawString( drawString, drawFont, drawBrush, x, y );
   }