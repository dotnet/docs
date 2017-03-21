      Dim match As Match = regex.Match(input)
      Do While match.Success
            ' Handle match here...

            match = match.NextMatch()
      Loop  