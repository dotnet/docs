        private void DrawBeziersPointF(PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(Color.Black, 3);
                     
            // Create points for curve.
            PointF start = new PointF(100.0F, 100.0F);
            PointF control1 = new PointF(200.0F, 10.0F);
            PointF control2 = new PointF(350.0F, 50.0F);
            PointF end1 = new PointF(500.0F, 100.0F);
            PointF control3 = new PointF(600.0F, 150.0F);
            PointF control4 = new PointF(650.0F, 250.0F);
            PointF end2 = new PointF(500.0F, 300.0F);
            PointF[] bezierPoints = { start, control1, control2, end1,
                 control3, control4, end2 };      
                         
            // Draw arc to screen.
            e.Graphics.DrawBeziers(blackPen, bezierPoints);
        }