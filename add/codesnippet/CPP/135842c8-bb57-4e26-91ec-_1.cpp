public:
   void FillRectangleFloat( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create location and size of rectangle.
      float x = 0.0F;
      float y = 0.0F;
      float width = 200.0F;
      float height = 200.0F;

      // Fill rectangle to screen.
      e->Graphics->FillRectangle( blueBrush, x, y, width, height );
   }