---
title: "Database Mirroring in SQL Server"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 89befaff-bb46-4290-8382-e67cdb0e3de9
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Database Mirroring in SQL Server
Database mirroring in SQL Server allows you to keep a copy, or mirror, of a SQL Server database on a standby server. Mirroring ensures that two separate copies of the data exist at all times, providing high availability and complete data redundancy. The .NET Data Provider for SQL Server provides implicit support for database mirroring, so that the developer does not need to take any action or write any code once it has been configured for a SQL Server database. In addition, the <xref:System.Data.SqlClient.SqlConnection> object supports an explicit connection mode that allows supplying the name of a failover partner server in the <xref:System.Data.SqlClient.SqlConnection.ConnectionString%2A>.  
  
 The following simplified sequence of events occurs for a <xref:System.Data.SqlClient.SqlConnection> object that targets a database configured for mirroring:  
  
1.  The client application successfully connects to the principal database, and the server sends back the name of the partner server, which is then cached on the client.  
  
2.  If the server containing the principal database fails or connectivity is interrupted, connection and transaction state is lost. The client application attempts to re-establish a connection to the principal database and fails.  
  
3.  The client application then transparently attempts to establish a connection to the mirror database on the partner server. If it succeeds, the connection is redirected to the mirror database, which then becomes the new principal database.  
  
## Specifying the Failover Partner in the Connection String  
 If you supply the name of a failover partner server in the connection string, the client will transparently attempt a connection with the failover partner if the principal database is unavailable when the client application first connects.  
  
```  
";Failover Partner=PartnerServerName"  
```  
  
 If you omit the name of the failover partner server and the principal database is unavailable when the client application first connects then a <xref:System.Data.SqlClient.SqlException> is raised.  
  
 When a <xref:System.Data.SqlClient.SqlConnection> is successfully opened, the failover partner name is returned by the server and supersedes any values supplied in the connection string.  
  
> [!NOTE]
>  You must explicitly specify the initial catalog or database name in the connection string for database mirroring scenarios. If the client receives failover information on a connection that doesn't have an explicitly specified initial catalog or database, the failover information is not cached and the application does not attempt to fail over if the principal server fails. If a connection string has a value for the failover partner, but no value for the initial catalog or database, an `InvalidArgumentException` is raised.  
  
## Retrieving the Current Server Name  
 In the event of a failover, you can retrieve the name of the server to which the current connection is actually connected by using the <xref:System.Data.SqlClient.SqlConnection.DataSource%2A> property of a <xref:System.Data.SqlClient.SqlConnection> object. The following code fragment retrieves the name of the active server, assuming that the connection variable references an open <xref:System.Data.SqlClient.SqlConnection>.  
  
 When a failover event occurs and the connection is switched to the mirror server, the **DataSource** property is updated to reflect the mirror name.  
  
```vb  
Dim activeServer As String = connection.DataSource  
```  
  
```csharp  
string activeServer = connection.DataSource;  
```  
  
## SqlClient Mirroring Behavior  
 The client always tries to connect to the current principal server. If it fails, it tries the failover partner. If the mirror database has already been switched to the principal role on the partner server, the connection succeeds and the new principal-mirror mapping is sent to the client and cached for the lifetime of the calling <xref:System.AppDomain>. It is not stored in persistent storage and is not available for subsequent connections in a different **AppDomain** or process. However, it is available for subsequent connections within the same **AppDomain**. Note that another **AppDomain** or process running on the same or a different computer always has its pool of connections, and those connections are not reset. In that case, if the primary database goes down, each process or **AppDomain** fails once, and the pool is automatically cleared.  
  
> [!NOTE]
>  Mirroring support on the server is configured on a per-database basis. If data manipulation operations are executed against other databases not included in the principal/mirror set, either by using multipart names or by changing the current database, the changes to these other databases do not propagate in the event of failure. No error is generated when data is modified in a database that is not mirrored. The developer must evaluate the possible impact of such operations.  
  
## Database Mirroring Resources  
 For conceptual documentation and information on configuring, deploying and administering mirroring, see the following resources in SQL Server Books Online.  
  
|Resource|Description|  
|--------------|-----------------|  
|[Database Mirroring](http://msdn.microsoft.com/library/bb934127.aspx) in SQL Server Books Online|Describes how to set up and configure mirroring in SQL Server.|  
  
## See Also  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
