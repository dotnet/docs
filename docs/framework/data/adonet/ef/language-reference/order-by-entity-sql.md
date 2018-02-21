---
title: "ORDER BY (Entity SQL)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c0b61572-ecee-41eb-9d7f-74132ec8a26c
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# ORDER BY (Entity SQL)
Specifies the sort order used on objects returned in a SELECT statement.  
  
## Syntax  
  
```  
[ ORDER BY   
   {  
      order_by_expression [SKIP n] [LIMIT n]  
      [ COLLATE collation_name ]  
      [ ASC | DESC ]  
   }  
   [ ,…n ]   
]  
```  
  
## Arguments  
 `order_by_expression`  
 Any valid query expression specifying a property on which to sort. Multiple sort expressions can be specified. The sequence of the sort expressions in the ORDER BY clause defines the organization of the sorted result set.  
  
 COLLATE {collation_name}  
 Specifies that the ORDER BY operation should be performed according to the collation specified in `collation_name`. COLLATE is applicable only for string expressions.  
  
 ASC  
 Specifies that the values in the specified property should be sorted in ascending order, from lowest value to highest value. This is the default.  
  
 DESC  
 Specifies that the values in the specified property should be sorted in descending order, from highest value to lowest value.  
  
 LIMIT `n`  
 Only the first `n` items will be selected.  
  
 SKIP `n`  
 Skips the first `n` items.  
  
## Remarks  
 The ORDER BY clause is logically applied to the result of the SELECT clause. The ORDER BY clause can reference items in the select list by using their aliases. The ORDER BY clause can also reference other variables that are currently in-scope. However, if the SELECT clause has been specified with a DISTINCT modifier, the ORDER BY clause can only reference aliases from the SELECT clause.  
  
 `SELECT c AS c1 FROM cs AS c ORDER BY c1.e1, c.e2`  
  
 Each expression in the ORDER BY clause must evaluate to some type that can be compared for ordered inequality (less than or greater than, and so on). These types are generally scalar primitives such as numbers, strings, and dates. RowTypes of comparable types are also order comparable.  
  
 If your code iterates over an ordered set, other than for a top-level projection, the output is not guaranteed to have its order preserved.  
  
```  
-- In the following sample, order is guaranteed to be preserved:  
SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorks.Contact as C1  
        ORDER BY C1.LastName  
```  
  
```  
-- In the following query ordering of the nested query is ignored.  
SELECT C2.FirstName, C2.LastName  
    FROM (SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorks.Contact as C1  
        ORDER BY C1.LastName) as C2  
```  
  
 To have an ordered UNION, UNION ALL, EXCEPT, or INTERSECT operation, use the following pattern:  
  
```  
SELECT ...  
FROM ( UNION/EXCEPT/INTERSECT operation )  
ORDER BY ...  
```  
  
## Restricted keywords  
 The following keywords must be enclosed in quotation marks when used in an `ORDER BY` clause:  
  
-   CROSS  
  
-   FULL  
  
-   KEY  
  
-   LEFT  
  
-   ORDER  
  
-   OUTER  
  
-   RIGHT  
  
-   ROW  
  
-   VALUE  
  
## Ordering Nested Queries  
 In the Entity Framework, a nested expression can be placed anywhere in the query; the order of a nested query is not preserved.  
  
```  
-- The following query will order the results by the last name.  
SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorks.Contact as C1  
        ORDER BY C1.LastName  
```  
  
```  
-- In the following query, ordering of the nested query is ignored.  
SELECT C2.FirstName, C2.LastName  
    FROM (SELECT C1.FirstName, C1.LastName  
        FROM AdventureWorks.Contact as C1  
        ORDER BY C1.LastName) as C2  
```  
  
## Example  
 The following [!INCLUDE[esql](../../../../../../includes/esql-md.md)] query uses the ORDER BY operator to specify the sort order used on objects returned in a SELECT statement. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1.  Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../../../../../../docs/framework/data/adonet/ef/how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2.  Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#ORDERBY](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#orderby)]  
  
## See Also  
 [Query Expressions](../../../../../../docs/framework/data/adonet/ef/language-reference/query-expressions-entity-sql.md)  
 [Entity SQL Reference](../../../../../../docs/framework/data/adonet/ef/language-reference/entity-sql-reference.md)  
 [SKIP](../../../../../../docs/framework/data/adonet/ef/language-reference/skip-entity-sql.md)  
 [LIMIT](../../../../../../docs/framework/data/adonet/ef/language-reference/limit-entity-sql.md)  
 [TOP](../../../../../../docs/framework/data/adonet/ef/language-reference/top-entity-sql.md)
