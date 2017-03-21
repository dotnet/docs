   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( this->BackColor == SystemColors::ControlDark )
      {
         this->BackColor = SystemColors::Control;
      }
   }