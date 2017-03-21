      Match match = Regex.Match(input, pattern, options);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  