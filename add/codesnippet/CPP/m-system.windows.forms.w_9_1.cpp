   // Halts the current navigation and any sounds or animations on 
   // the page.
   void ButtonStop_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->Stop();
   }