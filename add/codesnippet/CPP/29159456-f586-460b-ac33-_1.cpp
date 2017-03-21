public:
   void RectangleInflateTest( PaintEventArgs^ e )
   {
      // Create a rectangle.
      Rectangle rect = Rectangle(100,100,50,50);

      // Draw the uninflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Black, rect );

      // Call Inflate.
      Rectangle rect2 = Rectangle::Inflate( rect, 50, 50 );

      // Draw the inflated rectangle to screen.
      e->Graphics->DrawRectangle( Pens::Red, rect2 );
   }