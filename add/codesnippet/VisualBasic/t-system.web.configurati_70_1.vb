      ' Create an authorization rule object.
        Dim action As AuthorizationRuleAction = _
        AuthorizationRuleAction.Deny
        Dim authorizationRule = _
        New System.Web.Configuration.AuthorizationRule(action)