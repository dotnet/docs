public:
   void FillEllipseRectangle( PaintEventArgs^ e )
   {
      // Create solid brush.
      SolidBrush^ redBrush = gcnew SolidBrush( Color::Red );

      // Create rectangle for ellipse.
      int x = 0;
      int y = 0;
      int width = 200;
      int height = 100;
      Rectangle rect = Rectangle(x,y,width,height);

      // Fill ellipse on screen.
      e->Graphics->FillEllipse( redBrush, rect );
   }