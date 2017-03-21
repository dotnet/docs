public:
   void FillEllipseFloat( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ redBrush = gcnew SolidBrush( Color::Red );

      // Create location and size of ellipse.
      float x = 0.0F;
      float y = 0.0F;
      float width = 200.0F;
      float height = 100.0F;

      // Fill ellipse on screen.
      e->Graphics->FillEllipse( redBrush, x, y, width, height );
   }