private:
   void AddRectangleExample( PaintEventArgs^ e )
   {
      // Create a GraphicsPath object and add a rectangle to it.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      Rectangle pathRect = Rectangle(20,20,100,200);
      myPath->AddRectangle( pathRect );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }