public:
   void TransformPointsPoint( PaintEventArgs^ e )
   {
      // Create array of two points.
      array<Point>^ points = {Point(0,0),Point(100,50)};

      // Draw line connecting two untransformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Blue,3.0f ), points[ 0 ], points[ 1 ] );

      // Set world transformation of Graphics object to translate.
      e->Graphics->TranslateTransform( 40, 30 );

      // Transform points in array from world to page coordinates.
      e->Graphics->TransformPoints( CoordinateSpace::Page, CoordinateSpace::World, points );

      // Reset world transformation.
      e->Graphics->ResetTransform();

      // Draw line that connects transformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Red,3.0f ), points[ 0 ], points[ 1 ] );
   }