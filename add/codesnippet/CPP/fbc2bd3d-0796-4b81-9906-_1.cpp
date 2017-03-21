public:
   void DrawRectanglesRectangle( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create array of rectangles.
      array<Rectangle>^ rects = {Rectangle(0,0,100,200),Rectangle(100,200,250,50),Rectangle(300,0,50,100)};

      // Draw rectangles to screen.
      e->Graphics->DrawRectangles( blackPen, rects );
   }