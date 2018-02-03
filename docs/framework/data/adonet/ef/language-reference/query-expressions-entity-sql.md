---
title: "Query Expressions (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c36f327b-e230-48d4-bbd5-78dc6478c447
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Query Expressions (Entity SQL)
A query expression combines many different query operators into a single syntax. [!INCLUDE[esql](../../../../../../includes/esql-md.md)] provides various kinds of expressions, including the following: [literals](../../../../../../docs/framework/data/adonet/ef/language-reference/literals-entity-sql.md), [parameters](../../../../../../docs/framework/data/adonet/ef/language-reference/parameters-entity-sql.md), [variables](../../../../../../docs/framework/data/adonet/ef/language-reference/variables-entity-sql.md), operators, [functions](../../../../../../docs/framework/data/adonet/ef/language-reference/functions-entity-sql.md), set operators, and so on. For more information, see [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md).  
  
## Clauses  
 A query expression is composed of a series of clauses that apply successive operations to a collection of objects. They are based on the same clauses found in standard a SQL select statement: [SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md), [FROM](../../../../../../docs/framework/data/adonet/ef/language-reference/from-entity-sql.md), [WHERE](../../../../../../docs/framework/data/adonet/ef/language-reference/where-entity-sql.md), [GROUP BY](../../../../../../docs/framework/data/adonet/ef/language-reference/group-by-entity-sql.md), [HAVING](../../../../../../docs/framework/data/adonet/ef/language-reference/having-entity-sql.md), and [ORDER BY](../../../../../../docs/framework/data/adonet/ef/language-reference/order-by-entity-sql.md).  
  
## Scope  
 Names defined in the FROM clause are introduced into the FROM scope in order of appearance, left to right. In the JOIN list, expressions can refer to names defined earlier in the list. Public properties of elements identified in the FROM clause are not added to the FROM scope: They must be always referenced through the alias-qualified name. Normally, all parts of the select expression are considered within the FROM scope.  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)
