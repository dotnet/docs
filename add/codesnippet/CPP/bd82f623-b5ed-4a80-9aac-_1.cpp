public:
   void FillPathEllipse( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ redBrush = gcnew SolidBrush( Color::Red );

      // Create graphics path object and add ellipse.
      GraphicsPath^ graphPath = gcnew GraphicsPath;
      graphPath->AddEllipse( 0, 0, 200, 100 );

      // Fill graphics path to screen.
      e->Graphics->FillPath( redBrush, graphPath );
   }