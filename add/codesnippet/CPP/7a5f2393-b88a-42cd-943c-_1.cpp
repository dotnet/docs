public:
   void DrawLinePoint( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points that define line.
      Point point1 = Point(100,100);
      Point point2 = Point(500,100);

      // Draw line to screen.
      e->Graphics->DrawLine( blackPen, point1, point2 );
   }