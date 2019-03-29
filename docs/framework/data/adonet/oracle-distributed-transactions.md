---
title: "Oracle Distributed Transactions"
ms.date: "03/30/2017"
ms.assetid: c340ca81-ef79-402f-b204-c5156b890fe5
---
# Oracle Distributed Transactions
The <xref:System.Data.OracleClient.OracleConnection> object automatically enlists in an existing distributed transaction if it determines that a transaction is active. Automatic transaction enlistment occurs when the connection is opened or retrieved from the connection pool. You can disable auto-enlistment in existing transactions by specifying  
  
```  
Enlist=false  
```  
  
 as a connection string parameter for an <xref:System.Data.OracleClient.OracleConnection>.  
  
## See also
- [Oracle and ADO.NET](../../../../docs/framework/data/adonet/oracle-and-adonet.md)
- [ADO.NET Managed Providers and DataSet Developer Center](https://go.microsoft.com/fwlink/?LinkId=217917)
