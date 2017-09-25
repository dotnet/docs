### WebUtility.HtmlDecode no longer decodes invalid input sequences

|   |   |
|---|---|
|Details|By default, decoding methods no longer decode an invalid input sequence into an invalid UTF-16 string. Instead, they return the original input.|
|Suggestion|The change in decoder output should matter only if you store binary data instead of UTF-16 data in strings. To explicitly control this behavior, set the <code>aspnet:AllowRelaxedUnicodeDecoding</code> attribute of the [appSettings](https://msdn.microsoft.com/library/ms228154(v=vs.110).aspx) element to true to enable legacy behavior or to false to enable the current behavior.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Net.WebUtility.HtmlDecode(System.String)?displayProperty=nameWithType></li><li><xref:System.Net.WebUtility.HtmlDecode(System.String%2CSystem.IO.TextWriter)?displayProperty=nameWithType></li><li><xref:System.Net.WebUtility.UrlDecode(System.String)?displayProperty=nameWithType></li></ul>|
|Analyzers|<ul><li>CD0061</li></ul>|

