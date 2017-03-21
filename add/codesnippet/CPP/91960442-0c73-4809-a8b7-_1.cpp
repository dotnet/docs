public:
   void DrawPieFloat( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create location and size of ellipse.
      float x = 0.0F;
      float y = 0.0F;
      float width = 200.0F;
      float height = 100.0F;

      // Create start and sweep angles.
      float startAngle = 0.0F;
      float sweepAngle = 45.0F;

      // Draw pie to screen.
      e->Graphics->DrawPie( blackPen, x, y, width, height, startAngle, sweepAngle );
   }