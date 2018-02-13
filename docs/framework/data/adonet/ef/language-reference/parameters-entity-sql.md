---
title: "Parameters (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8d618edd-0988-4ff2-8263-ce59448af7a5
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Parameters (Entity SQL)
Parameters are variables that are defined outside [!INCLUDE[esql](../../../../../../includes/esql-md.md)], usually through a binding API that is used by a host language. Each parameter has a name and a type. Parameter names are defined in query expressions with the at (@) symbol as a prefix. This disambiguates them from the names of properties or other names that are defined in the query.  
  
 The host-language binding API provides APIs for binding parameters.  
  
## Example  
  
```  
select c   
      from LOB.Customers as c   
      where c.Name = @name  
```  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
