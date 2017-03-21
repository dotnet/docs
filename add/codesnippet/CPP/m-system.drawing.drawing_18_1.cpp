private:
   void CloneExample( PaintEventArgs^ e )
   {
      // Create a LinearGradientBrush.
      int x = 20,y = 20,h = 100,w = 200;
      Rectangle myRect = Rectangle(x,y,w,h);
      LinearGradientBrush^ myLGBrush = gcnew LinearGradientBrush( myRect,Color::Blue,Color::Aquamarine,45.0f,true );

      // Draw an ellipse to the screen using the LinearGradientBrush.
      e->Graphics->FillEllipse( myLGBrush, x, y, w, h );

      // Clone the LinearGradientBrush.
      LinearGradientBrush^ clonedLGBrush = dynamic_cast<LinearGradientBrush^>(myLGBrush->Clone());

      // Justify the left edge of the gradient with the
      // left edge of the ellipse.
      clonedLGBrush->TranslateTransform(  -100.0f, 0.0f );

      // Draw a second ellipse to the screen using the cloned HBrush.
      y = 150;
      e->Graphics->FillEllipse( clonedLGBrush, x, y, w, h );
   }