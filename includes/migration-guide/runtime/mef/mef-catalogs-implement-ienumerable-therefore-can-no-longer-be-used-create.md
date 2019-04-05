### MEF catalogs implement IEnumerable and therefore can no longer be used to create a serializer

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.5, MEF catalogs implement IEnumerable and therefore can no longer be used to create a serializer (<xref:System.Xml.Serialization.XmlSerializer?displayProperty=name> object). Trying to serialize a MEF catalog throws an exception.|
|Suggestion|Can no longer use MEF to create a serializer|
|Scope|Major|
|Version|4.5|
|Type|Runtime|
