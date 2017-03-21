private:
   void CloseAllFiguresExample( PaintEventArgs^ e )
   {
      // Create a path containing several open-ended figures.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->StartFigure();
      myPath->AddLine( Point(10,10), Point(150,10) );
      myPath->AddLine( Point(150,10), Point(10,150) );
      myPath->StartFigure();
      myPath->AddArc( 200, 200, 100, 100, 0, 90 );
      myPath->StartFigure();
      Point point1 = Point(300,300);
      Point point2 = Point(400,325);
      Point point3 = Point(400,375);
      Point point4 = Point(300,400);
      array<Point>^ points = {point1,point2,point3,point4};
      myPath->AddCurve( points );

      // Close all the figures.
      myPath->CloseAllFigures();

      // Draw the path to the screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Black,3.0f ), myPath );
   }