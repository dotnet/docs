public:
   void BlendConstExample( PaintEventArgs^ e )
   {
      //Draw ellipse using Blend.
      Point startPoint2 = Point(20,110);
      Point endPoint2 = Point(140,110);
      array<Single>^myFactors = {.2f,.4f,.8f,.8f,.4f,.2f};
      array<Single>^myPositions = {0.0f,.2f,.4f,.6f,.8f,1.0f};
      Blend^ myBlend = gcnew Blend;
      myBlend->Factors = myFactors;
      myBlend->Positions = myPositions;
      LinearGradientBrush^ lgBrush2 =
            gcnew LinearGradientBrush( startPoint2,endPoint2,Color::Blue,Color::Red );
      lgBrush2->Blend = myBlend;
      Rectangle ellipseRect2 = Rectangle(20,110,120,80);
      e->Graphics->FillEllipse( lgBrush2, ellipseRect2 );

      // End example.
   }