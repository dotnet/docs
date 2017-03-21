   // The following example uses the System, System.Net, 
   // and System.IO namespaces.
   static void RequestMutualAuth( Uri^ resource )
   {
      // Create a new HttpWebRequest object for the specified resource.
      WebRequest^ request = dynamic_cast<WebRequest^>(WebRequest::Create( resource ));

      // Request mutual authentication.
      request->AuthenticationLevel = AuthenticationLevel::MutualAuthRequested;

      // Supply client credentials.
      request->Credentials = CredentialCache::DefaultCredentials;
      HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());

      // Determine whether mutual authentication was used.
      Console::WriteLine( L"Is mutually authenticated? {0}", response->IsMutuallyAuthenticated );

      // Read and display the response.
      Stream^ streamResponse = response->GetResponseStream();
      StreamReader^ streamRead = gcnew StreamReader( streamResponse );
      String^ responseString = streamRead->ReadToEnd();
      Console::WriteLine( responseString );

      // Close the stream objects.
      streamResponse->Close();
      streamRead->Close();

      // Release the HttpWebResponse.
      response->Close();
   }