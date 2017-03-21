   HttpWebRequest^ request = dynamic_cast<HttpWebRequest^>(WebRequest::Create( args[ 1 ] ));
   request->CookieContainer = gcnew CookieContainer;
   HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());
   response->Cookies = request->CookieContainer->GetCookies( request->RequestUri );
   
   // Print the properties of each cookie.
   System::Collections::IEnumerator^ myEnum = response->Cookies->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      Cookie^ cook = safe_cast<Cookie^>(myEnum->Current);
      Console::WriteLine( "Cookie:" );
      Console::WriteLine( "{0} = {1}", cook->Name, cook->Value );
      Console::WriteLine( "Domain: {0}", cook->Domain );
      Console::WriteLine( "Path: {0}", cook->Path );
      Console::WriteLine( "Port: {0}", cook->Port );
      Console::WriteLine( "Secure: {0}", cook->Secure );
      Console::WriteLine( "When issued: {0}", cook->TimeStamp );
      Console::WriteLine( "Expires: {0} (expired? {1})", cook->Expires, cook->Expired );
      Console::WriteLine( "Don't save: {0}", cook->Discard );
      Console::WriteLine( "Comment: {0}", cook->Comment );
      Console::WriteLine( "Uri for comments: {0}", cook->CommentUri );
      Console::WriteLine( "Version: RFC {0}", cook->Version == 1 ? (String^)"2109" : "2965" );
      
      // Show the string representation of the cookie.
      Console::WriteLine( "String: {0}", cook );
      
   }