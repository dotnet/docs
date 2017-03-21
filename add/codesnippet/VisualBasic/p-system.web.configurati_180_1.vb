' Show all TransformerInfo objects in the collection.
Dim ti As Integer
For ti = 0 To webPartsSection.Personalization.Providers.Count - 1
  Console.WriteLine("  #{0} Name={1} Type={2}", ti, _
    webPartsSection.Transformers(ti).Name, _
    webPartsSection.Transformers(ti).Type)
Next
