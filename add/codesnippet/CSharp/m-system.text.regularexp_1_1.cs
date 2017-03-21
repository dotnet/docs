      Match match = regex.Match(input, startAt);
      while (match.Success) {
            // Handle match here...

            match = match.NextMatch();
      }  