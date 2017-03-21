// Get the current DefaultProvider property value.
Console.WriteLine(
	"Current DefaultProvider value: '{0}'",
	webPartsSection.Personalization.DefaultProvider);

// Set the DefaultProvider property.
webPartsSection.Personalization.DefaultProvider = 
	"ASPNetSQLPersonalizationProvider";