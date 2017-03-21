   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Draws a flat button on button1.
      ControlPaint::DrawButton( System::Drawing::Graphics::FromHwnd( button1->Handle ), 0, 0, button1->Width, button1->Height, ButtonState::Flat );
   }
