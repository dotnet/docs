### HttpRequest.ContentEncoding property prohibits UTF7

|   |   |
|---|---|
|Details|Beginning in .NET Framework 4.5, UTF-7 encoding is prohibited in <xref:System.Web.HttpRequest?displayProperty=name>s&#39; bodies. Data for applications that depend on incoming UTF-7 data will not decode properly in some cases.|
|Suggestion|Ideally, applications should be updated to not use UTF-7 encoding in <xref:System.Web.HttpRequest?displayProperty=name>s. Alternatively, legacy behavior can be restored by using the <code>aspnet:AllowUtf7RequestContentEncoding</code> attribute of the <a href="https://msdn.microsoft.com/en-us/library/hh975440(v=vs.110).aspx">appSettings</a> element.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Web.HttpRequest.ContentEncoding?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0043</li></ul>|

