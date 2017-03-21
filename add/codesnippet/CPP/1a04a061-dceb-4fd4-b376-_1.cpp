public:
   void DrawPieRectangle( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle for ellipse.
      Rectangle rect = Rectangle(0,0,200,100);

      // Create start and sweep angles.
      float startAngle = 0.0F;
      float sweepAngle = 45.0F;

      // Draw pie to screen.
      e->Graphics->DrawPie( blackPen, rect, startAngle, sweepAngle );
   }