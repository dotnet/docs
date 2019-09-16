### HttpRuntime.AppDomainAppPath Throws a NullReferenceException

|   |   |
|---|---|
|Details|In the .NET Framework 4.6.2, the runtime throws a <code>T:System.NullReferenceException</code> when retrieving a <code>P:System.Web.HttpRuntime.AppDomainAppPath</code> value that includes null characters.In the .NET Framework 4.6.1 and earlier versions, the runtime throws an <code>T:System.ArgumentNullException</code>.|
|Suggestion|You can do either of the follow to respond to this change:<ul><li>Handle the <code>T:System.NullReferenceException</code> if you application is running on the .NET Framework 4.6.2.</li><li>Upgrade to the .NET Framework 4.7, which restores the previous behavior and throws an <code>T:System.ArgumentNullException</code>.</li></ul>|
|Scope|Edge|
|Version|4.6.2|
|Type|Retargeting|
|Affected APIs|<ul><li><xref:System.Web.HttpRuntime.AppDomainAppPath?displayProperty=nameWithType></li></ul>|
