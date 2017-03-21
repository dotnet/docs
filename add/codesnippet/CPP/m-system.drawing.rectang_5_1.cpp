public:
   void RectangleFInflateExample( PaintEventArgs^ e )
   {
      // Create a RectangleF structure.
      RectangleF myRectF = RectangleF(100,20,100,100);

      // Draw myRect to the screen.
      Rectangle myRect = Rectangle::Truncate( myRectF );
      e->Graphics->DrawRectangle( Pens::Black, myRect );

      // Create a Size structure.
      SizeF inflateSize = SizeF(100,0);

      // Inflate myRect.
      myRectF.Inflate( inflateSize );

      // Draw the inflated rectangle to the screen.
      myRect = Rectangle::Truncate( myRectF );
      e->Graphics->DrawRectangle( Pens::Red, myRect );
   }