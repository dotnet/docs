public:
   void FillRectangleRectangleF( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create rectangle.
      RectangleF rect = RectangleF(0.0F,0.0F,200.0F,200.0F);

      // Fill rectangle to screen.
      e->Graphics->FillRectangle( blueBrush, rect );
   }