---
description: "Learn more about: USING (Entity SQL)"
title: "USING (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 20f58b8f-6070-4456-b7e8-5ff3d6269273
---
# USING (Entity SQL)

Specifies namespaces used in a query expression.  
  
## Syntax  
  
```sql  
USING [ alias = ] namespace  
```  
  
## Arguments  

 `alias`  
 Specifies a shorter alias to qualify a namespace with.  
  
 `namespace`  
 Any valid namespace.  
  
## Example  

 The following Entity SQL query uses the USING operator to specify namespaces used in a query expression. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2. Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
```csharp
using SqlServer; RAND()  
```  
  
## See also

- [Namespaces](namespaces-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
