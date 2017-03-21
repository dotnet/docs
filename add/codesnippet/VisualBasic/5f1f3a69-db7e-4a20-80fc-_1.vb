      Dim match As Match = Regex.Match(input, pattern, options)
      Do While match.Success
            ' Handle match here...

            match = match.NextMatch()
      Loop  