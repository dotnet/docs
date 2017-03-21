public:
   void DrawPolygonPoint( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Create points that define polygon.
      Point point1 = Point(50,50);
      Point point2 = Point(100,25);
      Point point3 = Point(200,5);
      Point point4 = Point(250,50);
      Point point5 = Point(300,100);
      Point point6 = Point(350,200);
      Point point7 = Point(250,250);
      array<Point>^ curvePoints = {point1,point2,point3,point4,point5,point6,point7};

      // Draw polygon to screen.
      e->Graphics->DrawPolygon( blackPen, curvePoints );
   }