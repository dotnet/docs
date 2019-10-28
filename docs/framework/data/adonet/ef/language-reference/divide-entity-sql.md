---
title: "- (Divide) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: ef48c368-f3ed-4275-8ada-4e9649781262
---
# / (Divide) (Entity SQL)
Divides one number by another.  
  
## Syntax  
  
```sql  
dividend / divisor  
```  
  
## Arguments  
 `dividend`  
 The numeric expression to divide. `dividend` is any valid expression of any one of the numeric data types.  
  
 `divisor`  
 The numeric expression to divide the dividend by. `divisor` is any valid expression of any one of the numeric data types.  
  
## Result Types  
 The data type that results from the implicit type promotion of the two arguments. For more information about implicit type promotion, see [Type System](type-system-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the / arithmetic operator to divide one number by another. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#DIVIDE](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#divide)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
