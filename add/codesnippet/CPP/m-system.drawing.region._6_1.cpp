   void TranslateExample( PaintEventArgs^ e )
   {
      // Create the first rectangle and draw it to the screen in blue.
      Rectangle regionRect = Rectangle(100,50,100,100);
      e->Graphics->DrawRectangle( Pens::Blue, regionRect );

      // Create a region using the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );

      // Apply the translation to the region.
      myRegion->Translate( 150, 100 );

      // Fill the transformed region with red and draw it to the screen in red.
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Red );
      e->Graphics->FillRegion( myBrush, myRegion );
   }