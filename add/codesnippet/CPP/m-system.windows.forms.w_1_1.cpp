   // Prints the current document using the current print settings.
   void ButtonPrint_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->WebBrowser1->Print();
   }