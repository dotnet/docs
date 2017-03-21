          // Add values to the CommaDelimitedStringCollection object.
          myStrCollection.AddRange(
            authorizationRuleCollection.Get(i).Users.ToString().Split(
            ",".ToCharArray()));