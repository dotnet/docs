### Attempting a TCP/IP connection to a SQL Server database that resolves to `localhost` fails

#### Details

In the .NET Framework 4.6 and 4.6.1, attempting a TCP/IP connection to a SQL Server database that resolves to `localhost` fails with the error, &quot;A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: SQL Network Interfaces, error: 26 - Error Locating Server/Instance Specified)&quot;

#### Suggestion

This issue has been addressed and the previous behavior restored in the .NET Framework 4.6.2. To connect to a SQL Server database that resolves to `localhost`, upgrade to the .NET Framework 4.6.2.

| Name    | Value       |
|:--------|:------------|
| Scope   |Minor|
|Version|4.6|
|Type|Runtime|

#### Affected APIs

Not detectable via API analysis.

<!--

#### Affected APIs

Not detectable via API analysis.

-->
