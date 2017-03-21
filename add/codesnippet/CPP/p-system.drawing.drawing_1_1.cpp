private:
   void DemonstrateBlend( PaintEventArgs^ e )
   {
      Blend^ blend1 = gcnew Blend( 9 );

      // Set the values in the Factors array to be all green, 
      // go to all blue, and then go back to green.
      array<Single>^temp0 = {0.0F,0.2F,0.5F,0.7F,1.0F,0.7F,0.5F,0.2F,0.0F};
      blend1->Factors = temp0;

      // Set the positions.
      array<Single>^temp1 = {0.0F,0.1F,0.3F,0.4F,0.5F,0.6F,0.7F,0.8F,1.0F};
      blend1->Positions = temp1;

      // Declare a rectangle to draw the Blend in.
      Rectangle rectangle1 = Rectangle(10,10,120,100);

      // Create a new LinearGradientBrush using the rectangle, 
      // green and blue. and 90-degree angle.
      LinearGradientBrush^ brush1 = gcnew LinearGradientBrush( rectangle1,Color::LightGreen,Color::Blue,90,true );

      // Set the Blend property on the brush to the custom blend.
      brush1->Blend = blend1;

      // Fill in an ellipse with the brush.
      e->Graphics->FillEllipse( brush1, rectangle1 );

      // Dispose of the custom brush.
      delete brush1;
   }