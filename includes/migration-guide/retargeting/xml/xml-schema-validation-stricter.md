### XML schema validation is stricter

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, XML schema validation is more strict. If you use xsd:anyURI to validate a URI such as a mailto protocol, validation fails if there are spaces in the URI. In previous versions of the .NET Framework, validation succeeded. The change affects only applications that target the .NET Framework 4.5.|
|Suggestion|If looser .NET Framework 4.0 validation is needed, the validating application can target version 4.0 of the .NET Framework. When retargeting to .NET Framework 4.5, however, code review should be done to be sure that invalid URIs (with spaces) are not expected as attribute values with the anyURI data type.|
|Scope|Minor|
|Version|4.5|
|Type|Retargeting|
