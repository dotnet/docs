// Show all TransformerInfo objects in the collection.
for (int ti = 0;
	ti < webPartsSection.Personalization.Providers.Count; ti++)
{
	Console.WriteLine("  #{0} Name={1} Type={2}", ti,
		webPartsSection.Transformers[ti].Name,
		webPartsSection.Transformers[ti].Type);
}
