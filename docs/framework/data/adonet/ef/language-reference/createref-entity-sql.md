---
title: "CREATEREF (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 489828cf-a335-4449-9360-b0d92eec5481
---
# CREATEREF (Entity SQL)
Fabricates references to an entity in an entityset.  
  
## Syntax  
  
```sql  
CreateRef(entityset_identifier, row_typed_expression)  
```  
  
## Arguments  
 `entityset_identifier`  
 The entityset identifier, not a string literal.  
  
 `row_typed_expression`  
 A row-typed expression that corresponds to the key properties of the entity type.  
  
## Remarks  
 `row_typed_expression` must be structurally equivalent to the key type for the entity. That is, it must have the same number and types of fields in the same order as the entity keys.  
  
 In the example below, Orders and BadOrders are both entitysets of type Order, and Id is assumed to be the single key property of Order. The example illustrates how we may produce a reference to an entity in BadOrders. Note that the reference may be dangling.  That is, the reference may not actually identify a specific entity. In those cases, a `DEREF` operation on that reference returns a null.  
  
```sql  
SELECT CreateRef(LOB.BadOrders, row(o.Id))
FROM LOB.Orders AS o
```  
  
## Example  
 The following Entity SQL query uses the CREATEREF operator to fabricate references to an entity in an entity set. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).  
  
2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:  
  
 [!code-sql[DP EntityServices Concepts#CREATEREF](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#createref)]  
  
## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [DEREF](deref-entity-sql.md)
- [KEY](key-entity-sql.md)
- [REF](ref-entity-sql.md)
