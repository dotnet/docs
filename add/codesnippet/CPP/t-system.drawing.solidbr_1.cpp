private:
   void AddShadow( PaintEventArgs^ e )
   {
      // Create two SizeF objects.
      SizeF shadowSize = listBox1->Size;
      SizeF addSize = SizeF(10.5F,20.8F);

      // Add them together and save the result in shadowSize.
      shadowSize = shadowSize + addSize;

      // Get the location of the ListBox and convert it to a PointF.
      PointF shadowLocation = listBox1->Location;

      // Add two points to get a new location.
      shadowLocation = shadowLocation + System::Drawing::Size( 5, 5 );

      // Create a rectangleF. 
      RectangleF rectFToFill = RectangleF(shadowLocation,shadowSize);

      // Create a custom brush using a semi-transparent color, and 
      // then fill in the rectangle.
      Color customColor = Color::FromArgb( 50, Color::Gray );
      SolidBrush^ shadowBrush = gcnew SolidBrush( customColor );
      array<RectangleF>^ temp0 = {rectFToFill};
      e->Graphics->FillRectangles( shadowBrush, temp0 );

      // Dispose of the brush.
      delete shadowBrush;
   }