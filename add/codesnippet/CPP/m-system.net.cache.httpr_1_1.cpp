   static WebResponse^ GetResponseUsingDefaultCache( Uri^ uri )
   {
      // Set a cache policy level for the "http:" scheme.
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::Default );

      // Create the request.
      WebRequest^ request = WebRequest::Create( uri );
      request->CachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy {0}.", policy );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }