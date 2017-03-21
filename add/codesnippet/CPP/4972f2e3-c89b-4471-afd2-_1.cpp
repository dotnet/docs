   // Authenticate is the core method for this custom authentication.
   // When an internet resource requests authentication, the WebRequest::GetResponse
   // method calls the AuthenticationManager::Authenticate method. This method, in
   // turn, calls the Authenticate method on each of the registered authentication
   // modules, in the order they were registered. When the authentication is
   // complete an Authorization object is returned to the WebRequest, as
   // shown by this routine's retun type.
   virtual Authorization^ Authenticate( String^ challenge, WebRequest^ request, ICredentials^ credentials )
   {
      Encoding^ ASCII = Encoding::ASCII;
      
      // Get the username and password from the credentials
      NetworkCredential^ MyCreds = credentials->GetCredential( request->RequestUri, "Basic" );
      if ( PreAuthenticate( request, credentials ) == nullptr )
            Console::WriteLine( "\n Pre-authentication is not allowed." );
      else
            Console::WriteLine( "\n Pre-authentication is allowed." );

      
      // Verify that the challenge satisfies the authorization requirements.
      bool challengeOk = checkChallenge( challenge, MyCreds->Domain );
      if (  !challengeOk )
            return nullptr;

      
      // Create the encrypted string according to the Basic authentication format as
      // follows:
      // a)Concatenate username and password separated by colon;
      // b)Apply ASCII encoding to obtain a stream of bytes;
      // c)Apply Base64 Encoding to this array of bytes to obtain the encoded
      // authorization.
      String^ BasicEncrypt = String::Concat( MyCreds->UserName, ":", MyCreds->Password );
      String^ BasicToken = String::Concat( "Basic ", Convert::ToBase64String( ASCII->GetBytes( BasicEncrypt ) ) );
      
      // Create an Authorization object using the above encoded authorization.
      Authorization^ resourceAuthorization = gcnew Authorization( BasicToken );
      
      // Get the Message property which contains the authorization string that the
      // client returns to the server when accessing protected resources
      Console::WriteLine( "\n Authorization Message: {0}", resourceAuthorization->Message );
      
      // Get the Complete property which is set to true when the authentication process
      // between the client and the server is finished.
      Console::WriteLine( "\n Authorization Complete: {0}", resourceAuthorization->Complete );
      
      Console::WriteLine( "\n Authorization ConnectionGroupId: {0}", resourceAuthorization->ConnectionGroupId );
      return resourceAuthorization;
   }
