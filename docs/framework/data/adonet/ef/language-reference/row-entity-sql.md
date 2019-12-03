---
title: "ROW (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 06da96e8-55d7-486c-991a-4e514d837ff9
---
# ROW (Entity SQL)
Constructs anonymous, structurally typed records from one or more values.  
  
## Syntax  
  
```sql  
ROW ( expression [ AS alias ] [,...] )  
```  
  
## Arguments  
 `expression`  
 Any valid query expression that returns a value to construct in a row type.  
  
 `alias`  
 Specifies an alias for the value specified in a row type. If an alias is not provided, [!INCLUDE[esql](../../../../../../includes/esql-md.md)] tries to generate an alias based on the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] alias generation rules.  
  
## Return Value  
 A row type.  
  
## Remarks  
 You use row constructors in the [!INCLUDE[esql](../../../../../../includes/esql-md.md)] to construct anonymous, structurally typed records from one or more values. The result type of a row constructor is a row type whose field types correspond to the types of the values that were used to construct the row. For example, the following expression constructs a value of type `Record(a int, b string, c int)`.  
  
```sql  
ROW(1 AS a, "abc" AS b, a+34 AS c)  
```  
  
 If you do not provide an alias for an expression in a row constructor, the Entity Framework will try to generate one. For more information, see the "Aliasing Rules" section of the [Identifiers](identifiers-entity-sql.md) topic.  
  
 The following rules apply to expression aliasing in a row constructor:  
  
- Expressions in a row constructor cannot refer to other aliases in the same constructor.  
  
- Two expressions in the same row constructor cannot have the same alias.  
  
 For more information about query constructors, see [Constructing Types](constructing-types-entity-sql.md).  
  
## Example  
 The following Entity SQL query uses the ROW operator to construct anonymous, structurally typed records. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#ROW](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#row)]  
  
## See also

- [Constructing Types](constructing-types-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
- [Type Definitions](type-definitions-entity-sql.md)
