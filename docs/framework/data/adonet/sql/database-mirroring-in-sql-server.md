---
description: "Learn more about database mirroring, which allows you to keep a copy, or mirror, of a SQL Server database on a standby server."
title: "Database Mirroring in SQL Server"
ms.date: "10/23/2026"
dev_langs:
  - "csharp"
  - "vb"
ms.custom: sfi-ropc-nochange
---
# Database mirroring in SQL Server

Database mirroring in SQL Server lets you keep a copy, or mirror, of a SQL Server database on a standby server. Mirroring ensures that two separate copies of the data exist at all times, providing high availability and complete data redundancy. After you configure database mirroring for a SQL Server database, Microsoft.Data.SqlClient supports it without additional client code. You can also specify a failover partner server in the <xref:Microsoft.Data.SqlClient.SqlConnection.ConnectionString> property.

The following sequence of events occurs when the <xref:Microsoft.Data.SqlClient.SqlConnection> object targets a database configured for mirroring:

1. The client application successfully connects to the principal database, and the server sends back the name of the partner server, which is then cached on the client.

2. If the server containing the principal database fails or connectivity is interrupted, connection and transaction state is lost. The client application attempts to re-establish a connection to the principal database and fails.

3. The client application then transparently attempts to establish a connection to the mirror database on the partner server. If it succeeds, the connection is redirected to the mirror database, which then becomes the new principal database.

## Specifying the Failover Partner in the Connection String

 If you supply the name of a failover partner server in the connection string, the client will transparently attempt a connection with the failover partner if the principal database is unavailable when the client application first connects.

```csharp
";Failover Partner=PartnerServerName"
```

If you omit the failover partner server name and the principal database is unavailable when the client application first connects, the provider throws <xref:Microsoft.Data.SqlClient.SqlException>.

When the <xref:Microsoft.Data.SqlClient.SqlConnection> opens successfully, the server returns the failover partner name. That name supersedes the value in the connection string.

> [!NOTE]
> You must explicitly specify the initial catalog or database name in the connection string for database mirroring scenarios. If the client receives failover information on a connection that doesn't have an explicitly specified initial catalog or database, the failover information is not cached and the application does not attempt to fail over if the principal server fails. If a connection string has a value for the failover partner, but no value for the initial catalog or database, an `InvalidArgumentException` is raised.

## Retrieving the Current Server Name

After a failover, use the <xref:Microsoft.Data.SqlClient.SqlConnection.DataSource> property to retrieve the connected server's name. The following code fragment assumes that the connection variable references an open instance of the <xref:Microsoft.Data.SqlClient.SqlConnection> class.

 When a failover event occurs and the connection is switched to the mirror server, the `DataSource` property is updated to reflect the mirror name.

```vb
Dim activeServer As String = connection.DataSource
```

```csharp
string activeServer = connection.DataSource;
```

## SqlClient Mirroring Behavior

 The client always tries to connect to the current principal server. If it fails, it tries the failover partner. If the mirror database has already been switched to the principal role on the partner server, the connection succeeds and the new principal-mirror mapping is sent to the client and cached for the lifetime of the calling <xref:System.AppDomain>. It is not stored in persistent storage and is not available for subsequent connections in a different `AppDomain` or process. However, it is available for subsequent connections within the same `AppDomain`. Note that another `AppDomain` or process running on the same or a different computer always has its pool of connections, and those connections are not reset. In that case, if the primary database goes down, each process or `AppDomain` fails once, and the pool is automatically cleared.

> [!NOTE]
> Mirroring support on the server is configured on a per-database basis. If data manipulation operations are executed against other databases not included in the principal/mirror set, either by using multipart names or by changing the current database, the changes to these other databases do not propagate in the event of failure. No error is generated when data is modified in a database that is not mirrored. The developer must evaluate the possible impact of such operations.

## Database Mirroring Resources

 For conceptual documentation and information on configuring, deploying and administering mirroring, see the following resources in SQL Server documentation.

|Resource|Description|
|--------------|-----------------|
|[Database Mirroring](/sql/database-engine/database-mirroring/database-mirroring-sql-server)|Describes how to set up and configure mirroring in SQL Server.|

## See also

- [ADO.NET Overview](../ado-net-overview.md)
