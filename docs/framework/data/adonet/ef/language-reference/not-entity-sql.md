---
title: "! (NOT) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: a1447a34-df06-4393-93c3-0612ebd41abc
---
# ! (NOT) (Entity SQL)
Negates a `Boolean` expression.  
  
## Syntax  
  
```sql  
NOT boolean_expression  
-- or  
! boolean_expression  
``` 
  
## Arguments  
 `boolean_expression`  
 Any valid expression that returns a Boolean.  
  
## Remarks  
 The exclamation point (!) has the same functionality as the NOT operator.  
  
## Example  
 The following Entity SQL query uses the NOT operator to negates a `Boolean` expression. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts 2#NOT](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#not)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
