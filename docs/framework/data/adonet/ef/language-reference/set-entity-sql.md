---
title: "SET (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 28b4deac-c7e4-4f09-b428-4d352ef2dc94
---
# SET (Entity SQL)
The SET expression is used to convert a collection of objects into a set by yielding a new collection with all duplicate elements removed.  
  
## Syntax  
  
```sql  
SET ( expression )  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns a collection.  
  
## Remarks  
 The set expression `SET(c)` is logically equivalent to the following select statement:  
  
```sql  
SELECT VALUE DISTINCT c FROM c  
```  
  
 `SET` is one of the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators. All [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators are evaluated from left to right. See [EXCEPT](except-entity-sql.md) for precedence information for the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators.  
  
## Example  
 The following Entity SQL query uses the SET expression to convert a collection of objects into a set. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2. Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts 2#SET](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts 2/tsql/entitysql.sql#set)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
