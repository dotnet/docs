public:
   void FillRectangleRectangle( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create rectangle.
      Rectangle rect = Rectangle(0,0,200,200);

      // Fill rectangle to screen.
      e->Graphics->FillRectangle( blueBrush, rect );
   }