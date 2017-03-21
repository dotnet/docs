public:
   void FillRectanglesRectangleF( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create array of rectangles.
      array<RectangleF>^ rects = {RectangleF(0.0F,0.0F,100.0F,200.0F),RectangleF(100.0F,200.0F,250.0F,50.0F),RectangleF(300.0F,0.0F,50.0F,100.0F)};

      // Fill rectangles to screen.
      e->Graphics->FillRectangles( blueBrush, rects );
   }