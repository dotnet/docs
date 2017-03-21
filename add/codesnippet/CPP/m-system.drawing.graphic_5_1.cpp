public:
   void DrawLinesPoint( PaintEventArgs^ e )
   {
      // Create pen.
      Pen^ pen = gcnew Pen( Color::Black,3.0f );

      // Create array of points that define lines to draw.
      array<Point>^ points = {Point(10,10),Point(10,100),Point(200,50),Point(250,300)};

      //Draw lines to screen.
      e->Graphics->DrawLines( pen, points );
   }