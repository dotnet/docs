   static HttpRequestCachePolicy^ CreateMinFreshPolicy( TimeSpan span )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MinFresh,span );
      Console::WriteLine( L"Minimum freshness {0}", policy->MinFresh );
      return policy;
   }