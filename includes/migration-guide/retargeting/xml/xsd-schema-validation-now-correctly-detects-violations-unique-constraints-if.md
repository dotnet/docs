### XSD Schema validation now correctly detects violations of unique constraints if compound keys are used and one key is empty

|   |   |
|---|---|
|Details|Versions of the .NET Framework prior to 4.6 had a bug that caused XSD validation to not detect unique constraints on compound keys if one of the keys was empty. In the .NET Framework 4.6, this issue is corrected. This will result in more correct validation, but it may also result in some XML not validating which previously would have.|
|Suggestion|If looser .NET Framework 4.0 validation is needed, the validating application can target version 4.5 (or earlier) of the .NET Framework. When retargeting to .NET Framework 4.6, however, code review should be done to be sure that duplicate compound keys (as described in this issue's description) are not expected to validate.|
|Scope|Edge|
|Version|4.6|
|Type|Retargeting|
