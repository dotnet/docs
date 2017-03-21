public:
   // Deny access to a specific resource by setting the ConnectPattern property.
   [method:WebPermission(SecurityAction::Deny,ConnectPattern="http://www.contoso.com/")]

   void Connect()
   {
      // Create a Connection.
      HttpWebRequest^ myWebRequest = (HttpWebRequest^)(WebRequest::Create( "http://www.contoso.com" ));
      Console::WriteLine( "This line should never be printed" );
   }