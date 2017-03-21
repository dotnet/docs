' Add a Transfomer Info Object to the collection using a constructor.
webPartsSection.Transformers.Add(New TransformerInfo( _
  "RowToFilterTransformer", _
  "MyCustomTransformers.RowToFilterTransformer"))

' Show all TransformerInfo objects in the collection.
Dim ti As Integer
For ti = 0 To webPartsSection.Personalization.Providers.Count - 1
  Console.WriteLine("  #{0} Name={1} Type={2}", ti, _
    webPartsSection.Transformers(ti).Name, _
    webPartsSection.Transformers(ti).Type)
Next

' Remove a TransformerInfo object by name.
webPartsSection.Transformers.Remove("RowToFilterTransformer")

' Remove a TransformerInfo object by index.
webPartsSection.Transformers.RemoveAt(0)

' Clear all TransformerInfo objects from the collection.
webPartsSection.Transformers.Clear()
