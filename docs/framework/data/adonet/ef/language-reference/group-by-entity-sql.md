---
title: "GROUP BY (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cf4f4972-4724-4945-ba44-943a08549139
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# GROUP BY (Entity SQL)
Specifies groups into which objects returned by a query ([SELECT](../../../../../../docs/framework/data/adonet/ef/language-reference/select-entity-sql.md)) expression are to be placed.  
  
## Syntax  
  
```  
[ GROUP BY aliasedExpression [ ,...n ] ]  
```  
  
## Arguments  
 `aliasedExpression`  
 Any valid query expression on which grouping is performed. `expression` can be a property or a non-aggregate expression that references a property returned by the FROM clause. Each expression in a GROUP BY clause must evaluate to a type that can be compared for equality. These types are generally scalar primitives such as numbers, strings, and dates. You cannot group by a collection.  
  
## Remarks  
 If aggregate functions are included in the SELECT clause \<select list>, GROUP BY calculates a summary value for each group. When GROUP BY is specified, either each property name in any nonaggregate expression in the select list should be included in the GROUP BY list, or the GROUP BY expression must exactly match the select list expression.  
  
> [!NOTE]
>  If the ORDER BY clause is not specified, groups returned by the GROUP BY clause are not in any particular order. To specify a particular ordering of the data, we recommend that you always use the ORDER BY clause.  
  
 When a GROUP BY clause is specified, either explicitly or implicitly (for example, by a HAVING clause in the query), the current scope is hidden, and a new scope is introduced.  
  
 The SELECT clause, the HAVING clause, and the ORDER BY clause will no longer be able to refer to element names specified in the FROM clause. You can only refer to the grouping expressions themselves. To do this, you can assign new names (aliases) to each grouping expression. If no alias is specified for a grouping expression, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] tries to generate one by using the alias generation rules, as illustrated in the following example.  
  
 `SELECT g1, g2, ...gn FROM c as c1`  
  
 `GROUP BY e1 as g1, e2 as g2, ...en as gn`  
  
 Expressions in the GROUP BY clause cannot refer to names defined earlier in the same GROUP BY clause.  
  
 In addition to grouping names, you can also specify aggregates in the SELECT clause, HAVING clause, and the ORDER BY clause. An aggregate contains an expression that is evaluated for each element of the group. The aggregate operator reduces the values of all these expressions (usually, but not always, into a single value). The aggregate expression can make references to the original element names visible in the parent scope, or to any of the new names introduced by the GROUP BY clause itself. Although the aggregates appear in the SELECT clause, HAVING clause, and ORDER BY clause, they are actually evaluated under the same scope as the grouping expressions, as illustrated in the following example.  
  
 `SELECT name, sum(o.Price * o.Quantity) as total`  
  
 `FROM orderLines as o`  
  
 `GROUP BY o.Product as name`  
  
 This query uses the GROUP BY clause to produce a report of the cost of all products ordered, broken down by product. It gives the name `name` to the product as part of the grouping expression, and then references that name in the SELECT list. It also specifies the aggregate `sum` in the SELECT list that internally references the price and quantity of the order line.  
  
 Each GROUP By key expression must have at least one reference to the input scope:  
  
```  
SELECT FROM Persons as P  
GROUP BY Q + P   -- GOOD  
GROUP BY Q   -- BAD  
GROUP BY 1   -- BAD, a constant is not allowed  
```  
  
 For an example of using GROUP BY, see [HAVING](../../../../../../docs/framework/data/adonet/ef/language-reference/having-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the GROUP BY operator to specify groups into which objects are returned by a query. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2.  Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#GROUPBY](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#groupby)]  
  
## See Also  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [Query Expressions](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expressions-entity-sql.md)
