   WebProxy_Interface^ webProxy_Interface = gcnew WebProxy_Interface( gcnew Uri( "http://proxy.example.com" ) );

   webProxy_Interface->Credentials = gcnew NetworkCredential( "myusername", "mypassword" );

   Console::WriteLine( "The web proxy is : {0}", webProxy_Interface->GetProxy( gcnew Uri( "http://www.contoso.com" ) ) );

   // Check if the webproxy can ne bypassed for the site "http://www.contoso.com".
   if ( webProxy_Interface->IsBypassed( gcnew Uri( "http://www.contoso.com" ) ) )
   {
      Console::WriteLine( "Web Proxy is by passed" );
   }
   else
   {
      Console::WriteLine( "Web Proxy is not by passed" );
   }