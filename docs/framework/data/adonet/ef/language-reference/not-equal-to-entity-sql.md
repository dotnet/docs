---
description: "Learn more about: != (Not Equal To) (Entity SQL)"
title: "!= (Not Equal To) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 3b4a02ad-ddfc-4c42-8dfa-676234461312
---
# != (Not Equal To) (Entity SQL)

Compares two expressions to determine whether the left expression is not equal to the right expression. The != (Not Equal To) operator is functionally equivalent to the <> operator.  
  
## Syntax  
  
```sql  
expression != expression  
-- or  
expression <> expression  
```  
  
## Arguments  

 `expression`  
 Any valid expression. Both expressions must have implicitly convertible data types.  
  
## Result Types  

 `true` if the left expression is not equal to the right expression; otherwise, `false`.  
  
## Example  

 The following Entity SQL query uses the != operator to compare two expressions to determine whether the left expression is not equal to the right expression. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#NOT_EQUALS](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#not_equals)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
