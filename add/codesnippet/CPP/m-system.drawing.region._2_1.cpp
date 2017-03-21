public:
   void Intersect_RectF_Example( PaintEventArgs^ e )
   {
      // Create the first rectangle and draw it to the screen in black.
      Rectangle regionRect = Rectangle(20,20,100,100);
      e->Graphics->DrawRectangle( Pens::Black, regionRect );

      // create the second rectangle and draw it to the screen in red.
      RectangleF complementRect = RectangleF(90,30,100,100);
      e->Graphics->DrawRectangle( Pens::Red, Rectangle::Round( complementRect ) );

      // Create a region using the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );

      // Get the area of intersection for myRegion when combined with
      // complementRect.
      myRegion->Intersect( complementRect );

      // Fill the intersection area of myRegion with blue.
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Blue );
      e->Graphics->FillRegion( myBrush, myRegion );
   }