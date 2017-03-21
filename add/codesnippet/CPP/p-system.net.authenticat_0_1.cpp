   static void RequestResource( Uri^ resource )
   {
      // Set policy to send credentials when using HTTPS and basic authentication.
      // Create a new HttpWebRequest object for the specified resource.
      WebRequest^ request = dynamic_cast<WebRequest^>(WebRequest::Create( resource ));

      // Supply client credentials for basic authentication.
      request->UseDefaultCredentials = true;
      request->AuthenticationLevel = AuthenticationLevel::MutualAuthRequired;
      HttpWebResponse^ response = dynamic_cast<HttpWebResponse^>(request->GetResponse());

      // Determine mutual authentication was used.
      Console::WriteLine( L"Is mutually authenticated? {0}", response->IsMutuallyAuthenticated );
      System::Collections::Specialized::StringDictionary^ spnDictionary = AuthenticationManager::CustomTargetNameDictionary;
      System::Collections::IEnumerator^ myEnum = spnDictionary->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DictionaryEntry^ e = safe_cast<DictionaryEntry^>(myEnum->Current);
         Console::WriteLine( "Key: {0}  - {1}", dynamic_cast<String^>(e->Key), dynamic_cast<String^>(e->Value) );
      }

      // Read and display the response.
      System::IO::Stream^ streamResponse = response->GetResponseStream();
      System::IO::StreamReader^ streamRead = gcnew System::IO::StreamReader( streamResponse );
      String^ responseString = streamRead->ReadToEnd();
      Console::WriteLine( responseString );

      // Close the stream objects.
      streamResponse->Close();
      streamRead->Close();

      // Release the HttpWebResponse.
      response->Close();
   }

   /*
   
   The output from this example will differ based on the requested resource
   and whether mutual authentication was successful. For the purpose of illustration,
   a sample of the output is shown here:
   
   Is mutually authenticated? True
   Key: http://server1.someDomain.contoso.com  - HTTP/server1.someDomain.contoso.com
   
   <html>
   ...
   </html>
   
   */