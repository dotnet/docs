      Try
         Dim match As Match = Regex.Match(input, pattern, options, 
                                          TimeSpan.FromSeconds(1))
         Do While match.Success
               ' Handle match here...
   
               match = match.NextMatch()
         Loop  
      Catch e As RegexMatchTimeoutException
         ' Do nothing: assume that exception represents no match.
      End Try   