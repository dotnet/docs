   void Button2_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( this->BackColor != SystemColors::ControlDark )
      {
         this->BackColor = SystemColors::ControlDark;
      }

      if (  !(this->Font->Bold) )
      {
         this->Font = gcnew System::Drawing::Font( this->Font,FontStyle::Bold );
      }
   }