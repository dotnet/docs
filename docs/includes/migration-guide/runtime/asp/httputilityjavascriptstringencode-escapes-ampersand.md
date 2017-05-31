### HttpUtility.JavaScriptStringEncode escapes ampersand

|   |   |
|---|---|
|Details|Starting with the .NET Framework 4.5, <xref:System.Web.HttpUtility.JavaScriptStringEncode(System.String)?displayProperty=name> escapes the ampersand (&amp;) character.|
|Suggestion|If your app depends on the previous behavior of this method, you can add an aspnet:JavaScriptDoNotEncodeAmpersand setting to the <a href="https://msdn.microsoft.com/en-us/library/hh975440(v=vs.110).aspx">ASP.NET appSettings element</a> in your configuration file.|
|Scope|Minor|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Web.HttpUtility.JavaScriptStringEncode(System.String)?displayProperty=fullName></li><li><xref:System.Web.HttpUtility.JavaScriptStringEncode(System.String%2CSystem.Boolean)?displayProperty=fullName></li></ul>|
|Analyzers|<ul><li>CD0044A</li><li>CD0044B</li></ul>|

