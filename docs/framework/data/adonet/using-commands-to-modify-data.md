---
title: "Using Commands to Modify Data"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f4160389-b9ff-4b74-b655-437c76dcd586
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Using Commands to Modify Data
Using a .NET Framework data provider, you can execute stored procedures or data definition language statements (for example, CREATE TABLE and ALTER COLUMN) to perform schema manipulation on a database or catalog. These commands do not return rows as a query would, so the **Command** object provides an **ExecuteNonQuery** to process them.  
  
 In addition to using **ExecuteNonQuery** to modify schema, you can also use this method to process SQL statements that modify data but that do not return rows, such as INSERT, UPDATE, and DELETE.  
  
 Although rows are not returned by the **ExecuteNonQuery** method, input and output parameters and return values can be passed and returned via the **Parameters** collection of the **Command** object.  
  
## In This Section  
 [Updating Data in a Data Source](../../../../docs/framework/data/adonet/updating-data-in-a-data-source.md)  
 Describes how to execute commands or stored procedures that modify data in a database.  
  
 [Performing Catalog Operations](../../../../docs/framework/data/adonet/performing-catalog-operations.md)  
 Describes how to execute commands that modify database schema.  
  
## See Also  
 [Retrieving and Modifying Data in ADO.NET](../../../../docs/framework/data/adonet/retrieving-and-modifying-data.md)  
 [Commands and Parameters](../../../../docs/framework/data/adonet/commands-and-parameters.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
