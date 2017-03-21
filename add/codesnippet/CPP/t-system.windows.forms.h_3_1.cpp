private:
   void webBrowser1_DocumentCompleted( Object^ /*sender*/, System::Windows::Forms::WebBrowserDocumentCompletedEventArgs^ /*e*/ )
   {
      WebBrowser1->Document->MouseDown += gcnew HtmlElementEventHandler( this, &Form1::Document_MouseDown );
      WebBrowser1->Document->MouseMove += gcnew HtmlElementEventHandler( this, &Form1::Document_MouseMove );
      WebBrowser1->Document->MouseUp += gcnew HtmlElementEventHandler( this, &Form1::Document_MouseUp );
   }

   void Document_MouseDown( Object^ /*sender*/, HtmlElementEventArgs^ /*e*/ )
   {
      // Insert your code here.
   }

   void Document_MouseMove( Object^ /*sender*/, HtmlElementEventArgs^ /*e*/ )
   {
      // Insert your code here.
   }

   void Document_MouseUp( Object^ /*sender*/, HtmlElementEventArgs^ /*e*/ )
   {
      // Insert your code here.
   }