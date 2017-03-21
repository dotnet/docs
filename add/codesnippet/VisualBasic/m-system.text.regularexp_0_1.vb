      Dim match As Match = Regex.Match(input, pattern)
      Do While match.Success
            ' Handle match here...

            match = match.NextMatch()
      Loop  