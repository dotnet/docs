---
title: "KEY (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: cbaa97a8-c89c-4460-8c74-00474695789f
---
# KEY (Entity SQL)
Extracts the key of a reference or of an entity expression.  
  
## Syntax  
  
```sql  
KEY(createref_expression)  
```  
  
## Remarks  
 An entity key contains the key values in the correct order of the specified entity or entity reference. Because multiple entity sets can be based on the same type, the same key might appear in each entity set. To get a unique reference, use `REF`. The return type of the KEY operator is a row type that includes one field for each key of the entity, in the same order.  
  
 In the following example, the key operator is passed a reference to the BadOrder entity, and returns the key portion of that reference. In this case, a record type with exactly one field corresponding to the `Id` property.  
  
```sql  
select Key( CreateRef(LOB.BadOrders, row(o.Id)) )   
from LOB.Orders as o  
```  
  
## Example  
 The following Entity SQL query uses the KEY operator to extract the key portion of an expression with type reference. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#KEY](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#key)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [CREATEREF](createref-entity-sql.md)
- [REF](ref-entity-sql.md)
- [DEREF](deref-entity-sql.md)
