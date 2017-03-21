public:
   void DrawLineInt( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create coordinates of points that define line.
      int x1 = 100;
      int y1 = 100;
      int x2 = 500;
      int y2 = 100;

      // Draw line to screen.
      e->Graphics->DrawLine( blackPen, x1, y1, x2, y2 );
   }