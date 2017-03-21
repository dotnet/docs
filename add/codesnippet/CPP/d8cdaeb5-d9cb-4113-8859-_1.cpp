public:
   void FillClosedCurvePointFillMode( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ redBrush = gcnew SolidBrush( Color::Red );

      //Create array of points for curve.
      Point point1 = Point(100,100);
      Point point2 = Point(200,50);
      Point point3 = Point(250,200);
      Point point4 = Point(50,150);
      array<Point>^ points = {point1,point2,point3,point4};

      // Set fill mode.
      FillMode newFillMode = FillMode::Winding;

      // Fill curve on screen.
      e->Graphics->FillClosedCurve( redBrush, points, newFillMode );
   }