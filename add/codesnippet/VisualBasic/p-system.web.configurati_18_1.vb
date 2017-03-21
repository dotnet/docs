' Add an authorization.
Dim ar As AuthorizationRule = _
  New AuthorizationRule(AuthorizationRuleAction.Allow)
ar.Verbs.Add("ModifyState")
ar.Users.Add("Admin")
webPartsSection.Personalization.Authorization.Rules.Add(ar)

' List current authorizations.
Dim ai As Integer
For ai = 0 To _
  webPartsSection.Personalization.Authorization.Rules.Count
	Console.WriteLine("  #{0}:", ai)
    Dim aRule As AuthorizationRule = _
      webPartsSection.Personalization.Authorization.Rules(ai)
    Console.WriteLine("  Verbs=")
    Dim verb As String
    For Each verb In aRule.Verbs
      Console.WriteLine("    * {0}", verb)
      Console.WriteLine("  Roles=")
    Next
    Dim role As String
	For Each role In aRule.Roles
      Console.WriteLine("    * {0}", role)
      Console.WriteLine("  Users=")
    Next
    Dim user As String
	For Each user In aRule.Users
      Console.WriteLine("    * {0}", user)
    Next
Next
