---
description: "Learn more about: FLATTEN (Entity SQL)"
title: "FLATTEN (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 1a670c63-0a29-4738-80e6-101f66af05c3
---
# FLATTEN (Entity SQL)

Converts a collection of collections into a flattened collection. The new collection contains all the same elements as the old collection, but without a nested structure.

## Syntax

```sql
FLATTEN ( collection )
```

## Arguments

 `collection`
 Any valid expression that returns a collection of value collections to flatten into a single collection.

## Remarks

 `FLATTEN` is one of the Entity SQL set operators. All Entity SQL set operators are evaluated from left to right. See [EXCEPT](except-entity-sql.md) for precedence information for the Entity SQL set operators.

## Example

 The following Entity SQL query uses the `FLATTEN` operator to convert a collection of collections into a flattened collection. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#FLATTEN](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#flatten)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
