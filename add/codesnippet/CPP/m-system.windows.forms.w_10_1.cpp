   // Reloads the current page.
   void ButtonRefresh_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Skip refresh if about:blank is loaded to avoid removing
      // content specified by the DocumentText property.
      if (  !this->WebBrowser1->Url->Equals( "about:blank" ) )
      {
         this->WebBrowser1->Refresh();
      }
   }