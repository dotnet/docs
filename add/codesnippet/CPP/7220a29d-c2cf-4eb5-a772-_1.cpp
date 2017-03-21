public:
   void DrawRectangleRectangle( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle.
      Rectangle rect = Rectangle(0,0,200,200);

      // Draw rectangle to screen.
      e->Graphics->DrawRectangle( blackPen, rect );
   }