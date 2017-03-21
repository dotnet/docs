private:
   void AddEllipseExample( PaintEventArgs^ e )
   {
      // Create a path and add an ellipse.
      Rectangle myEllipse = Rectangle(20,20,100,50);
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddEllipse( myEllipse );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }