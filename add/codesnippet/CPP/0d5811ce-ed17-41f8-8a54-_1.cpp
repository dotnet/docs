public:
   // Set the declarative security for the URI.
   [WebPermission(SecurityAction::Deny,Connect="http://www.contoso.com/")]
   void Connect()
   {
      // Throw an exception.
      try
      {
         HttpWebRequest^ myWebRequest = dynamic_cast<HttpWebRequest^>(WebRequest::Create( "http://www.contoso.com/" ));
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception : {0}", e );
      }