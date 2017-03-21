public:
   void SaveRestore2( PaintEventArgs^ e )
   {
      // Translate transformation matrix.
      e->Graphics->TranslateTransform( 100, 0 );

      // Save translated graphics state.
      GraphicsState^ transState = e->Graphics->Save();

      // Reset transformation matrix to identity and fill rectangle.
      e->Graphics->ResetTransform();
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Red ), 0, 0, 100, 100 );

      // Restore graphics state to translated state and fill second
      // rectangle.
      e->Graphics->Restore( transState );
      e->Graphics->FillRectangle( gcnew SolidBrush( Color::Blue ), 0, 0, 100, 100 );
   }