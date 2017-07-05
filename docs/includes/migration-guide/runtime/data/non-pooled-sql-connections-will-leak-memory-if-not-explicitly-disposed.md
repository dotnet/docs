### Non-pooled SQL connections will leak memory if not explicitly disposed

|   |   |
|---|---|
|Details|In the .NET Framework 4.5, non-pooled SQL connections which are not explicitly exposed (via Dispose, Close, or using) will leak memory|
|Suggestion|This issue is fixed in a .NET Framework 4.5 servicing update. Please update the .NET Framework 4.5, or upgrade to .NET Framework 4.5.1 or later, to fix this issue. Alternatively, this issue may be avoided by using the <xref:System.Data.SqlClient.SqlConnection?displayProperty=name> in a &#39;using&#39; pattern (which is a best practice) or by explicitly calling Dispose or Close when the connection is no longer needed.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.SqlClient.SqlConnection.%23ctor(System.String)?displayProperty=fullName></li><li><xref:System.Data.SqlClient.SqlConnection.%23ctor(System.String%2CSystem.Data.SqlClient.SqlCredential)?displayProperty=fullName></li></ul>|

