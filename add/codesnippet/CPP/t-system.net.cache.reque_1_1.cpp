   static WebResponse^ GetResponseFromCache( Uri^ uri )
   {
      RequestCachePolicy^ policy = gcnew RequestCachePolicy( RequestCacheLevel::CacheOnly );
      WebRequest^ request = WebRequest::Create( uri );
      request->CachePolicy = policy;
      WebResponse^ response = request->GetResponse();
      Console::WriteLine( L"Policy level is {0}.", policy->Level );
      Console::WriteLine( L"Is the response from the cache? {0}", response->IsFromCache );
      return response;
   }