---
title: "Mitigation: Pool Blocking Period"
ms.date: "03/30/2017"
ms.assetid: 92d2de20-79be-4df1-b182-144143a8866a
---
# Mitigation: Pool Blocking Period
The connection pool blocking period has been removed for connections to Azure SQL databases.  
  
## Additional description  
 In the .NET Framework 4.6.1 and earlier versions, when an app encounters a transient connection failure when connecting to a database, the connection attempt cannot be retried quickly, because the connection pool caches the error and re-throws it for 5 seconds to 1 min. For more information, see [SQL Server Connection Pooling (ADO.NET)](../data/adonet/sql-server-connection-pooling.md). This behavior is problematic for connections to Azure SQL databases, which often fail with transient errors that are typically recovered from within a few seconds. The connection pool blocking feature means that the app cannot connect to the database for an extensive period, even though the database is available. This behavior is particularly problematic for web apps that connect to Azure SQL databases and that need to render within a few seconds.  
  
 Starting with the .NET Framework 4.6.2, for connection open requests to known Azure SQL databases (*.database.windows.net, \*.database.chinacloudapi.cn, \*.database.usgovcloudapi.net, \*.database.cloudapi.de), connection open errors are not cached. For all other connection attempts, the connection pool blocking period continues to be enforced.  
  
## Impact  
 This change allows the connection open attempt to be retried immediately for Azure SQL databases, thereby improving the performance of cloud-enabled apps.  
  
## Mitigation  
 For apps that are adversely affected by this change, the connection pool blocking period can be configured by setting the new <xref:System.Data.SqlClient.SqlConnectionStringBuilder.PoolBlockingPeriod%2A?displayProperty=nameWithType> property.  The value of the property is a member of the <xref:System.Data.SqlClient.PoolBlockingPeriod?displayProperty=nameWithType> enumeration that can take either of three values:  
  
- <xref:System.Data.SqlClient.PoolBlockingPeriod.AlwaysBlock?displayProperty=nameWithType>
  
- <xref:System.Data.SqlClient.PoolBlockingPeriod.Auto?displayProperty=nameWithType>
  
- <xref:System.Data.SqlClient.PoolBlockingPeriod.NeverBlock?displayProperty=nameWithType>
  
 The previous behavior can be restored by setting the <xref:System.Data.SqlClient.SqlConnectionStringBuilder.PoolBlockingPeriod%2A> property to <xref:System.Data.SqlClient.PoolBlockingPeriod.AlwaysBlock?displayProperty=nameWithType>.  
  
## See also

- [Application compatibility](application-compatibility.md)
