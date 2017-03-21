public:
   void DrawLinesPointF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ pen = gcnew Pen( Color::Black,3.0f );

      // Create array of points that define lines to draw.
      array<PointF>^ points = {PointF(10.0F,10.0F),PointF(10.0F,100.0F),PointF(200.0F,50.0F),PointF(250.0F,300.0F)};

      //Draw lines to screen.
      e->Graphics->DrawLines( pen, points );
   }