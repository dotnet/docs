---
title: "Enabling Multiple Active Result Sets"
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
ms.assetid: 576079e4-debe-4ab5-9204-fcbe2ca7a5e2
caps.latest.revision: 6
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Enabling Multiple Active Result Sets
Multiple Active Result Sets (MARS) is a feature that works with SQL Server to allow the execution of multiple batches on a single connection. When MARS is enabled for use with SQL Server, each command object used adds a session to the connection.  
  
> [!NOTE]
>  A single MARS session opens one logical connection for MARS to use and then one logical connection for each active command.  
  
## Enabling and Disabling MARS in the Connection String  
  
> [!NOTE]
>  The following connection strings use the sample **AdventureWorks** database included with SQL Server. The connection strings provided assume that the database is installed on a server named MSSQL1. Modify the connection string as necessary for your environment.  
  
 The MARS feature is disabled by default. It can be enabled by adding the "MultipleActiveResultSets=True" keyword pair to your connection string. "True" is the only valid value for enabling MARS. The following example demonstrates how to connect to an instance of SQL Server and how to specify that MARS should be enabled.  
  
```vb  
Dim connectionString As String = "Data Source=MSSQL1;" & _  
    "Initial Catalog=AdventureWorks;Integrated Security=SSPI;" & _  
    "MultipleActiveResultSets=True"  
```  
  
```csharp  
string connectionString = "Data Source=MSSQL1;" +   
    "Initial Catalog=AdventureWorks;Integrated Security=SSPI;" +  
    "MultipleActiveResultSets=True";  
```  
  
 You can disable MARS by adding the "MultipleActiveResultSets=False" keyword pair to your connection string. "False" is the only valid value for disabling MARS. The following connection string demonstrates how to disable MARS.  
  
```vb  
Dim connectionString As String = "Data Source=MSSQL1;" & _  
    "Initial Catalog=AdventureWorks;Integrated Security=SSPI;" & _  
    "MultipleActiveResultSets=False"  
```  
  
```csharp  
string connectionString = "Data Source=MSSQL1;" +   
    "Initial Catalog=AdventureWorks;Integrated Security=SSPI;" +  
    "MultipleActiveResultSets=False";  
```  
  
## Special Considerations When Using MARS  
 In general, existing applications should not need modification to use a MARS-enabled connection. However, if you wish to use MARS features in your applications, you should understand the following special considerations.  
  
### Statement Interleaving  
 MARS operations execute synchronously on the server. Statement interleaving of SELECT and BULK INSERT statements is allowed. However, data manipulation language (DML) and data definition language (DDL) statements execute atomically. Any statements attempting to execute while an atomic batch is executing are blocked. Parallel execution at the server is not a MARS feature.  
  
 If two batches are submitted under a MARS connection, one of them containing a SELECT statement, the other containing a DML statement, the DML can begin execution within execution of the SELECT statement. However, the DML statement must run to completion before the SELECT statement can make progress. If both statements are running under the same transaction, any changes made by a DML statement after the SELECT statement has started execution are not visible to the read operation.  
  
 A WAITFOR statement inside a SELECT statement does not yield the transaction while it is waiting, that is, until the first row is produced. This implies that no other batches can execute within the same connection while a WAITFOR statement is waiting.  
  
### MARS Session Cache  
 When a connection is opened with MARS enabled, a logical session is created, which adds additional overhead. To minimize overhead and enhance performance, **SqlClient** caches the MARS session within a connection. The cache contains at most 10 MARS sessions. This value is not user adjustable. If the session limit is reached, a new session is created—an error is not generated. The cache and sessions contained in it are per-connection; they are not shared across connections. When a session is released, it is returned to the pool unless the pool's upper limit has been reached. If the cache pool is full, the session is closed. MARS sessions do not expire. They are only cleaned up when the connection object is disposed. The MARS session cache is not preloaded. It is loaded as the application requires more sessions.  
  
### Thread Safety  
 MARS operations are not thread-safe.  
  
### Connection Pooling  
 MARS-enabled connections are pooled like any other connection. If an application opens two connections, one with MARS enabled and one with MARS disabled, the two connections are in separate pools. For more information, see [SQL Server Connection Pooling (ADO.NET)](../../../../../docs/framework/data/adonet/sql-server-connection-pooling.md).  
  
### SQL Server Batch Execution Environment  
 When a connection is opened, a default environment is defined. This environment is then copied into a logical MARS session.  
  
 The batch execution environment includes the following components:  
  
-   Set options (for example, ANSI_NULLS, DATE_FORMAT, LANGUAGE, TEXTSIZE)  
  
-   Security context (user/application role)  
  
-   Database context (current database)  
  
-   Execution state variables (for example, @@ERROR, @@ROWCOUNT, @@FETCH_STATUS @@IDENTITY)  
  
-   Top-level temporary tables  
  
 With MARS, a default execution environment is associated to a connection. Every new batch that starts executing under a given connection receives a copy of the default environment. Whenever code is executed under a given batch, all changes made to the environment are scoped to the specific batch. Once execution finishes, the execution settings are copied into the default environment. In the case of a single batch issuing several commands to be executed sequentially under the same transaction, semantics are the same as those exposed by connections involving earlier clients or servers.  
  
### Parallel Execution  
 MARS is not designed to remove all requirements for multiple connections in an application. If an application needs true parallel execution of commands against a server, multiple connections should be used.  
  
 For example, consider the following scenario. Two command objects are created, one for processing a result set and another for updating data; they share a common connection via MARS. In this scenario, the `Transaction`.`Commit` fails on the update until all the results have been read on the first command object, yielding the following exception:  
  
 Message: Transaction context in use by another session.  
  
 Source: .Net SqlClient Data Provider  
  
 Expected: (null)  
  
 Received: System.Data.SqlClient.SqlException  
  
 There are three options for handling this scenario:  
  
1.  Start the transaction after the reader is created, so that it is not part of the transaction. Every update then becomes its own transaction.  
  
2.  Commit all work after the reader is closed. This has the potential for a substantial batch of updates.  
  
3.  Don't use MARS; instead use a separate connection for each command object as you would have before MARS.  
  
### Detecting MARS Support  
 An application can check for MARS support by reading the `SqlConnection.ServerVersion` value. The major number should be 9 for SQL Server 2005 and 10 for SQL Server 2008.  
  
## See Also  
 [Multiple Active Result Sets (MARS)](../../../../../docs/framework/data/adonet/sql/multiple-active-result-sets-mars.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
