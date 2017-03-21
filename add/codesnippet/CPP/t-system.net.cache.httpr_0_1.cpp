   // The following method demonstrates overriding the
   // caching policy for a request.
   static WebResponse^ GetResponseNoCache( Uri^ uri )
   {
      // Set a default policy level for the "http:" and "https" schemes.
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::Default );
      HttpWebRequest::DefaultCachePolicy = policy;

      // Create the request.
      WebRequest^ request = WebRequest::Create( uri );

      // Define a cache policy for this request only. 
      HttpRequestCachePolicy^ noCachePolicy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::NoCacheNoStore );
      request->CachePolicy = noCachePolicy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"IsFromCache? {0}", response->IsFromCache );
      
      return response;
   }