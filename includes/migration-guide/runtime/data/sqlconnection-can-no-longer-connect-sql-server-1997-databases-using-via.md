### SqlConnection can no longer connect to SQL Server 1997 or databases using the VIA adapter

|   |   |
|---|---|
|Details|Connections to SQL Server databases using the [Virtual Interface Adapter (VIA) protocol](https://docs.microsoft.com/previous-versions/sql/sql-server-2008-r2/ms191229%28v=sql.105%29) are no longer supported. The protocol used to connect to a SQL Server database is visible in the connection string. A VIA connection will contain via:&lt;servername&gt;. If this app is connecting to SQL via a protocol other than VIA (tcp: or np: for example), then no breaking change will be encountered.Also, connections to SQL Server 7 (1997) are no longer supported.|
|Suggestion|The VIA protocol is deprecated, so an alternative protocol should be used to connect to SQL databases. The most common protocol used is TCP/IP. For more information about connecting through TCP/IP, see [Enable the TCP/IP protocol for a database instance](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/bb909712(v=vs.90)). If the database is only accessed from within an intranet, the shared pipes protocol may provide better performance if the network is slow.|
|Scope|Edge|
|Version|4.5|
|Type|Runtime|
|Affected APIs|<ul><li><xref:System.Data.SqlClient.SqlConnection.%23ctor(System.String)?displayProperty=nameWithType></li><li><xref:System.Data.SqlClient.SqlConnection.%23ctor(System.String,System.Data.SqlClient.SqlCredential)?displayProperty=nameWithType></li></ul>|

