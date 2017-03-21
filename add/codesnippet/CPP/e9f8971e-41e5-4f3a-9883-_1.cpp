private:
   void AddArcExample( PaintEventArgs^ e )
   {
      // Create a GraphicsPath object.
      GraphicsPath^ myPath = gcnew GraphicsPath;

      // Set up and call AddArc, and close the figure.
      Rectangle rect = Rectangle(20,20,50,100);
      myPath->StartFigure();
      myPath->AddArc( rect, 0, 180 );
      myPath->CloseFigure();

      // Draw the path to screen.
      e->Graphics->DrawPath( gcnew Pen( Color::Red,3.0f ), myPath );
   }