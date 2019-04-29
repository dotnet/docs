### System.Uri escaping now supports RFC 3986

|   |   |
|---|---|
|Details|URI escaping has changed in .NET Framework 4.5 to support [RFC 3986](https://tools.ietf.org/html/rfc3986). Specific changes include:<ul><li><xref:System.Uri.EscapeDataString(System.String)?displayProperty=name> escapes reserved characters based on RFC 3986.</li><li><xref:System.Uri.EscapeUriString(System.String)?displayProperty=name> does not escape reserved characters.</li><li><xref:System.Uri.UnescapeDataString(System.String)?displayProperty=name> does not throw an exception if it encounters an invalid escape sequence.</li><li>Unreserved escaped characters are un-escaped.</li></ul>|
|Suggestion|<ul><li>Update applications to not rely on <xref:System.Uri.UnescapeDataString(System.String)?displayProperty=name> to throw in the case of an invalid escape sequence. Such sequences must be detected directly now.</li><li>Similarly, expect that Escaped and Unescaped URI and Data strings may vary from .NET Framework 4.0 and .NET Framework 4.5 and should not be compared across .NET versions directly. Instead, they should be parsed and normalized in a single .NET version before any comparisons are made.</li></ul>|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Uri.EscapeDataString(System.String)?displayProperty=nameWithType></li><li><xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType></li><li><xref:System.Uri.UnescapeDataString(System.String)?displayProperty=nameWithType></li></ul>|
