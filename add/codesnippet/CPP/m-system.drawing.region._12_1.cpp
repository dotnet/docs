private:
   void FillRegionExcludingPath( PaintEventArgs^ e )
   {
      // Create the region using a rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( Rectangle(20,20,100,100) );

      // Create the GraphicsPath.
      System::Drawing::Drawing2D::GraphicsPath^ path = gcnew System::Drawing::Drawing2D::GraphicsPath;

      // Add a circle to the graphics path.
      path->AddEllipse( 50, 50, 25, 25 );

      // Exclude the circle from the region.
      myRegion->Exclude( path );

      // Retrieve a Graphics object from the form.
      Graphics^ formGraphics = e->Graphics;

      // Fill the region in blue.
      formGraphics->FillRegion( Brushes::Blue, myRegion );

      // Dispose of the path and region objects.
      delete path;
      delete myRegion;
   }