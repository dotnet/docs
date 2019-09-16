### System.Uri.IsWellFormedUriString method returns false for relative URIs with a colon char in first segment

|   |   |
|---|---|
|Details|Beginning with the .NET Framework 4.5, <xref:System.Uri.IsWellFormedUriString(System.String,System.UriKind)> will treat relative URIs with a <code>:</code> in their first segment as not well formed. This is a change from <xref:System.Uri.IsWellFormedUriString(System.String,System.UriKind)?displayProperty=name> behavior in the .NET Framework 4.0 that was made to conform to RFC3986.|
|Suggestion|This change (like many other URI changes) will only affect applications targeting the .NET Framework 4.5 (or later). To keep using the old behavior, target the app against the .NET Framework 4.0. Alternatively, scan URI's prior to calling <xref:System.Uri.IsWellFormedUriString(System.String,System.UriKind)?displayProperty=name> looking for <code>:</code> characters that you may want to remove for validation purposes, if the old behavior is desirable.|
|Scope|Minor|
|Version|4.5|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Uri.IsWellFormedUriString(System.String,System.UriKind)?displayProperty=nameWithType></li></ul>|
