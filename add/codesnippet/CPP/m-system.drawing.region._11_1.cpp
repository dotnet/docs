private:
   void FillInfiniteRegion( PaintEventArgs^ e )
   {
      // Create a region from a rectangle.
      Rectangle originalRectangle = Rectangle(40,40,40,50);
      System::Drawing::Region^ smallRegion = gcnew System::Drawing::Region( originalRectangle );

      // Call MakeInfinite.
      smallRegion->MakeInfinite();

      // Fill the region in red and draw the original rectangle
      // in black. Note that the entire form is filled in.
      e->Graphics->FillRegion( Brushes::Red, smallRegion );
      e->Graphics->DrawRectangle( Pens::Black, originalRectangle );
   }