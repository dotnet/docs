   static WebResponse^ GetResponseFromServer( Uri^ uri )
   {
      RequestCachePolicy^ policy = gcnew RequestCachePolicy( RequestCacheLevel::NoCacheNoStore );
      WebRequest^ request = WebRequest::Create( uri );
      request->CachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy is {0}.", policy );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }