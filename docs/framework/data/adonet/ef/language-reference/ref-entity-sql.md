---
title: "REF (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: c5f4cb35-69e9-44cc-b63b-ee38922bbda1
---
# REF (Entity SQL)
Returns a reference to an entity instance.  
  
## Syntax  
  
```sql  
REF( expression )   
```  
  
## Arguments  
 `expression`  
 Any valid expression that yields an instance of an entity type.  
  
## Return Value  
 A reference to the specified entity instance.  
  
## Remarks  
 An entity reference consists of the entity key and an entity set name. Because different entity sets can be based on the same entity type, a particular entity key can appear in multiple entity sets. However, an entity reference is always unique. If the input expression represents a persisted entity, a reference to this entity will be returned. If the input expression is not a persisted entity, a null reference will be returned.  
  
 If the property extraction operator (.) is used to access a property of an entity, the reference is automatically dereferenced.  
  
## Example  
 The following Entity SQL query uses the REF operator to return the reference for an input entity argument. The same query dereferences the reference because we are using a property extraction operation (.) to access a property of the Product entity. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:  
  
1. Follow the procedure in [How to: Execute a Query that Returns PrimitiveType Results](../how-to-execute-a-query-that-returns-primitivetype-results.md).  
  
2. Pass the following query as an argument to the `ExecutePrimitiveTypeQuery` method:  
  
 [!code-csharp[DP EntityServices Concepts 2#REF](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#ref)]  
  
## See also

- [DEREF](deref-entity-sql.md)
- [CREATEREF](createref-entity-sql.md)
- [KEY](key-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
- [Type Definitions](type-definitions-entity-sql.md)
