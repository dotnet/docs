' Get the current DefaultProvider property value.
Console.WriteLine( _
  "Current DefaultProvider value: '{0}'", _
  webPartsSection.Personalization.DefaultProvider)

' Set the DefaultProvider property.
webPartsSection.Personalization.DefaultProvider = _
  "ASPNetSQLPersonalizationProvider"