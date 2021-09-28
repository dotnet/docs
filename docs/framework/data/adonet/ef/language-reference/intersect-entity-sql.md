---
description: "Learn more about: INTERSECT (Entity SQL)"
title: "INTERSECT (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 93c6fe33-f341-4b52-911e-adf503891951
---
# INTERSECT (Entity SQL)

Returns a collection of any distinct values that are returned by both the query expressions on the left and right sides of the INTERSECT operand. All expressions must be of the same type or of a common base or derived type as `expression`.

## Syntax

```sql
expression INTERSECT expression
```

## Arguments

 `expression`
 Any valid query expression that returns a collection to compare with the collection returned from another query expression.

## Return Value

 A collection of the same type or of a common base or derived type as `expression`.

## Remarks

 INTERSECT is one of the Entity SQL set operators. All Entity SQL set operators are evaluated from left to right. For precedence information for the Entity SQL set operators, see [EXCEPT](except-entity-sql.md).

## Example

 The following Entity SQL query uses the INTERSECT operator to return a collection of any distinct values that are returned by both the query expressions on the left and right sides of the INTERSECT operand. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

 [!code-sql[DP EntityServices Concepts#INTERSECT](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#intersect)]

## See also

- [Entity SQL Reference](entity-sql-reference.md)
