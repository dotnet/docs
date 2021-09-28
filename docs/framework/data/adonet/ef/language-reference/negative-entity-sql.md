---
description: "Learn more about: - (Negative) (Entity SQL)"
title: "- (Negative) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 208e54ef-4741-4ec5-89d6-6ff700863cb0
---
# - (Negative) (Entity SQL)

Returns the negative of the value of a numeric expression.  
  
## Syntax  
  
```sql  
- expression  
```  
  
## Arguments  

 `expression`  
 Any valid expression of any one of the numeric data types.  
  
## Result Types  

 The data type of `expression`.  
  
## Remarks  

 If `expression` is an unsigned type, the result type will be the signed type that most closely relates to the type of `expression`. For example, if `expression` is of type Byte, a value of type Int16 will be returned.  
  
## Example  

 The following Entity SQL query uses the - arithmetic operator to return the negative of the value of a numeric expression. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#NEGATIVE](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#negative)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
