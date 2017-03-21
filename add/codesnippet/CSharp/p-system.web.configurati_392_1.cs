            // Using the AuthorizationRuleCollection Add method.
           
            // Set the action property.
            authorizationRule.Action = 
               AuthorizationRuleAction.Allow;
            // Define the new rule to add to the collection.
            authorizationRule.Users.Add("userName");
            authorizationRule.Roles.Add("admin");
            authorizationRule.Verbs.Add("POST");

            // Add the new rule to the collection.
            authorizationSection.Rules.Add(authorizationRule);