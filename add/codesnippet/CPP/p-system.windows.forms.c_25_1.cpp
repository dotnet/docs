   // This method draws a focus rectangle on Button2 using the 
   // handle and client rectangle of Button2.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      ControlPaint::DrawFocusRectangle( Graphics::FromHwnd( Button2->Handle ), Button2->ClientRectangle );
   }