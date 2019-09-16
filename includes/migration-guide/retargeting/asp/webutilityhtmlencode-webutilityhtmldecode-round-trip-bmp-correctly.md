### WebUtility.HtmlEncode and WebUtility.HtmlDecode round-trip BMP correctly

|   |   |
|---|---|
|Details|For applications that target the .NET Framework 4.5, characters that are outside the Basic Multilingual Plane (BMP) round-trip correctly when they are passed to the <xref:System.Net.WebUtility.HtmlDecode(System.String)> methods.|
|Suggestion|This change should have no effect on current applications, but to restore the original behavior, set the <code>targetFramework</code> attribute of the <code>&lt;httpRuntime&gt;</code> element to a string other than &quot;4.5&quot;. You can also set the <code>unicodeEncodingConformance</code> and <code>unicodeDecodingConformance</code> attributes of the <code>&lt;webUtility&gt;</code> configuration element to control this behavior independently of the targeted version of the .NET Framework.|
|Scope|Edge|
|Version|4.5|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Net.WebUtility.HtmlEncode(System.String)?displayProperty=nameWithType></li><li><xref:System.Net.WebUtility.HtmlEncode(System.String,System.IO.TextWriter)?displayProperty=nameWithType></li></ul>|
