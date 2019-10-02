---
title: "+ (String Concatenation) (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 580130fa-6c7c-4f76-a47d-d22c27ccadf6
---
# + (String Concatenation) (Entity SQL)
Concatenates two strings.  
  
## Syntax  
  
```sql  
expression + expression  
```  
  
## Arguments  
 `expression`  
 Any valid expression of the EDM.String data types. Both expressions must be of the same data type, or one expression must be able to be implicitly converted to the data type of the other expression.  
  
## Result Types  
 The data type that results from the implicit type promotion of the two arguments. For more information about implicit type promotion, see [Type System](type-system-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the + operator to concatenates two strings. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2. Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts 2#CONCAT](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts 2/tsql/entitysql.sql#concat)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Conceptual Model Types (CSDL)](/ef/ef6/modeling/designer/advanced/edmx/csdl-spec#conceptual-model-types-csdl)
