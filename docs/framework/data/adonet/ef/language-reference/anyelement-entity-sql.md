---
description: "Learn more about: ANYELEMENT (Entity SQL)"
title: "ANYELEMENT (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 475a9ad6-8c8d-4f49-9970-af273e5360f1
---
# ANYELEMENT (Entity SQL)

Extracts an element from a multivalued collection.

## Syntax

```csharp
ANYELEMENT ( expression )
```

## Arguments

 `expression`
 Any valid query expression that returns a collection to extract an element from.

## Return Value

 A single element in the collection or an arbitrary element if the collection has more than one; if the collection is empty, returns `null`. If `collection` is a collection of type `Collection<T>`, then `ANYELEMENT(collection)` is a valid expression that yields an instance of type `T`.

## Remarks

 ANYELEMENT extracts an arbitrary element from a multivalued collection. For example, the following example attempts to extract a singleton element from the set `Customers`.

```csharp
ANYELEMENT(Customers)
```

## Example

 The following Entity SQL query uses the ANYELEMENT operator to extract an element from a multivalued collection. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-csharp[DP EntityServices Concepts 2#ANYELEMENT](../../../../../../samples/snippets/csharp/VS_Snippets_Data/dp entityservices concepts 2/cs/entitysql.cs#anyelement)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
- [Nullable Structured Types](nullable-structured-types-entity-sql.md)
