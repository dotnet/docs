private:
   void DrawBeziersPointF( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points for curve.
      PointF start = PointF(100.0F,100.0F);
      PointF control1 = PointF(200.0F,10.0F);
      PointF control2 = PointF(350.0F,50.0F);
      PointF end1 = PointF(500.0F,100.0F);
      PointF control3 = PointF(600.0F,150.0F);
      PointF control4 = PointF(650.0F,250.0F);
      PointF end2 = PointF(500.0F,300.0F);
      array<PointF>^ bezierPoints = {start,control1,control2,end1,control3,control4,end2};

      // Draw arc to screen.
      e->Graphics->DrawBeziers( blackPen, bezierPoints );
   }