public:
   void TransformExample( PaintEventArgs^ e )
   {
      
      // Create the first rectangle and draw it to the screen in blue.
      Rectangle regionRect = Rectangle(100,50,100,100);
      e->Graphics->DrawRectangle( Pens::Blue, regionRect );
      
      // Create a region using the first rectangle.
      System::Drawing::Region^ myRegion = gcnew System::Drawing::Region( regionRect );
      
      // Create a transform matrix and set it to have a 45 degree
      // rotation.
      Matrix^ transformMatrix = gcnew Matrix;
      transformMatrix->RotateAt( 45, Point(100,50) );
      
      // Apply the transform to the region.
      myRegion->Transform(transformMatrix);
      
      // Fill the transformed region with red and draw it to the screen
      // in red.
      SolidBrush^ myBrush = gcnew SolidBrush( Color::Red );
      e->Graphics->FillRegion( myBrush, myRegion );
   }