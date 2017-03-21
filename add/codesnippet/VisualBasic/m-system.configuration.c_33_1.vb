          ' Add values to the CommaDelimitedStringCollection object.
          myStrCollection.AddRange( _
            authorizationRuleCollection.Get(i).Users.ToString().Split( _
            ",".ToCharArray()))