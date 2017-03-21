protected:
   virtual void OnPaint( PaintEventArgs^ e ) override
   {
      //Draw ellipse using ColorBlend.
      Point startPoint2 = Point(20,110);
      Point endPoint2 = Point(140,110);
      array<Color>^ myColors =
            {Color::Green,Color::Yellow,Color::Yellow,Color::Blue,Color::Red,Color::Red};
      array<Single>^myPositions = {0.0f,.20f,.40f,.60f,.80f,1.0f};
      ColorBlend^ myBlend = gcnew ColorBlend;
      myBlend->Colors = myColors;
      myBlend->Positions = myPositions;
      LinearGradientBrush^ lgBrush2 =
            gcnew LinearGradientBrush( startPoint2,endPoint2,Color::Green,Color::Red );
      lgBrush2->InterpolationColors = myBlend;
      Rectangle ellipseRect2 = Rectangle(20,110,120,80);
      e->Graphics->FillEllipse( lgBrush2, ellipseRect2 );
   }