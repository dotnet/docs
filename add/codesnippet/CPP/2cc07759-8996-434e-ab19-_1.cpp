public:
   void DrawPieRectangleF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create rectangle for ellipse.
      RectangleF rect = RectangleF(0.0F,0.0F,200.0F,100.0F);

      // Create start and sweep angles.
      float startAngle = 0.0F;
      float sweepAngle = 45.0F;

      // Draw pie to screen.
      e->Graphics->DrawPie( blackPen, rect, startAngle, sweepAngle );
   }