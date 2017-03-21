// Get the current DefaultProvider property value.
Console.WriteLine(
	"Current DefaultProvider value: '{0}'",
	webPartsSection.Personalization.DefaultProvider);

// Set the DefaultProvider property.
webPartsSection.Personalization.DefaultProvider = 
	"ASPNetSQLPersonalizationProvider";
// Add a provider.
webPartsSection.Personalization.Providers.Add(
	new ProviderSettings("CustomProvider", 
	"MyCustomProviders.Provider"));

// List current providers.
for (int pi = 0; 
	pi < webPartsSection.Personalization.Providers.Count; pi++)
{
	Console.WriteLine("  #{0} Name={1} Type={2}", pi,
		webPartsSection.Personalization.Providers[pi].Name,
		webPartsSection.Personalization.Providers[pi].Type);
}

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
