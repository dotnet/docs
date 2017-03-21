   static HttpRequestCachePolicy^ CreateMaxStalePolicy( TimeSpan span )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MaxStale,span );
      Console::WriteLine( L"Max stale is {0}", policy->MaxStale );
      return policy;
   }