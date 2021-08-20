### ASP.NET Incorrect multipart handling may result in lost form data.

#### Details

In applications that target .NET Framework 4.7.2 and earlier versions, ASP.NET might incorrectly parse multipart boundary values, resulting in form data being unavailable during request execution. Applications that target .NET Framework 4.8 or later versions correctly parse multipart data, so form values are available during request execution.

#### Suggestion

Starting with applications running on .NET Framework 4.8, when targeting .NET Framework 4.8 or later by using the `targetFrameworkVersion` element, the default behavior changes to strip delimiters. When targeting previous framework versions or not using `targetFrameworkVersion`, trailing delimiters for some values are still returned.

This behavior can also be explicitly controlled with an `appSetting`:

<pre><code class="lang-xml">&lt;configuration&gt;&#13;&#10;&lt;appSettings&gt;&#13;&#10;...&#13;&#10;&lt;add key=&quot;aspnet:UseLegacyMultiValueHeaderHandling&quot;  value=&quot;true&quot;/&gt;&#13;&#10;...&#13;&#10;&lt;/appSettings&gt;&#13;&#10;&lt;/configuration&gt;&#13;&#10;</code></pre>

| Name    | Value       |
|:--------|:------------|
| Scope   |Unknown|
|Version|4.8|
|Type|Runtime|

#### Affected APIs

- <xref:System.Web.HttpRequest.Form?displayProperty=nameWithType>
- <xref:System.Web.HttpRequest.Files?displayProperty=nameWithType>
- <xref:System.Web.HttpRequest.ContentEncoding?displayProperty=nameWithType>

<!--

#### Affected APIs

- `P:System.Web.HttpRequest.Form`
- `P:System.Web.HttpRequest.Files`
- `P:System.Web.HttpRequest.ContentEncoding`

-->
