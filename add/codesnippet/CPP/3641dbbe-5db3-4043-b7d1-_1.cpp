private:
   void FlattenExample( PaintEventArgs^ e )
   {
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Matrix^ translateMatrix = gcnew Matrix;
      translateMatrix->Translate( 0, 10 );
      Point point1 = Point(20,100);
      Point point2 = Point(70,10);
      Point point3 = Point(130,200);
      Point point4 = Point(180,100);
      array<Point>^ points = {point1,point2,point3,point4};
      myPath->AddCurve( points );
      e->Graphics->DrawPath( gcnew Pen( Color::Black,2.0f ), myPath );
      myPath->Flatten( translateMatrix, 10.0f );
      e->Graphics->DrawPath( gcnew Pen( Color::Red,1.0f ), myPath );
   }