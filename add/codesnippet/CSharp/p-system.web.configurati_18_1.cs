// Add an authorization.
AuthorizationRule ar = 
	new AuthorizationRule(AuthorizationRuleAction.Allow);
ar.Verbs.Add("ModifyState");
ar.Users.Add("Admin");
webPartsSection.Personalization.Authorization.Rules.Add(ar);

// List current authorizations.
for (int ai = 0;
	ai < webPartsSection.Personalization.Authorization.Rules.Count; 
	ai++)
{
	Console.WriteLine("  #{0}:", ai);
	AuthorizationRule aRule = 
		webPartsSection.Personalization.Authorization.Rules[ai];
	Console.WriteLine("  Verbs=");
	foreach (string verb in aRule.Verbs)
		Console.WriteLine("    * {0}", verb);
	Console.WriteLine("  Roles=");
	foreach (string role in aRule.Roles)
		Console.WriteLine("    * {0}", role);
	Console.WriteLine("  Users=");
	foreach (string user in aRule.Users)
		Console.WriteLine("    * {0}", user);
}
