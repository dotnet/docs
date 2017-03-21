   static HttpRequestCachePolicy^ CreateCacheIfAvailablePolicy()
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpRequestCacheLevel::CacheIfAvailable );
      Console::WriteLine( policy );
      return policy;
   }