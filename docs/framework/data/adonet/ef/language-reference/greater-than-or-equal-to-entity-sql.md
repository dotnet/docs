---
title: ">= (Greater Than or Equal To) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 70780ac4-0123-4da8-b731-8af856daffe3
---
# >= (Greater Than or Equal To) (Entity SQL)
Compares two expressions to determine whether the left expression has a value greater than or equal to the right expression.  
  
## Syntax  
  
```sql  
expression >= expression  
```  
  
## Arguments  
 `expression`  
 Any valid expression. Both expressions must have implicitly convertible data types.  
  
## Result Types  
 `true` if the left expression has a value greater than or equal to the right expression; otherwise, `false`.  
  
## Example  
 The following Entity SQL query uses >= comparison operator to compare two expressions to determine whether the left expression has a value greater than or equal to the right expression. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#GREATER_OR_EQUALS](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#greater_or_equals)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
