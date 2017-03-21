private:
   void Button2_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Button2->Width = 100;
      Button2->Text = String::Format( "Color: {0}", Button2->BackColor.Name );
   }