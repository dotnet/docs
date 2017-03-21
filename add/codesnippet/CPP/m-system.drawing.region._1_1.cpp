public:
   void Complement_Region_Example( PaintEventArgs^ e )
   {
      // Create the first rectangle and draw it to the screen in black.
      Rectangle regionRect = Rectangle(20,20,100,100);
      e->Graphics->DrawRectangle( Pens::Black, regionRect );

      // Create the second rectangle and draw it to the screen in red.
      Rectangle complementRect = Rectangle(90,30,100,100);
      e->Graphics->DrawRectangle( Pens::Red, complementRect );

      // Create a region from the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );

      // Create a complement region.
      System::Drawing::Region^ complementRegion = gcnew System::Drawing::Region( complementRect );

      // Get the complement of myRegion when combined with
      // complementRegion.
      myRegion->Complement( complementRegion );

      // Fill the complement area with blue.
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Blue );
      e->Graphics->FillRegion( myBrush, myRegion );
   }