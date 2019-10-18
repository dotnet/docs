### The Replace method in OData URLs is disabled by default

|   |   |
|---|---|
|Details|Beginning in the .NET Framework 4.5, the Replace method in OData URLs is disabled by default. When OData Replace is disabled (now by default), any user requests including replace functions (which are uncommon) will fail.|
|Suggestion|If the replace method is required (which is uncommon), it can be re-enabled through a config settings (<xref:System.Data.Services.Configuration.DataServicesFeaturesSection.ReplaceFunction?displayProperty=name>). However, an enabled replace method can open security vulnerabilities and should only be used after careful review.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.Services.DataService%601?displayProperty=nameWithType></li></ul>|
