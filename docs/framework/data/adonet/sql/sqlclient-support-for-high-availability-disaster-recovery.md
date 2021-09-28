---
title: "SqlClient Support for High Availability, Disaster Recovery"
description: Learn about SqlClient application support for high-availability, disaster recovery in SQL Server, using Always On Availability Groups or Always On Failover Cluster Instances.
ms.date: "03/30/2017"
ms.assetid: 61e0b396-09d7-4e13-9711-7dcbcbd103a0
---
# SqlClient Support for High Availability, Disaster Recovery

This topic discusses SqlClient support (added in .NET Framework 4.5) for high-availability, disaster recovery with the Always On features -- Always On availability groups (AGs) and Always On failover cluster instances (FCIs) with SQL Server 2012 or later.  For more information about either Always On feature, see SQL Server Books Online.  
  
 You can now specify an availability group listener or the name of an FCI in the connection property. If a SqlClient application is connected to a database that fails over, the original connection is broken and the application must open a new connection to continue work after the failover.  
  
 If you are not connecting to an AG or FCI, and if multiple IP addresses are associated with a hostname, SqlClient will iterate sequentially through all IP addresses associated with DNS entry. This can be time consuming if the first IP address returned by DNS server is not bound to any network interface card (NIC). When connecting an FCI, or to the listener of an availability group, SqlClient attempts to establish connections to all IP addresses in parallel and if a connection attempt succeeds, the driver discards any pending connection attempts.  
  
> [!NOTE]
> Increasing connection timeout and implementing connection retry logic will increase the probability that an application will connect to an availability group. Also, because a connection can fail because of a failover, you should implement connection retry logic, retrying a failed connection until it reconnects.  
  
 The following connection properties were added to SqlClient in .NET Framework 4.5:  
  
- `ApplicationIntent`  
  
- `MultiSubnetFailover`  
  
 You can programmatically modify these connection string keywords with:  
  
1. <xref:System.Data.SqlClient.SqlConnectionStringBuilder.ApplicationIntent%2A>  
  
2. <xref:System.Data.SqlClient.SqlConnectionStringBuilder.MultiSubnetFailover%2A>  

> [!NOTE]
> Setting `MultiSubnetFailover` to `true` isn't required with .NET Framework 4.6.1 or later versions.
  
## Connecting With MultiSubnetFailover  

 Always specify `MultiSubnetFailover=True` when connecting to the FCI or the listener of an AG. `MultiSubnetFailover` enables faster failover for all AGs and or FCIs in SQL Server 2012 or later and significantly reduces failover time for single and multi-subnet Always On topologies. During a multi-subnet failover, the client attempts connections in parallel. During a subnet failover, the client aggressively retries the TCP connection.  
  
 The `MultiSubnetFailover` connection property indicates that the application is using either an AG or FCI and that SqlClient will try to connect to the database on the primary SQL Server instance by trying to connect to all the IP addresses. When `MultiSubnetFailover=True` is specified for a connection, the client retries TCP connection attempts faster than the operating system’s default TCP retransmit intervals. This enables faster reconnection after failover of either an AG or FCI, and is applicable to both single- and multi-subnet AGs and FCIs.  
  
 For more information about connection string keywords in SqlClient, see <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A>.  
  
 Specifying `MultiSubnetFailover=True` when connecting to something other than an AG or FCI may result in a negative performance impact, and is not supported.  
  
 Use the following guidelines to connect to a server using one of the Always On features:  
  
- Use the `MultiSubnetFailover` connection property when connecting to a single subnet or multi-subnet; it will improve performance for both.  
  
- To connect to an AG, specify the listener of the availability group as the server in your connection string.  
  
- Connecting to a SQL Server instance configured with more than 64 IP addresses will cause a connection failure.  
  
- Behavior of an application that uses the `MultiSubnetFailover` connection property is not affected based on the type of authentication: SQL Server Authentication, Kerberos Authentication, or Windows Authentication.  
  
- Increase the value of `Connect Timeout` to accommodate for failover time and reduce application connection retry attempts.  
  
- Distributed transactions are not supported.  
  
 If read-only routing is not in effect, connecting to a secondary replica location will fail in the following situations:  
  
1. If the secondary replica location is not configured to accept connections.  
  
2. If an application uses `ApplicationIntent=ReadWrite` (discussed below) and the secondary replica location is configured for read-only access.  
  
 <xref:System.Data.SqlClient.SqlDependency> is not supported on read-only secondary replicas.  
  
 A connection will fail if a primary replica is configured to reject read-only workloads and the connection string contains `ApplicationIntent=ReadOnly`.  
  
## Upgrading to Use Multi-Subnet Clusters from Database Mirroring  

 A connection error (<xref:System.ArgumentException>) will occur if the `MultiSubnetFailover` and `Failover Partner` connection keywords are present in the connection string, or if `MultiSubnetFailover=True` and a protocol other than TCP is used. An error (<xref:System.Data.SqlClient.SqlException>) will also occur if `MultiSubnetFailover` is used and the SQL Server returns a failover partner response indicating it is part of a database mirroring pair.  
  
 If you upgrade a SqlClient application that currently uses database mirroring to a multi-subnet scenario, you should remove the `Failover Partner` connection property and replace it with `MultiSubnetFailover` set to `True` and replace the server name in the connection string with an availability group listener. If a connection string uses `Failover Partner` and `MultiSubnetFailover=True`, the driver will generate an error. However, if a connection string uses `Failover Partner` and `MultiSubnetFailover=False` (or `ApplicationIntent=ReadWrite`), the application will use database mirroring.  
  
 The driver will return an error if database mirroring is used on the primary database in the AG, and if `MultiSubnetFailover=True` is used in the connection string that connects to a primary database instead of to an availability group listener.  
  
## Specifying Application Intent  

 When `ApplicationIntent=ReadOnly`, the client requests a read workload when connecting to an AlwaysOn enabled database. The server will enforce the intent at connection time and during a USE database statement but only to an Always On enabled database.  
  
 The `ApplicationIntent` keyword does not work with legacy, read-only databases.  
  
 A database can allow or disallow read workloads on the targeted AlwaysOn database. (This is done with the `ALLOW_CONNECTIONS` clause of the `PRIMARY_ROLE` and `SECONDARY_ROLE`Transact-SQL statements.)  
  
 The `ApplicationIntent` keyword is used to enable read-only routing.  
  
## Read-Only Routing  

 Read-only routing is a feature that can ensure the availability of a read only replica of a database. To enable read-only routing:  
  
1. You must connect to an Always On Availability Group availability group listener.  
  
2. The `ApplicationIntent` connection string keyword must be set to `ReadOnly`.  
  
3. The Availability Group must be configured by the database administrator to enable read-only routing.  
  
 It is possible that multiple connections using read-only routing will not all connect to the same read-only replica. Changes in database synchronization or changes in the server's routing configuration can result in client connections to different read-only replicas. To ensure that all read-only requests connect to the same read-only replica, do not pass an availability group listener to the `Data Source` connection string keyword. Instead, specify the name of the read-only instance.  
  
 Read-only routing may take longer than connecting to the primary because read only routing first connects to the primary and then looks for the best available readable secondary. Because of this, you should increase your login timeout.  
  
## See also

- [SQL Server Features and ADO.NET](sql-server-features-and-adonet.md)
- [ADO.NET Overview](../ado-net-overview.md)
