---
title: "Variables (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3eed222a-f8f6-46b6-9cd5-220cc0e4e5d8
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Variables (Entity SQL)
## Variable  
 A variable expression is a reference to a named expression defined in the current scope. A variable reference must be a valid [!INCLUDE[esql](../../../../../../includes/esql-md.md)] identifier, as defined in [Identifiers](../../../../../../docs/framework/data/adonet/ef/language-reference/identifiers-entity-sql.md).  
  
 The following example shows the use of a variable in the expression. The `c` in the FROM clause is the definition of the variable. The use of `c` in the SELECT clause represents the variable reference.  
  
```  
select c   
from LOB.customers as c  
```  
  
## See Also  
 [Identifiers](../../../../../../docs/framework/data/adonet/ef/language-reference/identifiers-entity-sql.md)  
 [Parameters](../../../../../../docs/framework/data/adonet/ef/language-reference/parameters-entity-sql.md)  
 [Entity SQL Overview](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-overview.md)
