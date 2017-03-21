   static HttpRequestCachePolicy^ CreateFreshAndAgePolicy( TimeSpan freshMinimum, TimeSpan ageMaximum )
   {
      HttpRequestCachePolicy^ policy = gcnew HttpRequestCachePolicy( HttpCacheAgeControl::MaxAgeAndMinFresh,
          ageMaximum, freshMinimum );
      Console::WriteLine( policy );
      return policy;
   }