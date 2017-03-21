private:
   void AddRectanglesExample( PaintEventArgs^ e )
   {
      // Adds a pattern of rectangles to a GraphicsPath object.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      array<Rectangle>^ pathRects = {Rectangle(20,20,100,200),Rectangle(40,40,120,220),Rectangle(60,60,240,140)};
      myPath->AddRectangles( pathRects );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }