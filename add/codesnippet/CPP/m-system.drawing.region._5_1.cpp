public:
   void IsVisible_RectF_Example( PaintEventArgs^ e )
   {
      // Create the first rectangle and draw it to the screen in blue.
      Rectangle regionRect = Rectangle(20,20,100,100);
      e->Graphics->DrawRectangle( Pens::Blue, regionRect );

      // Create the second rectangle and draw it to the screen in red.
      RectangleF myRect = RectangleF(90,30,100,100);
      e->Graphics->DrawRectangle( Pens::Red, Rectangle::Round( myRect ) );

      // Create a region using the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );

      // Determine if myRect is contained in the region.
      bool contained = myRegion->IsVisible( myRect );

      // Display the result.
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( "Arial",8 );
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Black );
      e->Graphics->DrawString( String::Format( "contained = {0}", contained ), myFont, myBrush, PointF(20,140) );
   }