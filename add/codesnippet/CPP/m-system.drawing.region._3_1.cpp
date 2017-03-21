public:
   void Complement_RectF_Example( PaintEventArgs^ e )
   {
      // Create the first rectangle and draw it to the screen in black.
      Rectangle regionRect = Rectangle(20,20,100,100);
      e->Graphics->DrawRectangle( Pens::Black, regionRect );

      // Create the second rectangle and draw it to the screen in red.
      RectangleF complementRect = RectangleF(90,30,100,100);
      e->Graphics->DrawRectangle( Pens::Red, Rectangle::Round( complementRect ) );

      // Create a region using the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );

      // Get the complement of the region combined with the second
      // rectangle.
      myRegion->Complement( complementRect );

      // Fill the complement area with blue.
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Blue );
      e->Graphics->FillRegion( myBrush, myRegion );
   }