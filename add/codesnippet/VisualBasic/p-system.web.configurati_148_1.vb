' Add a provider.
webPartsSection.Personalization.Providers.Add( _
  New ProviderSettings("CustomProvider", _
  "MyCustomProviders.Provider"))

' List current providers.
Dim pi As Integer
For pi = 0 To webPartsSection.Personalization.Providers.Count - 1
  Console.WriteLine("  #{0} Name={1} Type={2}", pi, _
    webPartsSection.Personalization.Providers(pi).Name, _
    webPartsSection.Personalization.Providers(pi).Type)
Next
