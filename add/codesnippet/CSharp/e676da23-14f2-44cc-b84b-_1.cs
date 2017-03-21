      try {
         Match match = Regex.Match(input, pattern, options,
                                   TimeSpan.FromSeconds(1));
         while (match.Success) {
               // Handle match here...
   
               match = match.NextMatch();
         }  
      }
      catch (RegexMatchTimeoutException) {
         // Do nothing: assume that exception represents no match.
      }