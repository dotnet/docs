   static HttpRequestCachePolicy^ CreateMaxAgePolicy( TimeSpan span )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MaxAge,span );
      Console::WriteLine( L"Max age is {0}", policy->MaxAge );
      return policy;
   }