   void SetBrushRemapTableExample( PaintEventArgs^ /*e*/ )
   {
      // Create a color map.
      array<ColorMap^>^myColorMap = gcnew array<ColorMap^>(1);
      myColorMap[ 0 ] = gcnew ColorMap;
      myColorMap[ 0 ]->OldColor = Color::Red;
      myColorMap[ 0 ]->NewColor = Color::Green;

      // Create an ImageAttributes object, passing it to the myColorMap
      // array.
      ImageAttributes^ imageAttr = gcnew ImageAttributes;
      imageAttr->SetBrushRemapTable( myColorMap );
   }