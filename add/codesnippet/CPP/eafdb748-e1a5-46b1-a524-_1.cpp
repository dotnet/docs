public:
   void DrawLinePointF( PaintEventArgs^ e )
   {

      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );
      
      // Create points that define line.
      PointF point1 = PointF(100.0F,100.0F);
      PointF point2 = PointF(500.0F,100.0F);

      // Draw line to screen.
      e->Graphics->DrawLine( blackPen, point1, point2 );
   }