private:
   void ShowPensAndSmoothingMode( PaintEventArgs^ e )
   {
      // Set the SmoothingMode property to smooth the line.
      e->Graphics->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::AntiAlias;

      // Create a new Pen object.
      Pen^ greenPen = gcnew Pen( Color::Green );

      // Set the width to 6.
      greenPen->Width = 6.0F;

      // Set the DashCap to round.
      greenPen->DashCap = System::Drawing::Drawing2D::DashCap::Round;

      // Create a custom dash pattern.
      array<Single>^temp0 = {4.0F,2.0F,1.0F,3.0F};
      greenPen->DashPattern = temp0;

      // Draw a line.
      e->Graphics->DrawLine( greenPen, 20.0F, 20.0F, 100.0F, 240.0F );

      // Change the SmoothingMode to none.
      e->Graphics->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::None;

      // Draw another line.
      e->Graphics->DrawLine( greenPen, 100.0F, 240.0F, 160.0F, 20.0F );

      // Dispose of the custom pen.
      delete greenPen;
   }