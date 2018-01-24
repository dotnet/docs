---
title: "How to: Make Model and Mapping Files Embedded Resources"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 20dfae4d-e95a-4264-9540-f5ad23b462d3
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# How to: Make Model and Mapping Files Embedded Resources
The [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] enables you to deploy model and mapping files as embedded resources of an application. The assembly with the embedded model and mapping files must be loaded in the same application domain as the entity connection. For more information, see [Connection Strings](../../../../../docs/framework/data/adonet/ef/connection-strings.md). By default, the [!INCLUDE[adonet_edm](../../../../../includes/adonet-edm-md.md)] tools embed the model and mapping files. When you manually define the model and mapping files, use this procedure to ensure that the files are deployed as embedded resources together with an [!INCLUDE[adonet_ef](../../../../../includes/adonet-ef-md.md)] application.  
  
> [!NOTE]
>  To maintain embedded resources, you must repeat this procedure whenever the model and mapping files are modified.  
  
### To embed model and mapping files  
  
1.  In **Solution Explorer**, select the conceptual (.csdl) file.  
  
2.  In the **Properties** pane, set **Build Action** to **Embedded Resource**.  
  
3.  Repeat steps 1 and 2 for the storage (.ssdl) file and the mapping (.msl) file.  
  
4.  In **Solution Explorer**, double-click the App.config file and then modify the `Metadata` parameter in the `connectionString` attribute based on one of the following formats:  
  
    -   `Metadata=` `res://<assemblyFullName>/<resourceName>;`  
  
    -   `Metadata=` `res://*/<resourceName>;`  
  
    -   `Metadata=res://*;`  
  
     For more information, see [Connection Strings](../../../../../docs/framework/data/adonet/ef/connection-strings.md).  
  
## Example  
 The following connection string references embedded model and mapping files for the [AdventureWorks Sales Model](http://msdn.microsoft.com/library/f16cd988-673f-4376-b034-129ca93c7832). This connection string is stored in the project's App.config file.  
  
  
  
## See Also  
 [Modeling and Mapping](../../../../../docs/framework/data/adonet/ef/modeling-and-mapping.md)  
 [How to: Define the Connection String](../../../../../docs/framework/data/adonet/ef/how-to-define-the-connection-string.md)  
 [How to: Build an EntityConnection Connection String](../../../../../docs/framework/data/adonet/ef/how-to-build-an-entityconnection-connection-string.md)  
 [ADO.NET Entity Data Model  Tools](http://msdn.microsoft.com/library/91076853-0881-421b-837a-f582f36be527)
