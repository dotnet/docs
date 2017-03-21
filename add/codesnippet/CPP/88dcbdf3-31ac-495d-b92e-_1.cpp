public:
   void DrawStringRectangleF( PaintEventArgs^ e )
   {
      // Create string to draw.
      String^ drawString = "Sample Text";

      // Create font and brush.
      System::Drawing::Font^ drawFont = gcnew System::Drawing::Font( "Arial",16 );
      SolidBrush^ drawBrush = gcnew SolidBrush( Color::Black );

      // Create rectangle for drawing.
      float x = 150.0F;
      float y = 150.0F;
      float width = 200.0F;
      float height = 50.0F;
      RectangleF drawRect = RectangleF(x,y,width,height);

      // Draw rectangle to screen.
      Pen^ blackPen = gcnew Pen( Color::Black );
      e->Graphics->DrawRectangle( blackPen, x, y, width, height );

      // Draw string to screen.
      e->Graphics->DrawString( drawString, drawFont, drawBrush, drawRect );
   }