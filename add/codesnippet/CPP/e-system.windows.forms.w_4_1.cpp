   // Updates the title bar with the current document title.
   void WebBrowser1_DocumentTitleChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->Text = WebBrowser1->DocumentTitle;
   }