---
title: "EXCEPT (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 69cc23e5-3f8f-4b49-b20e-2f84ff11c80d
---
# EXCEPT (Entity SQL)
Returns a collection of any distinct values from the query expression to the left of the EXCEPT operand that are not also returned from the query expression to the right of the EXCEPT operand. All expressions must be of the same type or of a common base or derived type as `expression`.  
  
## Syntax  
  
```sql  
expression EXCEPT expression  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns a collection to compare with the collection returned from another query expression.  
  
## Return Value  
 A collection of the same type or of a common base or derived type as `expression`.  
  
## Remarks  
 EXCEPT is one of the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators. All [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators are evaluated from left to right. The following table shows the precedence of the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] set operators.  
  
|Precedence|Operators|  
|----------------|---------------|  
|Highest|INTERSECT|  
||UNION<br /><br /> UNION ALL|  
||EXCEPT|  
|Lowest|EXISTS<br /><br /> OVERLAPS<br /><br /> FLATTEN<br /><br /> SET|  
  
## Example  
 The following Entity SQL query uses the EXCEPT operator to return a collection of any distinct values from two query expressions. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#EXCEPT](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#except)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
