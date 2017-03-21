private:
   void AddPieExample( PaintEventArgs^ e )
   {
      // Create a pie slice of a circle using the AddPie method.
      GraphicsPath^ myPath = gcnew GraphicsPath;
      myPath->AddPie( 20, 20, 70, 70, -45, 90 );

      // Draw the path to the screen.
      Pen^ myPen = gcnew Pen( Color::Black,2.0f );
      e->Graphics->DrawPath( myPen, myPath );
   }