---
title: "What's New in ADO.NET"
ms.date: "03/30/2017"
ms.assetid: 3bb65d38-cce2-46f5-b979-e5c505e95e10
---
# What's New in ADO.NET

The following features are new in ADO.NET in the .NET Framework 4.5.

## SqlClient Data Provider

The following features are new in the .NET Framework Data Provider for SQL Server in .NET Framework 4.5:

- The ConnectRetryCount and ConnectRetryInterval connection string keywords (<xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A>) let you control the idle connection resiliency feature.

- Streaming support from SQL Server to an application supports scenarios where data on the server is unstructured.  See [SqlClient Streaming Support](sqlclient-streaming-support.md) for more information.

- Support has been added for asynchronous programming.  See [Asynchronous Programming](asynchronous-programming.md) for more information.

- Connection failures will now be logged in the extended events log. For more information, see [Data Tracing in ADO.NET](data-tracing.md).

- SqlClient now has support for SQL Server's high availability, disaster recovery feature, AlwaysOn. For more information, see [SqlClient Support for High Availability, Disaster Recovery](./sql/sqlclient-support-for-high-availability-disaster-recovery.md).

- A password can be passed as a <xref:System.Security.SecureString> when using SQL Server Authentication. See <xref:System.Data.SqlClient.SqlCredential> for more information.

- When `TrustServerCertificate` is false and `Encrypt` is true, the server name (or IP address) in a SQL Server SSL certificate must exactly match the server name (or IP address) specified in the connection string. Otherwise, the connection attempt will fail. For more information, see the description of the `Encrypt` connection option in <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A>.

  If this change causes an existing application to no longer connect, you can fix the application using one of the following:

  - Issue a certificate that specifies the short name in the Common Name (CN) or Subject Alternative Name (SAN) field. This solution will work for database mirroring.

  - Add an alias that maps the short name to the fully-qualified domain name.

  - Use the fully-qualified domain name in the connection string.

- SqlClient supports Extended Protection. For more information about Extended Protection, see [Connecting to the Database Engine Using Extended Protection](/sql/database-engine/configure-windows/connect-to-the-database-engine-using-extended-protection).

- SqlClient supports connections to LocalDB databases. For more information, see [SqlClient Support for LocalDB](./sql/sqlclient-support-for-localdb.md).

- `Type System Version=SQL Server 2012;` is new value to pass to the `Type System Version` connection property. The `Type System Version=Latest;` value is now obsolete and has been made equivalent to `Type System Version=SQL Server 2008;`. For more information, see <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A>.

- SqlClient provides additional support for sparse columns, a feature that was added in SQL Server 2008. If your application already accesses data in a table that uses sparse columns, you should see an increase in performance. The IsColumnSet column of <xref:System.Data.SqlClient.SqlDataReader.GetSchemaTable%2A> indicates if a column is a sparse column that is a member of a column set. <xref:System.Data.SqlClient.SqlConnection.GetSchema%2A> indicates if a column is a sparse column (see [SQL Server Schema Collections](sql-server-schema-collections.md) for more information). For more information about sparse columns, see [Use Sparse Columns](/sql/relational-databases/tables/use-sparse-columns).

- The assembly Microsoft.SqlServer.Types.dll, which contains the spatial data types, has been upgraded from version 10.0 to version 11.0. Applications that reference this assembly may fail. For more information, see [Breaking Changes to Database Engine Features](https://docs.microsoft.com/previous-versions/sql/sql-server-2012/ms143179(v=sql.110)).

## ADO.NET Entity Framework

The .NET Framework 4.5 adds APIs that enable new scenarios when working with the Entity Framework 5.0. For more information about improvements and features that were added to the Entity Framework 5.0, see the following topics: [What’s New](https://docs.microsoft.com/previous-versions/gg696190(v=vs.103)) and [Entity Framework Releases and Versioning](/ef/ef6/what-is-new/past-releases).

## See also

- [ADO.NET](index.md)
- [ADO.NET Overview](ado-net-overview.md)
- [SQL Server and ADO.NET](./sql/index.md)
- [What's New in WCF Data Services 5.0](https://docs.microsoft.com/previous-versions/dotnet/wcf-data-services/ee373845(v=vs.103))
