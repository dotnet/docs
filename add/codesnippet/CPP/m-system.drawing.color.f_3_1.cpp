   void FromArgb4( PaintEventArgs^ e )
   {
      Graphics^ g = e->Graphics;

      // Transparent red, green, and blue brushes.
      SolidBrush^ trnsRedBrush = gcnew SolidBrush( Color::FromArgb( 0x78FF0000 ) );
      SolidBrush^ trnsGreenBrush = gcnew SolidBrush( Color::FromArgb( 0x7800FF00 ) );
      SolidBrush^ trnsBlueBrush = gcnew SolidBrush( Color::FromArgb( 0x780000FF ) );

      // Base and height of the triangle that is used to position the
      // circles. Each vertex of the triangle is at the center of one of the
      // 3 circles. The base is equal to the diameter of the circles.
      float triBase = 100;
      float triHeight = (float)Math::Sqrt( 3 * (triBase * triBase) / 4 );

      // coordinates of first circle's bounding rectangle.
      float x1 = 40;
      float y1 = 40;

      // Fill 3 over-lapping circles. Each circle is a different color.
      g->FillEllipse( trnsRedBrush, x1, y1, 2 * triHeight, 2 * triHeight );
      g->FillEllipse( trnsGreenBrush, x1 + triBase / 2, y1 + triHeight, 2 * triHeight, 2 * triHeight );
      g->FillEllipse( trnsBlueBrush, x1 + triBase, y1, 2 * triHeight, 2 * triHeight );
   }