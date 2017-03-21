      Match match = Regex.Match(input, pattern);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  