// <Snippet1>
using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Configuration;

namespace Samples.Aspnet.SystemWebConfiguration
{
	// Accesses the System.Web.Configuration.WebPartsSection
	// members selected by the user.
	class UsingWebPartsSection
	{
		public static void Main()
		{
			// Process the System.Web.Configuration.WebPartsSectionobject.
			try
			{
				// Get the Web application configuration.
				Configuration configuration = 
					WebConfigurationManager.OpenWebConfiguration("/aspnet");

				// Get the section.
				WebPartsSection webPartsSection = (WebPartsSection) 
					configuration.Sections["system.web/webParts"];
// <Snippet2>
// <Snippet5>
// Add a Transfomer Info Object to the collection using a constructor.
webPartsSection.Transformers.Add(new TransformerInfo(
	"RowToFilterTransformer",
	"MyCustomTransformers.RowToFilterTransformer"));

// </Snippet5>
// <Snippet6>
// Show all TransformerInfo objects in the collection.
for (int ti = 0;
	ti < webPartsSection.Personalization.Providers.Count; ti++)
{
	Console.WriteLine("  #{0} Name={1} Type={2}", ti,
		webPartsSection.Transformers[ti].Name,
		webPartsSection.Transformers[ti].Type);
}

// </Snippet6>
// <Snippet7>
// Remove a TransformerInfo object by name.
webPartsSection.Transformers.Remove("RowToFilterTransformer");

// </Snippet7>
// <Snippet8>
// Remove a TransformerInfo object by index.
webPartsSection.Transformers.RemoveAt(0);

// </Snippet8>
// <Snippet9>
// Clear all TransformerInfo objects from the collection.
webPartsSection.Transformers.Clear();

// </Snippet9>
// </Snippet2>
// <Snippet3>
// <Snippet13>
// Get the current DefaultProvider property value.
Console.WriteLine(
	"Current DefaultProvider value: '{0}'",
	webPartsSection.Personalization.DefaultProvider);

// Set the DefaultProvider property.
webPartsSection.Personalization.DefaultProvider = 
	"ASPNetSQLPersonalizationProvider";
// </Snippet13>
// <Snippet14>
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

// </Snippet14>
// <Snippet15>
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

// </Snippet15>
// </Snippet3>

				// Update if not locked.
				if (! webPartsSection.IsReadOnly())
				{
					configuration.Save();
					Console.WriteLine("** Configuration updated.");
				}
				else
					Console.WriteLine("** Could not update, section is locked.");
			}
			catch (System.ArgumentException e)
			{
				// Unknown error.
				Console.WriteLine(
					"A invalid argument exception detected in UsingWebPartsSection Main. Check your");
				Console.WriteLine("command line for errors.");
			}
		}
	} // UsingWebPartsSection class end.

} // Samples.Aspnet.SystemWebConfiguration namespace end.

// </Snippet1>
