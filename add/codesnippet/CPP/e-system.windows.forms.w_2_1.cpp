   // Updates StatusBar1 with the current browser status text.
   void WebBrowser1_StatusTextChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->StatusBar1->Text = WebBrowser1->StatusText;
   }