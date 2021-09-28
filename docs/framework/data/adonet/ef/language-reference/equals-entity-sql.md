---
description: "Learn more about: = (Equals) (Entity SQL)"
title: "= (Equals) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 948eb588-7080-4046-bb48-633b007393bf
---
# = (Equals) (Entity SQL)

Compares the equality of two expressions.  
  
## Syntax  
  
```sql  
expression = expression  
-- or
expression == expression  
```  
  
## Arguments  

 `expression`  
 Any valid expression. Both expressions must have implicitly convertible data types.  
  
## Result Types  

 `true` if the left expression is equal to the right expression; otherwise, `false`.  
  
## Remarks  

 The == operator is equivalent to =.  
  
## Example  

 The following Entity SQL query uses = comparison operator to compare the equality of two expressions. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#EQUALS](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#equals)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
