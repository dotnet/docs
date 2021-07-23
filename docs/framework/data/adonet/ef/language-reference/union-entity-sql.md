---
description: "Learn more about: UNION (Entity SQL)"
title: "UNION (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: df98a4db-b00d-4c8b-bd74-0d285f27e1df
---
# UNION (Entity SQL)

Combines the results of two or more queries into a single collection.

## Syntax

```sql
expression
UNION [ ALL ]
expression
```

## Arguments

 `expression`
 Any valid query expression that returns a collection to combine with the collection All expressions must be of the same type or of a common base or derived type as `expression`.

 UNION
 Specifies that multiple collections are to be combined and returned as a single collection.

 ALL
 Specifies that multiple collections are to be combined and returned as a single collection, including duplicates. If not specified, duplicates are removed from the result collection.

## Return Value

 A collection of the same type or of a common base or derived type as `expression`.

## Remarks

 UNION is one of the Entity SQL set operators. All Entity SQL set operators are evaluated from left to right. For precedence information for the Entity SQL set operators, see [EXCEPT](except-entity-sql.md).

## Example

 The following Entity SQL query uses the UNION ALL operator to combine the results of two queries into a single collection. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#UNION](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#union)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
