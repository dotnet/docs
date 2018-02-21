---
title: "HAVING (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b5d52d97-8372-4335-beac-2d0b79dc3707
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# HAVING (Entity SQL)
Specifies a search condition for a group or an aggregate.  
  
## Syntax  
  
```  
[ HAVING search_condition ]  
```  
  
## Arguments  
 `search_condition`  
 Specifies the search condition for the group or the aggregate to meet. When HAVING is used with GROUP BY ALL, the HAVING clause overrides ALL.  
  
## Remarks  
 The HAVING clause is used to specify an additional filtering condition on the result of a grouping. If no GROUP BY clause is specified in the query expression, an implicit single-set group is assumed.  
  
> [!NOTE]
>  HAVING can be used only with the [SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md) statement. When [GROUP BY](../../../../../../docs/framework/data/adonet/ef/language-reference/group-by-entity-sql.md) is not used, HAVING behaves like a WHERE clause.  
  
 The HAVING clause works like the WHERE clause except that it is applied after the GROUP BY operation. This means that the HAVING clause can only make references to grouping aliases and aggregates, as illustrated in the following example.  
  
```  
SELECT Name, SUM(o.Price * o.Quantity) AS Total FROM orderLines AS o GROUP BY o.Product AS Name  
HAVING SUM(o.Quantity) > 1  
```  
  
 The previous restricts the groups to only those that include more than one product.  
  
## Example  
 The following Entity SQL query uses the HAVING and GROUP BY operators to specify a search condition for a group or an aggregate. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2.  Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#HAVING](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#having)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Query Expressions](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expressions-entity-sql.md)
