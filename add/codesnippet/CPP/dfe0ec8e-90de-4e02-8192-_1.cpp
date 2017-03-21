private:
   void DrawCurvePointFTension( PaintEventArgs^ e )
   {
      // Create pens.
      Pen^ redPen = gcnew Pen( Color::Red,3.0f );
      Pen^ greenPen = gcnew Pen( Color::Green,3.0f );

      // Create points that define curve.
      PointF point1 = PointF(50.0F,50.0F);
      PointF point2 = PointF(100.0F,25.0F);
      PointF point3 = PointF(200.0F,5.0F);
      PointF point4 = PointF(250.0F,50.0F);
      PointF point5 = PointF(300.0F,100.0F);
      PointF point6 = PointF(350.0F,200.0F);
      PointF point7 = PointF(250.0F,250.0F);
      array<PointF>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw lines between original points to screen.
      e->Graphics->DrawLines( redPen, curvePoints );

      // Create tension.
      float tension = 1.0F;

      // Draw curve to screen.
      e->Graphics->DrawCurve( greenPen, curvePoints, tension );
   }