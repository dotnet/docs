   static HttpRequestCachePolicy^ CreateLastSyncPolicy( DateTime when )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( when );
      Console::WriteLine( L"When: {0}", when );
      Console::WriteLine( policy->CacheSyncDate );
      return policy;
   }