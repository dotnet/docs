public:
   void RectangleInflateTest2( PaintEventArgs^ e )
   {
      // Create a rectangle.
      Rectangle rect = Rectangle(100,100,50,50);

      // Draw the uninflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Black, rect );

      // Set up the inflate size.
      System::Drawing::Size inflateSize = System::Drawing::Size( 50, 50 );

      // Call Inflate.
      rect.Inflate( inflateSize );

      // Draw the inflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Red, rect );
   }