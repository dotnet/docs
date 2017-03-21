public:
   void DrawPathEllipse( PaintEventArgs^ e )
   {
      // Create graphics path object and add ellipse.
      GraphicsPath^ graphPath = gcnew GraphicsPath;
      graphPath->AddEllipse( 0, 0, 200, 100 );

      // Create pen.
      Pen^ blackPen = gcnew Pen( Color::Black,3.0f );

      // Draw graphics path to screen.
      e->Graphics->DrawPath( blackPen, graphPath );
   }