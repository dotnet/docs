### MEF catalogs implement IEnumerable and therefore can no longer be used to create a serializer

#### Details

Starting with the .NET Framework 4.5, MEF catalogs implement IEnumerable and therefore can no longer be used to create a serializer (<xref:System.Xml.Serialization.XmlSerializer?displayProperty=fullName> object). Trying to serialize a MEF catalog throws an exception.

#### Suggestion

Can no longer use MEF to create a serializer

| Name    | Value       |
|:--------|:------------|
| Scope   |Major|
|Version|4.5|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
