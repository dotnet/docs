// Add a Transfomer Info Object to the collection using a constructor.
webPartsSection.Transformers.Add(new TransformerInfo(
	"RowToFilterTransformer",
	"MyCustomTransformers.RowToFilterTransformer"));

// Show all TransformerInfo objects in the collection.
for (int ti = 0;
	ti < webPartsSection.Personalization.Providers.Count; ti++)
{
	Console.WriteLine("  #{0} Name={1} Type={2}", ti,
		webPartsSection.Transformers[ti].Name,
		webPartsSection.Transformers[ti].Type);
}

// Remove a TransformerInfo object by name.
webPartsSection.Transformers.Remove("RowToFilterTransformer");

// Remove a TransformerInfo object by index.
webPartsSection.Transformers.RemoveAt(0);

// Clear all TransformerInfo objects from the collection.
webPartsSection.Transformers.Clear();
