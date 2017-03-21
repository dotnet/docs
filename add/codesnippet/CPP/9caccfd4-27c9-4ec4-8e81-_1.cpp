public:
   void TransformPointsPointF( PaintEventArgs^ e )
   {
      // Create array of two points.
      array<PointF>^ points = {PointF(0.0F,0.0F),PointF(100.0F,50.0F)};

      // Draw line connecting two untransformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Blue,3.0f ), points[ 0 ], points[ 1 ] );

      // Set world transformation of Graphics object to translate.
      e->Graphics->TranslateTransform( 40.0F, 30.0F );

      // Transform points in array from world to page coordinates.
      e->Graphics->TransformPoints( CoordinateSpace::Page, CoordinateSpace::World, points );

      // Reset world transformation.
      e->Graphics->ResetTransform();

      // Draw line that connects transformed points.
      e->Graphics->DrawLine( gcnew Pen( Color::Red,3.0f ), points[ 0 ], points[ 1 ] );
   }