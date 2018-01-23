---
title: "OLE DB, ODBC, and Oracle Connection Pooling"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2bd83b1e-3ea9-43c4-bade-d9cdb9bbbb04
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# OLE DB, ODBC, and Oracle Connection Pooling
Pooling connections can significantly enhance the performance and scalability of your application. This section discusses connection pooling for the .NET Framework data providers for OLE DB, ODBC and Oracle.  
  
## Connection Pooling for OleDb  
 The .NET Framework Data Provider for OLE DB automatically pools connections using OLE DB session pooling. Connection string arguments can be used to enable or disable OLE DB services including pooling. For example, the following connection string disables OLE DB session pooling and automatic transaction enlistment.  
  
```  
Provider=SQLOLEDB;OLE DB Services=-4;Data Source=localhost;Integrated Security=SSPI;  
```  
  
 We recommend that you always close or dispose of a connection when you are finished using it in order to return the connection to the pool. Connections that are not explicitly closed may not get returned to the pool. For example, a connection that has gone out of scope but that has not been explicitly closed will only be returned to the connection pool if the maximum pool size has been reached and the connection is still valid.  
  
 For more information about OLE DB session or resource pooling, as well as how to disable pooling by overriding OLE DB provider service defaults, see the [OLE DB Programmer's Guide](http://go.microsoft.com/fwlink/?linkid=45232).  
  
## Connection Pooling for Odbc  
 Connection pooling for the .NET Framework Data Provider for ODBC is managed by the ODBC Driver Manager that is used for the connection, and is not affected by the .NET Framework Data Provider for ODBC.  
  
 To enable or disable connection pooling, open **ODBC Data Source Administrator** in the Administrative Tools folder of Control Panel. The **Connection Pooling** tab allows you to specify connection pooling parameters for each ODBC driver installed. Note that connection pooling changes for a specific ODBC driver affect all applications that use that ODBC driver.  
  
 For more information on ODBC connection pooling, see [INFO: Frequently Asked Questions About ODBC Connection Pooling](http://support.microsoft.com/kb/169470).  
  
## Connection Pooling for OracleClient  
 The .NET Framework Data Provider for Oracle provides connection pooling automatically for your ADO.NET client application. You can also supply several connection string modifiers to control connection pooling behavior (see "Controlling Connection Pooling with Connection String Keywords," later in this topic).  
  
### Pool Creation and Assignment  
 When a connection is opened, a connection pool is created based on an exact matching algorithm that associates the pool with the connection string in the connection. Each connection pool is associated with a distinct connection string. When a new connection is opened, if the connection string is not an exact match to an existing pool, a new pool is created.  
  
 Once created, connection pools are not destroyed until the active process ends. Maintaining inactive or empty pools uses very few system resources.  
  
### Connection Addition  
 A connection pool is created for each unique connection string. When a pool is created, multiple connection objects are created and added to the pool so that the minimum pool size requirement is satisfied. Connections are added to the pool as needed, up to the maximum pool size.  
  
 When an <xref:System.Data.OracleClient.OracleConnection> object is requested, it is obtained from the pool if a usable connection is available. To be usable, the connection must currently be unused, have a matching transaction context or not be associated with any transaction context, and have a valid link to the server.  
  
 If the maximum pool size has been reached and no usable connection is available, the request is queued. The connection pooler satisfies these requests by reallocating connections as they are released back into the pool. Connections are released back into the pool when they are closed or disposed.  
  
### Connection Removal  
 The connection pooler removes a connection from the pool after it has been idle for an extended period of time, or if the pooler detects that the connection with the server has been severed. Note that this can be detected only after attempting to communicate with the server. If a connection is found that is no longer connected to the server, it is marked as invalid. The connection pooler periodically scans connection pools looking for objects that have been released to the pool and are marked as invalid. These connections are then permanently removed.  
  
 If a connection exists to a server that has disappeared, this connection can be drawn from the pool if the connection pooler has not detected the severed connection and marked it as invalid. When this occurs, an exception is generated. However, you must still close the connection in order to release it back into the pool.  
  
 Do not call `Close` or `Dispose` on a `Connection`, a `DataReader`, or any other managed object in the `Finalize` method of your class. In a finalizer, only release unmanaged resources that your class owns directly. If your class does not own any unmanaged resources, do not include a `Finalize` method in your class definition. For more information, see [Garbage Collection](../../../../docs/standard/garbage-collection/index.md).  
  
### Transaction Support  
 Connections are drawn from the pool and assigned based on transaction context. The context of the requesting thread and the assigned connection must match. Therefore, each connection pool is actually subdivided into connections with no transaction context associated with them, and into *N* subdivisions that each contain connections with a particular transaction context.  
  
 When a connection is closed, it is released back into the pool and into the appropriate subdivision based on its transaction context. Therefore, you can close the connection without generating an error, even though a distributed transaction is still pending. This allows you to commit or abort the distributed transaction at a later time.  
  
### Controlling Connection Pooling with Connection String Keywords  
 The <xref:System.Data.OracleClient.OracleConnection.ConnectionString%2A> property of the <xref:System.Data.OracleClient.OracleConnection> object supports connection string key/value pairs that can be used to adjust the behavior of the connection pooling logic.  
  
 The following table describes the <xref:System.Data.OracleClient.OracleConnection.ConnectionString%2A> values you can use to adjust connection pooling behavior.  
  
|Name|Default|Description|  
|----------|-------------|-----------------|  
|`Connection Lifetime`|0|When a connection is returned to the pool, its creation time is compared with the current time, and the connection is destroyed if that time span (in seconds) exceeds the value specified by `Connection Lifetime`. This is useful in clustered configurations to force load balancing between a running server and a server just brought online.<br /><br /> A value of zero (0) will cause pooled connections to have the maximum time-out.|  
|`Enlist`|'true'|When `true`, the pooler automatically enlists the connection in the current transaction context of the creation thread if a transaction context exists.|  
|`Max Pool Size`|100|The maximum number of connections allowed in the pool.|  
|`Min Pool Size`|0|The minimum number of connections maintained in the pool.|  
|`Pooling`|'true'|When `true`, the connection is drawn from the appropriate pool, or if necessary, created and added to the appropriate pool.|  
  
## See Also  
 [Connection Pooling](../../../../docs/framework/data/adonet/connection-pooling.md)  
 [Performance Counters](../../../../docs/framework/data/adonet/performance-counters.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
