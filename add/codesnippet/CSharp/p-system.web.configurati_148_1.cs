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
