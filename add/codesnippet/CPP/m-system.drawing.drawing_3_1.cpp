public:
   void MatrixShearExample( PaintEventArgs^ e )
   {
      Matrix^ myMatrix = gcnew Matrix;
      myMatrix->Shear( 2, 0 );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Green ), 0, 0, 100, 50 );
      e->Graphics->MultiplyTransform( myMatrix );
      e->Graphics->DrawRectangle( gcnew Pen( Color::Red ), 0, 0, 100, 50 );
      e->Graphics->DrawEllipse( gcnew Pen( Color::Blue ), 0, 0, 100, 50 );
   }