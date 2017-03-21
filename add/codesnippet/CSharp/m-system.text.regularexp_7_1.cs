      Match match = regex.Match(input);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  