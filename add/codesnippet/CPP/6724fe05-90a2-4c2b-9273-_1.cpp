public:
   void DrawRectanglesRectangleF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create array of rectangles.
      array<RectangleF>^ rects = {RectangleF(0.0F,0.0F,100.0F,200.0F),RectangleF(100.0F,200.0F,250.0F,50.0F),RectangleF(300.0F,0.0F,50.0F,100.0F)};

      // Draw rectangles to screen.
      e->Graphics->DrawRectangles( blackPen, rects );
   }