public:
   void FillRectanglesRectangle( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ blueBrush = gcnew SolidBrush( Color::Blue );

      // Create array of rectangles.
      array<Rectangle>^ rects = {Rectangle(0,0,100,200),Rectangle(100,200,250,50),Rectangle(300,0,50,100)};

      // Fill rectangles to screen.
      e->Graphics->FillRectangles( blueBrush, rects );
   }