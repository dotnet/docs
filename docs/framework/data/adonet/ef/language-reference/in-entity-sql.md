---
title: "IN (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 51662950-ee01-4857-b7b9-311dd8515966
---
# IN (Entity SQL)
Determines whether a value matches any value in a collection.  
  
## Syntax  
  
```sql  
value [ NOT ] IN expression  
```  
  
## Arguments  
 `value`  
 Any valid expression that returns the value to match.  
  
 [ NOT ]  
 Specifies that the `Boolean` result of IN be negated.  
  
 `expression`  
 Any valid expression that returns the collection to test for a match. All expressions must be of the same type or of a common base or derived type as `value`.  
  
## Return Value  
 `true` if the value is found in the collection; null if the value is null or the collection is null; otherwise, `false`. Using NOT IN negates the results of IN.  
  
## Example  
 The following Entity SQL query uses the IN operator to determine whether a value matches any value in a collection. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#IN](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#in)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
