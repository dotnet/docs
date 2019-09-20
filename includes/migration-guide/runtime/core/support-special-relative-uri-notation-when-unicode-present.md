### Support special relative URI notation when Unicode is present

|   |   |
|---|---|
|Details|<xref:System.Uri> will no longer throw a <xref:System.NullReferenceException> when calling <xref:System.Uri.TryCreate%2A> on certain relative URIs containing Unicode. The simplest reproduction of the <xref:System.NullReferenceException> is below, with the two statements being equivalent:<pre><code class="lang-csharp">bool success = Uri.TryCreate(&quot;http:%C3%A8&quot;, UriKind.RelativeOrAbsolute, out Uri href);&#13;&#10;bool success = Uri.TryCreate(&quot;http:&#232;&quot;, UriKind.RelativeOrAbsolute, out Uri href);&#13;&#10;</code></pre>To reproduce the <xref:System.NullReferenceException>, the following items must be true:<ul><li>The URI must be specified as relative by prepending it with ‘http:’ and not following it with ‘//’.</li><li>The URI must contain percent-encoded Unicode or unreserved symbols.</li></ul>|
|Suggestion|Users depending on this behavior to disallow relative URIs should instead specify <xref:System.UriKind.Absolute?displayProperty=nameWithType> when creating a URI.|
|Scope|Edge|
|Version|4.7.2|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Uri.TryCreate(System.Uri,System.Uri,System.Uri@)?displayProperty=nameWithType></li><li><xref:System.Uri.TryCreate(System.String,System.UriKind,System.Uri@)?displayProperty=nameWithType></li><li><xref:System.Uri.TryCreate(System.Uri,System.String,System.Uri@)?displayProperty=nameWithType></li></ul>|
