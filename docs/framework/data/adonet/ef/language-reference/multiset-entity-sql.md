---
description: "Learn more about: MULTISET (Entity SQL)"
title: "MULTISET (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: eb90a377-e47a-43a5-b308-e993b6d611e6
---
# MULTISET (Entity SQL)

Creates an instance of a multiset from a list of values. All the values in the MULTISET constructor must be of a compatible type `T`. Empty multiset constructors are not allowed.

## Syntax

```sql
MULTISET ( expression [{, expression }] )
-- or
{ expression [{, expression }] }
```

## Arguments

`expression`
 Any valid list of values.

## Return Value

A collection of type MULTISET\<T>.

## Remarks

<!-- markdownlint-disable DOCSMD001 -->

Entity SQL provides three kinds of constructors: row constructors, object constructors, and multiset (or collection) constructors. For more information, see [Constructing Types](constructing-types-entity-sql.md).

The multiset constructor creates an instance of a multiset from a list of values. All the values in the constructor must be of a compatible type.

For example, the following expression creates a multiset of integers.

`MULTISET(1, 2, 3)`

`{1, 2, 3}`

> [!NOTE]
> Nested multiset literals are only supported when a wrapping multiset has a single multiset element; for example, `{{1, 2, 3}}`. When the wrapping multiset has multiple multiset elements (for example, `{{1, 2}, {3, 4}}`), nested multiset literals are not supported.

## Example

The following Entity SQL query uses the MULTISET operator to create an instance of a multiset from a list of values. The query is based on the AdventureWorks Sales Model. To compile and run this query, follow these steps:

1. Follow the procedure in [How to: Execute a Query that Returns StructuralType Results](../how-to-execute-a-query-that-returns-structuraltype-results.md).

2. Pass the following query as an argument to the `ExecuteStructuralTypeQuery` method:

[!code-sql[DP EntityServices Concepts#MULTISET](~/samples/snippets/tsql/VS_Snippets_Data/dp entityservices concepts/tsql/entitysql.sql#multiset)]

## See also

- [Constructing Types](constructing-types-entity-sql.md)
- [Entity SQL Reference](entity-sql-reference.md)
