   //When the mouse hovers over Button2, its ClientRectangle is filled.
   void Button2_MouseHover( Object^ sender, System::EventArgs^ /*e*/ )
   {
      Control^ senderControl = dynamic_cast<Control^>(sender);
      Rectangle screenRectangle = senderControl->RectangleToScreen( senderControl->ClientRectangle );
      ControlPaint::FillReversibleRectangle( screenRectangle, senderControl->BackColor );
   }

   // When the mouse leaves Button2, its ClientRectangle is cleared by
   // calling the FillReversibleRectangle method again.
   void Button2_MouseLeave( Object^ sender, System::EventArgs^ /*e*/ )
   {
      Control^ senderControl = dynamic_cast<Control^>(sender);
      Rectangle screenRectangle = senderControl->RectangleToScreen( senderControl->ClientRectangle );
      ControlPaint::FillReversibleRectangle( screenRectangle, senderControl->BackColor );
   }